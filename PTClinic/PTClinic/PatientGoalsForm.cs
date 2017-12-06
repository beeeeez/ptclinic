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
    public partial class PatientGoalsForm : Form
    {
        private Form Login;
        private Form Admin;
        private Form PatientProfile;

        public PatientGoalsForm()
        {
            InitializeComponent();
        }

        public PatientGoalsForm(int patientID, bool fromProfile, Form Admin, Form Login, Form PatientProfile)
        {
            InitializeComponent();
            setButtonIcon();

            this.Admin = Admin;
            this.Login = Login;
            this.PatientProfile = PatientProfile;

            // If PT Goals form was openedd from Visit hide "Back to profile" button
            if (!fromProfile)
            {
                btnBackToProfile.Visible = false;
            }
            else
            {
                btnBackToProfile.Visible = true;
            }
        }

        // Setting the Icons for Logout and Home Buttons
        private void setButtonIcon()
        {
            btnLogOut.Image = Image.FromFile("..\\..\\Resources\\ic_power_settings_new_white_24dp_1x.png");
            btnBackHome.Image = Image.FromFile("..\\..\\Resources\\ic_home_white_24dp_1x.png");
            btnBackToProfile.Image = Image.FromFile("..\\..\\Resources\\ic_arrow_back_white_24dp_1x.png");
        }

        private void btnBackToProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientProfile.Show();
        }

        private void btnBackHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.Show();
        }
    }
}
