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
    public partial class PatientGoalsForm : Form
    {
        private Form Login;
        private Form Admin;
        private Form PatientProfile;
        PatientInfo patientName;

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

            patientName = new PatientInfo();

            // If PT Goals form was openedd from Visit hide "Back to profile" button
            if (!fromProfile)
            {
                btnBackToProfile.Visible = false;
            }
            else
            {
                btnBackToProfile.Visible = true;
            }


            using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
            {
                // Gather info about this patient via the patient ID (intPID) passed from the search and store it in a data reader
                using (var dataReaderPatient = patientName.FindOnePatient(connection, patientID))
                {
                    while (dataReaderPatient.Read())
                    {
                        // Take the appropriate fields from the datareader
                        // and put them in proper labels

                        patientName.Fname = dataReaderPatient["patient_first_name"].ToString();
                        patientName.Lname = dataReaderPatient["patient_last_name"].ToString();


                        lblPatientName.Text = "For " + patientName.Fname + " " + patientName.Lname;

                    }
                }
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

        private void btnSavePTGoals_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button Clciked");
        }
    }
}
