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

            // To format image to fit picturebox
            //pictureBoxSignup.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // If sign up is successful close signup form and pass back to login
            Login.Show();
            this.Close();

            OleDbConnection conn = new OleDbConnection(ConfigurationManager.AppSettings["ConnectionString"]);

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    MessageBox.Show("CONNECTION OPENED!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
    }
}
