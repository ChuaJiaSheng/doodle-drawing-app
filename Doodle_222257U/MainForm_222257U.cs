using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Doodle_222257U
{
    public partial class MainForm_222257U : Form
    {
        Bitmap bm;
        Bitmap emoji = new Bitmap(50, 50);
        Graphics g;
        Pen pen = new Pen(Color.Black, 30);
        SolidBrush brush = new SolidBrush(Color.Black);
        Point cursor;
        Point startP = new Point(0, 0);
        Point endP = new Point(0, 0);
        FontStyle fontStyle;
        bool flagDraw = false;
        bool flagBrush = false;
        bool flagErase = false;
        bool flagText = false;
        bool flagPen = false;
        bool flagEmoji = false;
        string strText;
        string emojiTag;
        string fileName;
        string fontName = "San Serif";
        float fontSize = 8;
        float brushSize;
        int emojiSize = 20;
        int eraserSize;

        public MainForm_222257U()
        {
            InitializeComponent();
        }
        private void chuaJiaSheng222257UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
            Clipboard.SetText(attribute.Value.ToString());
        }
        private void MainForm_222257U_Load(object sender, EventArgs e)
        {
            bm = new Bitmap(picBoxMain.Width, picBoxMain.Height);
            picBoxMain.Image = bm;
            picBoxBrush_Click(sender, e);
            // Set up the ComboBoxes for brush and eraser sizes
            cbbBrushSize.SelectedIndex = 0; // Default brush size
            cbbEraserSize.SelectedIndex = 7; // Default eraser size
            timer1.Start();
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }
        private void cbbBrushSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbBrushSize.SelectedItem != null)
            {
                // Retrieve the selected item
                string selectedSize = (string)cbbBrushSize.SelectedItem;
                double v = Convert.ToDouble(selectedSize);
                pen.Width = (float)v;
                brushSize = (float)v;
            }
        }
        private void cbbEraserSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbEraserSize.SelectedItem != null)
            {
                // Retrieve the selected item
                string selectedSize = (string)cbbEraserSize.SelectedItem;
                eraserSize = Convert.ToInt32(selectedSize);
            }
        }
        private void btnTextColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color col = colorDialog1.Color;
                picBoxBrushColor.BackColor = col;
            }
        }
        private void btnFontDialog_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fontName = dlg.Font.Name;
                fontSize = dlg.Font.Size;
                fontStyle = dlg.Font.Style;
            }
        }
        private void stripMenuLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofdlg = new OpenFileDialog())
            {
                ofdlg.Title = "Open Dialog";
                flagEmoji = false;
                string imgFileName = ofdlg.FileName;
                picBoxBrushColor.Image = Properties.Resources.fileload;
                if (ofdlg.ShowDialog(this) == DialogResult.OK)
                {
                    using (Bitmap bmp = new Bitmap(picBoxMain.Width, picBoxMain.Height))
                    {
                        Bitmap bgImg = new Bitmap(ofdlg.FileName);
                        ofdlg.Filter = "Image Files(*.BMP)|*.BMP|All files (*.*)|*.*";
                        fileName = ofdlg.FileName;
                        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                        picBoxMain.DrawToBitmap(bmp, rect);
                        picBoxMain.BackgroundImage = bgImg;
                        Console.WriteLine(bgImg);
                        
                        picBoxMain.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
            }
        }
        private void stripMenuCampus_Click(object sender, EventArgs e)
        {
            flagEmoji = false;
            picBoxItem.Image = Properties.Resources.fileload;
            Image img = Properties.Resources.campus;

            using (Bitmap bmp = new Bitmap(picBoxMain.Width, picBoxMain.Height))
            {
                Bitmap bgImg = new Bitmap(img);
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                picBoxMain.DrawToBitmap(bmp, rect);
                picBoxMain.BackgroundImage = bgImg;
                Console.WriteLine(bgImg);

                picBoxMain.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
        private void stripCat_Click(object sender, EventArgs e)
        {
            flagEmoji = false;
            picBoxItem.Image = Properties.Resources.fileload;
            Image img = Properties.Resources.drawCat;

            using (Bitmap bmp = new Bitmap(picBoxMain.Width, picBoxMain.Height))
            {
                Bitmap bgImg = new Bitmap(img);
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                picBoxMain.DrawToBitmap(bmp, rect);
                picBoxMain.BackgroundImage = bgImg;
                Console.WriteLine(bgImg);

                picBoxMain.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
        private void stripMenuSave_Click(object sender, EventArgs e)
        {
            flagEmoji = false;
            using (SaveFileDialog sfdlg = new SaveFileDialog())
            {
                sfdlg.Title = "Save Dialog";
                sfdlg.Filter = "Image Files(*.BMP)|*.BMP|All files (*.*)|*.*";
                if (sfdlg.ShowDialog(this) == DialogResult.OK)
                {
                    using (Bitmap bmp = new Bitmap(picBoxMain.Width, picBoxMain.Height))
                    {
                        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                        picBoxMain.DrawToBitmap(bmp, rect);
                        bmp.Save(sfdlg.FileName, ImageFormat.Bmp);
                        MessageBox.Show("File Saved Successfully");
                    }
                }
            }
        }
        private void txtBoxEmoji_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxEmoji.Text == "")
            {
                emojiSize = 1;
            }
            else if (txtBoxEmoji.Text == "0")
            {
                txtBoxEmoji.Text = "1";
                emojiSize = 1;
            }
            else
            {
                emojiSize = Convert.ToInt32(txtBoxEmoji.Text);
            }
        }
        private void picBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            startP = e.Location;
            if (flagText == false)
            {
                if (e.Button == MouseButtons.Left)
                    flagDraw = true;
            }
            else if (flagText == true)
            {
                flagDraw = true;
                Color color = picBoxBrushColor.BackColor;
                strText = txtBoxText.Text;

                g = Graphics.FromImage(bm);

                Font font = new Font(fontName, fontSize, fontStyle);

                g.DrawString(strText, font, brush, startP.X, startP.Y);
                g.Dispose();
                picBoxMain.Invalidate();
            }
            if (flagEmoji == true)
            {
                flagDraw = false;
                flagText = false;
                flagErase = false;
                emoji = new Bitmap(picBoxItem.Image, emojiSize, emojiSize);
                g = Graphics.FromImage(bm);
                g.DrawImage(emoji, startP);
                g.Dispose();
                picBoxMain.Invalidate();
            }
        }
        private void picBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            cursor = this.PointToClient(Cursor.Position); // get cursor position
            lblXYpos.Text = "X:" + (cursor.X - 15) + "   Y:" + (cursor.Y - 15); // update status bar
            if (flagDraw == true)
            {
                endP = e.Location;
                g = Graphics.FromImage(bm);
                if (flagErase == false)
                {
                    if (flagPen == true)
                    {
                        pen.Color = picBoxBrushColor.BackColor;
                        g.DrawLine(pen, startP, endP);
                    }
                    else if (flagBrush == true)
                    {
                        brush.Color = picBoxBrushColor.BackColor;
                        g.FillEllipse(brush, endP.X, endP.Y, brushSize, brushSize);
                    }
                }
                else
                {
                    g.FillRectangle(brush, endP.X, endP.Y, eraserSize, eraserSize);
                }
                g.Dispose();
                picBoxMain.Invalidate();
            }
            startP = endP;
        }
        private void picBoxMain_MouseUp(object sender, MouseEventArgs e)
        {
            flagDraw = false;
        }

        private void picBoxColour_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pen.Color = pb.BackColor;
            brush.Color = pb.BackColor;
            picBoxBrushColor.BackColor = pen.Color;
            picBoxBrushColor.Image = null;
            flagErase = false;
        }
        private void picBoxClear_Click(object sender, EventArgs e)
        {
            bm = new Bitmap(picBoxMain.Width, picBoxMain.Height);
            picBoxMain.Image = bm;
            picBoxItem.Image = Properties.Resources.clear;
            flagEmoji = false;
        }
        private void picBoxErase_Click(object sender, EventArgs e)
        {
            brush = new SolidBrush(picBoxMain.BackColor);
            picBoxItem.Image = Properties.Resources.erasor;
            flagErase = true;
            flagEmoji = false;
        }
        private void picBoxText_Click(object sender, EventArgs e)
        {
            picBoxItem.Image = Properties.Resources.text;
            flagDraw = false;
            flagText = true;
            flagErase = false;
            flagEmoji = false;
        }
        private void picBoxFill_Click(object sender, EventArgs e)
        {
            Color col = picBoxBrushColor.BackColor;
            picBoxMain.BackColor = col;
            picBoxItem.Image = Properties.Resources.fill;
            flagEmoji = false;
            flagDraw = false;
        }
        private void picBoxPen_Click(object sender, EventArgs e)
        {
            flagPen = true;
            flagText = false;
            flagBrush = false;
            flagErase = false;
            flagEmoji = false;
            picBoxItem.Image = Properties.Resources.pen;
        }
        private void picBoxEmoji_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            emojiTag = pb.Tag.ToString();
            flagEmoji = true;
            switch (emojiTag)
            {
                case "angelBlushingSmile":
                    picBoxItem.Image = Properties.Resources.angelBlushingSmile;
                    break;
                case "badSmiley":
                    picBoxItem.Image = Properties.Resources.badSmiley;
                    break;
                case "faceWithTearsOfJoy":
                    picBoxItem.Image = Properties.Resources.faceWithTearsOfJoy;
                    break;
                case "fearful":
                    picBoxItem.Image = Properties.Resources.fearful;
                    break;
                case "grinningFace":
                    picBoxItem.Image = Properties.Resources.grinningFace;
                    break;
                case "heartSmiley":
                    picBoxItem.Image = Properties.Resources.heartSmiley;
                    break;
                case "hondaUpAmazeThumbs":
                    picBoxItem.Image = Properties.Resources.hondaUpAmazeThumbs;
                    break;
                case "loudlyCrying":
                    picBoxItem.Image = Properties.Resources.loudlyCrying;
                    break;
                case "piracyPirate":
                    picBoxItem.Image = Properties.Resources.piracyPirate;
                    break;
                case "smiley":
                    picBoxItem.Image = Properties.Resources.smiley;
                    break;
                case "smileyThumb":
                    picBoxItem.Image = Properties.Resources.smileyThumb;
                    break;
                case "smilingFaceWithSunglassesCool":
                    picBoxItem.Image = Properties.Resources.smilingFaceWithSunglassesCool;
                    break;
                case "tongueOut":
                    picBoxItem.Image = Properties.Resources.tongueOut;
                    break;
                case "unamusedFace":
                    picBoxItem.Image = Properties.Resources.unamusedFace;
                    break;
                case "winkEmoji":
                    picBoxItem.Image = Properties.Resources.winkEmoji;
                    break;
            }
        }
        private void picBoxBrush_Click(object sender, EventArgs e)
        {
            flagBrush = true;
            flagText = false;
            flagPen = false;
            flagErase = false;
            flagEmoji = false;
            picBoxItem.Image = Properties.Resources.brush;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
        private void txtBoxEmoji_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void stripCalander_Click(object sender, EventArgs e)
        {
            if (monthCal.Visible == false)
            {
                monthCal.Visible = true;
            }
            else
            {
                monthCal.Visible = false;
            }
        }
        private void stripEmoji_Click(object sender, EventArgs e)
        {
            if (panelEmoji.Visible == false)
            {
                panelEmoji.Visible = true;
                lblEmojiSize.Visible = true;
                txtBoxEmoji.Visible = true;
            }
            else
            {
                panelEmoji.Visible = false;
                lblEmojiSize.Visible = false;
                txtBoxEmoji.Visible = false;
            }
        }
        private void stripDate_Click(object sender, EventArgs e)
        {
            if (lblDate.Visible == false)
            {
                lblDate.Visible = true;
            }
            else
            {
                lblDate.Visible = false;
            }
        }
        private void stripTime_Click(object sender, EventArgs e)
        {
            if (lblTime.Visible == false)
            {
                lblTime.Visible = true;
            }
            else
            {
                lblTime.Visible = false;
            }
        }
        private void stripCursorDefault_Click(object sender, EventArgs e)
        {
            chooseCursor frm = new chooseCursor();
            frm.ShowDialog();
            string type = frm.CursorType;
            if (type == "Default ")
            {
                this.Cursor = Cursors.Default;
            }
            else if (type == "Cross")
            {
                this.Cursor = Cursors.Cross;
            }
            else if (type == "IBeam")
            {
                this.Cursor = Cursors.IBeam;
            }
            else if (type == "No")
            {
                this.Cursor = Cursors.No;
            }
            else if (type == "SizeAll")
            {
                this.Cursor = Cursors.SizeAll;
            }
            else if (type == "Hand")
            {
                this.Cursor = Cursors.Hand;
            }
            else if (type == "SizeNESW")
            {
                this.Cursor = Cursors.SizeNESW;
            }
            else if (type == "SizeNS")
            {
                this.Cursor = Cursors.SizeNS;
            }
            else if (type == "SizeNWSE")
            {
                this.Cursor = Cursors.SizeNWSE;
            }
            else if (type == "SizeWE")
            {
                this.Cursor = Cursors.SizeWE;
            }
            else if (type == "WaitCursor")
            {
                this.Cursor = Cursors.WaitCursor;
            }
            else if (type == "AppStarting")
            {
                this.Cursor = Cursors.AppStarting;
            }
            else if (type == "Help")
            {
                this.Cursor = Cursors.Help;
            }
            else if (type == "HSplit")
            {
                this.Cursor = Cursors.HSplit;
            }
            else if (type == "NoMove2D")
            {
                this.Cursor = Cursors.NoMove2D;
            }
            else if (type == "NoMoveHoriz")
            {
                this.Cursor = Cursors.NoMoveHoriz;
            }
            else if (type == "NoMoveVert")
            {
                this.Cursor = Cursors.NoMoveVert;
            }
            else if (type == "PanEast")
            {
                this.Cursor = Cursors.PanEast;
            }
            else if (type == "PanNE")
            {
                this.Cursor = Cursors.PanNE;
            }
            else if (type == "PanNorth")
            {
                this.Cursor = Cursors.PanNorth;
            }
            else if (type == "PanNW")
            {
                this.Cursor = Cursors.PanNW;
            }
            else if (type == "PanSE")
            {
                this.Cursor = Cursors.PanSE;
            }
            else if (type == "PanSouth")
            {
                this.Cursor = Cursors.PanSouth;
            }
            else if (type == "PanSW")
            {
                this.Cursor = Cursors.PanSW;
            }
            else if (type == "PanWest")
            {
                this.Cursor = Cursors.PanWest;
            }
            else if (type == "UpArrow")
            {
                this.Cursor = Cursors.UpArrow;
            }
            else if (type == "VSplit")
            {
                this.Cursor = Cursors.VSplit;
            }
        }
        private void stripCursorComputer_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bm = new Bitmap(new Bitmap(ofd.FileName), 50, 50);

                Cursor = new Cursor(bm.GetHicon());
            }
        }
        private void stripGrey_Click(object sender, EventArgs e)
        {
            flagEmoji = false;
            Bitmap oImage;
            oImage = (Bitmap)picBoxMain.BackgroundImage;

            if (oImage == null)
                return;
            Color col;
            int red, green, blue, gray;
            for (int i = 0; i < oImage.Width; i++)
                for (int j = 0; j < oImage.Height; j++)
                {
                    col = oImage.GetPixel(i, j);
                    red = col.R;
                    green = col.G;
                    blue = col.B;
                    gray = (red + green + blue) / 3;
                    oImage.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            picBoxMain.Refresh();
        }
        private void scaleColor_Click(object sender, EventArgs e)
        {
            flagEmoji = false;
            using (Bitmap bmp = new Bitmap(picBoxMain.Width, picBoxMain.Height))
            {
                Bitmap bgImg = new Bitmap(fileName);
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                picBoxMain.DrawToBitmap(bmp, rect);
                picBoxMain.BackgroundImage = bgImg;

                picBoxMain.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
        private void trkHeight_Scroll(object sender, EventArgs e)
        {
            picBoxMain.Height = trkHeight.Value;
        }
        private void trkWidth_Scroll(object sender, EventArgs e)
        {
            picBoxMain.Width = trkWidth.Value;
        }
    }
}
