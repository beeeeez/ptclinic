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
        private string activityOneScore;
        private string activityTwoScore;
        private string activityThreeScore;

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


            for (int i = 0; i < gbActivtyOneScore.Controls.Count; i++)
            {
                RadioButton rb = (RadioButton)gbActivtyOneScore.Controls[i];
                rb.CheckedChanged += new System.EventHandler(gbActivityOneScore_CheckChanged);
            }
            for (int i = 0; i < gbActivityTwoScore.Controls.Count; i++)
            {
                RadioButton rb = (RadioButton)gbActivityTwoScore.Controls[i];
                rb.CheckedChanged += new System.EventHandler(gbActivityTwoScore_CheckChanged);
            }
            for (int i = 0; i < gbActivityThreeScore.Controls.Count; i++)
            {
                RadioButton rb = (RadioButton)gbActivityThreeScore.Controls[i];
                rb.CheckedChanged += new System.EventHandler(gbActivityThreeScore_CheckChanged);
            }
        }


        private void gbActivityOneScore_CheckChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton rb = (RadioButton)sender;
                activityOneScore = rb.Text;
                //MessageBox.Show(activityOneScore);
            }
        }

        private void gbActivityTwoScore_CheckChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton rb = (RadioButton)sender;
                activityTwoScore = rb.Text;
                //MessageBox.Show(rb.Text);
            }
        }

        private void gbActivityThreeScore_CheckChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton rb = (RadioButton)sender;
                activityThreeScore = rb.Text;
                //MessageBox.Show(rb.Text);
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
            // MessageBox.Show("Button Clciked");
            PatientGoals newPatientGoals = new PatientGoals();
            newPatientGoals.Activity_One = tbActivityOne.Text;
            newPatientGoals.Activity_One_Score = activityOneScore;
            newPatientGoals.Activity_Two = tbActivityTwo.Text;
            newPatientGoals.Activity_Two_Score = activityTwoScore;
            newPatientGoals.Activity_Three = tbActivityThree.Text;
            newPatientGoals.Activity_Three_Score = activityThreeScore;
            newPatientGoals.Patient_Goals = tbPatientTreatmentGoals.Text;

            /** TODO
             * 
             * Add validation to patient goals class to check if activity two and three have
            * any text in their respected textboxes to validate that the score for each one is also selected
            * prior to saving to DB
            * 
            * 
            */


            //MessageBox.Show("Activity One Score: " + activityOneScore);
            //MessageBox.Show("Activity Two Score: " + activityTwoScore);
            //MessageBox.Show("Activity Three Score: " + activityThreeScore);
        }
    }
}
