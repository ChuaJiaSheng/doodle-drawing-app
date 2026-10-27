using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doodle_222257U
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "debian" && txtPassword.Text == "temppwd")
            {
                this.Hide();

                MainForm_222257U frm = new MainForm_222257U();
                frm.Show();
            }
            else if (txtUsername.Text != "debian" || txtPassword.Text != "temppwd")
            {
                MessageBox.Show("The username or password entered is incorrect. Please try again.");
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }
        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void lblCkear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(btnLogin, EventArgs.Empty);
            }
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }
    }
}

