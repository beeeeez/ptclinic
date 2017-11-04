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

            panelError.BackColor = Color.Red;
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
                panelError.BackColor = Color.Red;
                panelError.Visible = true;
                lblError.Text = "Please fill out all fields";
            }
            else if (Validation.IsValidUserLength(tbUsername.Text.Trim()) == false)
            {
                panelError.BackColor = Color.Red;
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
                panelError.BackColor = Color.Red;
                panelError.Visible = true;
                lblError.Text = "Passwords do not match";
            }
            else
            {
                panelError.BackColor = Color.Red;
                panelError.Visible = false;
                lblError.Text = "";



                //OleDbConnection connection = new OleDbConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = PTClinic.accdb; Persist Security Info = False; ");


                try
                {
                    connection.Open();

                    PTClinicDataTableAdapters.UsersTableAdapter user = new PTClinicDataTableAdapters.UsersTableAdapter();
                    PTClinicData.UsersDataTable dt = user.GetDataByUsername(tbUsername.Text.Trim());
                   

                    if (dt.Rows.Count > 0)
                    {
                       /** string username = dt[1].first_name.ToString();
                        if (username.ToLower().Equals(tbUsername.Text.Trim().ToLower()))
                        {
                            MessageBox.Show("Sorry, That Username already exists.", "Username Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    **/
                        MessageBox.Show("Sorry, That Username already exists.", "Username Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      
                    }
                    else
                    {
                        string insertStatement = "INSERT INTO `Users` (`username`, `password`, `salt`, `first_name`, `last_name`, `email`, `date_created`) VALUES (@username, @password, @salt, @first_name, @last_name, @email, @date_created)";


                        OleDbCommand comm = new OleDbCommand();
                        comm.CommandText = insertStatement; // Commander knows what to say
                        comm.Connection = connection; // Heres the connection

                        // Get Current SHORT dATE
                        DateTime date = DateTime.Now;
                        string shortDateStr = date.ToShortDateString();
                        DateTime shortDate = Convert.ToDateTime(shortDateStr);

                        comm.Parameters.AddWithValue("@username", tbUsername.Text.Trim());
                        comm.Parameters.AddWithValue("@password", tbPassword.Text.Trim());
                        comm.Parameters.AddWithValue("@salt", "salt");
                        comm.Parameters.AddWithValue("@first_name", tbFirstName.Text.Trim());
                        comm.Parameters.AddWithValue("@last_name", tbLastName.Text.Trim());
                        comm.Parameters.AddWithValue("@email", tbEmail.Text.Trim());
                        comm.Parameters.AddWithValue("@date_created", shortDate);


                        try
                        {
                          //  connection.Open();
                            // ADD NEW USER
                            comm.ExecuteNonQuery();

                        }
                        catch (Exception err)
                        {
                            MessageBox.Show(err.ToString(), "Database Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        panelError.BackColor = Color.FromArgb(0, 192, 0);
                        panelError.Visible = true;
                        lblError.Text = "User successfully added";
                        /**
                        finally
                        {
                           // connection.Close();
                            MessageBox.Show("Added statement", "Database!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        } **/

                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                    MessageBox.Show("Connection has been closed!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }

            }




        }

    }
}
