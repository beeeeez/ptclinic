using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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

            panelError.Visible = false;
            this.Update();
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
                //MessageBox.Show("Please enter both username and password.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                panelError.Visible = true;
                lblError.Text = "Please enter both username and password.";
                tbUsername.Focus();
                return;
            }


            // OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;");



            using (OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
            {

                string getUserSQL = "SELECT [user_id], [username], [first_name] FROM Users WHERE ([username] = @username AND [password] = @password)";
                OleDbCommand comm = new OleDbCommand();
                comm.CommandText = getUserSQL; // Commander knows what to say
                comm.Connection = connection; // Heres the connection

                comm.Parameters.AddWithValue("@username", tbUsername.Text);
                comm.Parameters.AddWithValue("@password", tbPassword.Text);

                try
                {
                    connection.Open();
                    OleDbDataReader dr = comm.ExecuteReader();

                    if (dr.Read())
                    {
                        panelError.Visible = false;
                        string username = dr["username"].ToString();
                        string firstName = dr["first_name"].ToString();

                       // MessageBox.Show(" First Name = " + dr["first_name"].ToString(), "DB RETURNED", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // GO TO ADMIN WINDOW 
                        Admin adminForm = new Admin(this, username, firstName);
                   
                        adminForm.Show();

                        tbUsername.Text = "";
                        tbPassword.Text = "";
                    }
                    else
                    {
                        panelError.Visible = true;
                        lblError.Text = "Sorry, the Username or Password you entered is invalid.";
                    }

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Display DB Connection error to user 


                }
                finally
                {
                    connection.Close();
                    //MessageBox.Show("Connection closed");
                }
            }


            /**

            try
            {
           
                PTClinicDataTableAdapters.UsersTableAdapter user = new PTClinicDataTableAdapters.UsersTableAdapter();
                PTClinicData.UsersDataTable dt = user.GetDataByUsernamePwd(tbUsername.Text, tbPassword.Text);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("You have successfully logged in.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // GO TO ADMIN WINDOW 
                    Admin adminForm = new Admin(this);
                    adminForm.Show();
                  

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


    **/
        }


        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // Show Sign up form
            Signup signupForm = new Signup(this);
            signupForm.Show();
        }


    }
}
