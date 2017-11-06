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
    public partial class Admin : Form
    {
        private Form Login;
        public string adminFirstName { get; set; }
        public string adminUsername { get; set; }

        public Admin(Form Login, string username, string firstName)
        {
            InitializeComponent();

            this.Login = Login;
            this.adminUsername = username;
            this.adminFirstName = firstName;
            Login.Hide();

            // Set Logged In User Welcome
            lblUsername.Text = firstName;

            setButtonIcon();

            // Mouse Enter events for cards
            this.pbBtnNewPatient.MouseEnter += new EventHandler(pbBtnNewPatient_MouseEnter);
            this.pbBtnVisit.MouseEnter += new EventHandler(pbBtnVisit_MouseEnter);
            this.pbBtnNewPatient.MouseLeave += new EventHandler(pbBtnNewPatient_MouseLeave);
            this.pbBtnVisit.MouseLeave += new EventHandler(pbBtnVisit_MouseLeave);

            /*
             *   TODO WORK ON FORM CLOSING EVENT HANDLER
             *   */
            //this.FormClosing += new FormClosingEventHandler();


        }

        private void setButtonIcon()
        {
            btnLogOut.Image = Image.FromFile("..\\..\\Resources\\ic_power_settings_new_white_24dp_1x.png");
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            Login.Show();
        }

        private void pbBtnNewPatient_Click(object sender, EventArgs e)
        {
            // ON CLICK GO TO NEW PATIENT FORM
            PatientInformation patientForm = new PatientInformation(this, Login);

            patientForm.Show();

        }

        private void pbBtnVisit_Click(object sender, EventArgs e)
        {
            // ON CLICK GO TO PATIENT VISIT FORM
        }


        private void pbBtnNewPatient_MouseEnter(object sender, EventArgs e)
        {
            // ADD BORDER
            pbBtnNewPatient.BorderStyle = BorderStyle.FixedSingle;

        }

        private void pbBtnVisit_MouseEnter(object sender, EventArgs e)
        {
            // ADD BORDER
            pbBtnVisit.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pbBtnNewPatient_MouseLeave(object sender, EventArgs e)
        {
            // REMOVE BORDER
            pbBtnNewPatient.BorderStyle = BorderStyle.None;

        }

        private void pbBtnVisit_MouseLeave(object sender, EventArgs e)
        {
            // REMOVE BORDER
            pbBtnVisit.BorderStyle = BorderStyle.None;
        }

        private void Admin_FormClosing(object sender, FormClosingEventHandler e)
        {

            if (MessageBox.Show("Are you sure you want to exit program?", "Confirm Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                MessageBox.Show("LEAVING");
            }
            else
            {
                MessageBox.Show("STAY IN APP");
            }

        }
    }
}
