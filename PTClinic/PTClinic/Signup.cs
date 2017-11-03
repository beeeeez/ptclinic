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
using System.Configuration;

namespace PTClinic
{
    public partial class Signup : Form
    {
        private Form Login;

        public Signup(Form Login)
        {
            InitializeComponent();
            this.Login = Login;
            Login.Hide();

            panelError.Visible = false;
            this.Update();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // If sign up is successful close signup form and pass back to login
            //Login.Show();
            //this.Close();

            if (string.IsNullOrEmpty(tbFirstName.Text) || string.IsNullOrEmpty(tbLastName.Text) ||
                string.IsNullOrEmpty(tbPassword.Text) || string.IsNullOrEmpty(tbPasswordConfirm.Text) ||
                string.IsNullOrEmpty(tbUsername.Text) || string.IsNullOrEmpty(tbEmail.Text))
            {
                panelError.Visible = true;
                lblError.Text = "Please fill out all fields";
            }
            else if (Validation.IsValidUserLength(tbUsername.Text.Trim()) == false)
            {
                panelError.Visible = true;
                lblError.Text = "Username must be longer";
            }
            else if (Validation.IsValidEmail(tbEmail.Text) == false)
            {
                panelError.Visible = true;
                lblError.Text = "Enter a valid email";
            }
            else if (!tbPassword.Text.Trim().Equals(tbPasswordConfirm.Text.Trim()))
            {
                panelError.Visible = true;
                lblError.Text = "Passwords do not match";
            }
            else
            {
                panelError.Visible = false;
                lblError.Text = "";
            }



            OleDbConnection conn = new OleDbConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();

                PTClinicDataTableAdapters.UsersTableAdapter user = new PTClinicDataTableAdapters.UsersTableAdapter();
                PTClinicData.UsersDataTable dt = user.GetDataByUsername(tbUsername.Text.Trim());

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Sorry, That Username already exists.", "Username Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

                /**

                try
                {
                    PTClinicData.UsersDataTable dtNewUser = user.InsertNewUser(tbUsername, tbPassword);
                    // INSERT NEW USER


                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



                **/




                /** if (conn.State == ConnectionState.Open)
                 {
                     MessageBox.Show("CONNECTION OPENED!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }**/

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }



        }

    }
}
