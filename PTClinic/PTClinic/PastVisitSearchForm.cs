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
    public partial class PastVisitSearchForm : Form
    {

        private int patientId;
        private Form Admin;
        private Form Login;

        public PastVisitSearchForm(int patientId, Form Admin, Form Login)
        {

            InitializeComponent();

            setButtonIcon();

            this.patientId = patientId;
            this.Admin = Admin;
            this.Login = Login;

            string id = patientId.ToString();
            MessageBox.Show("Patient id is " + id);
            lblPatientId.Text = "Patient id is " + id;


        }

        // Setting the Icons for Logout and Home Buttons
        private void setButtonIcon()
        {
            btnLogOut.Image = Image.FromFile("..\\..\\Resources\\ic_power_settings_new_white_24dp_1x.png");
            btnBackHome.Image = Image.FromFile("..\\..\\Resources\\ic_home_white_24dp_1x.png");
            btnBackToProfile.Image = Image.FromFile("..\\..\\Resources\\ic_arrow_back_white_24dp_1x.png");
        }

        private void btnViewFollowUp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Go to follow up view only form");
        }

        private void btnBackToProfile_Click(object sender, EventArgs e)
        {
            Search newSearchForm = new Search(Admin, Login);
            PatientInformation newPatientForm = new PatientInformation(0, Admin, Login);
            PatientProfile newProfile = new PatientProfile(patientId, Admin, Login, newSearchForm, newPatientForm, false);
            this.Hide();
            newProfile.Show();

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
