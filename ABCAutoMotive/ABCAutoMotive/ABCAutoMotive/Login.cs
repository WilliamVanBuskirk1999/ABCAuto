using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace ABCAutoMotive
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginBLL logBl = new LoginBLL();

            if (logBl.LoginUser(txtUsername.Text, txtPassword.Text) == true)
            {
                if (chkRememberMe.Checked)
                {
                    Properties.Settings.Default.UserName = txtUsername.Text;
                    Properties.Settings.Default.Password = txtPassword.Text;
                    Properties.Settings.Default.RemPass = true;
                }
                else
                {
                    Properties.Settings.Default.UserName = txtUsername.Text;
                    Properties.Settings.Default.Password = string.Empty;
                    Properties.Settings.Default.RemPass = false;
                }
                Properties.Settings.Default.AccessLevel = logBl.GetAccessLevel(txtUsername.Text, txtPassword.Text);
                Properties.Settings.Default.Save();
                DialogResult = DialogResult.OK;

                
            }
            else
            {
                MessageBox.Show("Login failed, please try again");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsername.Text = Properties.Settings.Default.UserName;
            this.Text = Application.ProductName;
            chkRememberMe.Checked = Properties.Settings.Default.RemPass;

        }

        private void Login_Leave(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
