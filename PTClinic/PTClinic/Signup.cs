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
    public partial class Signup : Form
    {
        private Form Login;

        public Signup(Form Login)
        {
            InitializeComponent();
            this.Login = Login;
            Login.Hide();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // If sign up is successful close signup form and pass back to login
            Login.Show();
            this.Close();
        }
    }
}
