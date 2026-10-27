namespace Doodle_222257U
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.picBoxPassword = new System.Windows.Forms.PictureBox();
            this.picBoxLogin = new System.Windows.Forms.PictureBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblCkear = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin.Font = new System.Drawing.Font("Myanmar Text", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblLogin.Location = new System.Drawing.Point(427, 76);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(305, 94);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "User Login";
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Control;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtPassword.Font = new System.Drawing.Font("Modern No. 20", 20.25F);
            this.txtPassword.Location = new System.Drawing.Point(494, 233);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(236, 40);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            // 
            // picBoxPassword
            // 
            this.picBoxPassword.BackColor = System.Drawing.SystemColors.Control;
            this.picBoxPassword.Image = global::Doodle_222257U.Properties.Resources.password;
            this.picBoxPassword.Location = new System.Drawing.Point(433, 233);
            this.picBoxPassword.Name = "picBoxPassword";
            this.picBoxPassword.Size = new System.Drawing.Size(55, 40);
            this.picBoxPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxPassword.TabIndex = 3;
            this.picBoxPassword.TabStop = false;
            // 
            // picBoxLogin
            // 
            this.picBoxLogin.BackColor = System.Drawing.SystemColors.Control;
            this.picBoxLogin.Image = global::Doodle_222257U.Properties.Resources.loginIcon;
            this.picBoxLogin.Location = new System.Drawing.Point(433, 173);
            this.picBoxLogin.Name = "picBoxLogin";
            this.picBoxLogin.Size = new System.Drawing.Size(55, 40);
            this.picBoxLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxLogin.TabIndex = 4;
            this.picBoxLogin.TabStop = false;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtUsername.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(494, 173);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(236, 36);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.Control;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.btnLogin.Font = new System.Drawing.Font("Modern No. 20", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(433, 296);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(297, 39);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.lblExit.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblExit.Location = new System.Drawing.Point(558, 346);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(41, 18);
            this.lblExit.TabIndex = 5;
            this.lblExit.Text = "Exit";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // lblCkear
            // 
            this.lblCkear.AutoSize = true;
            this.lblCkear.BackColor = System.Drawing.Color.Transparent;
            this.lblCkear.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.lblCkear.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCkear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblCkear.Location = new System.Drawing.Point(634, 276);
            this.lblCkear.Name = "lblCkear";
            this.lblCkear.Size = new System.Drawing.Size(98, 18);
            this.lblCkear.TabIndex = 3;
            this.lblCkear.Text = "Clear Fields";
            this.lblCkear.Click += new System.EventHandler(this.lblCkear_Click);
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Doodle_222257U.Properties.Resources.login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCkear);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.picBoxLogin);
            this.Controls.Add(this.picBoxPassword);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.White;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox picBoxPassword;
        private System.Windows.Forms.PictureBox picBoxLogin;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblCkear;
    }
}