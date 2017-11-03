using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTClinic
{
    public partial class Login : Form
    {


        public Login()
        {
            InitializeComponent();
        }

        private void tbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If enter key pressed jump to password field
            if (e.KeyChar == (char)13)
            {
                tbPassword.Focus();
            }
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If enter key pressed - jump to perform login click
            if (e.KeyChar == (char)13)
            {
                btnLogin.PerformClick();
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text) || string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUsername.Focus();
                return;
            }

            //MessageBox.Show("Login Button was clicked!!!");

            try
            {
           
                PTClinicDataTableAdapters.UsersTableAdapter user = new PTClinicDataTableAdapters.UsersTableAdapter();
                PTClinicData.UsersDataTable dt = user.GetDataByUsernamePwd(tbUsername.Text, tbPassword.Text);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("You have successfully logged in.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // GO TO ADMIN WINDOW 
                }
                else
                {
                    MessageBox.Show("Your username or password is incorrect. Try again.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // Show Sign up form
            Signup signupForm = new Signup(this);
            signupForm.Show();

            // Hide login form
           // this.Hide();


        }

 
    }
}
