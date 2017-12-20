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
        private int pID;
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        public PatientGoalsForm()
        {
            InitializeComponent();
        }

        public PatientGoalsForm(int patientID, bool fromProfile, Form Admin, Form Login, Form PatientProfile)
        {
            InitializeComponent();
            setButtonIcon();
            myTimer.Tick += new System.EventHandler(myTimer_Tick);

            pID = patientID;

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

            PatientGoals goals = new PatientGoals();

            //using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
            //{
            //    // Gather info about this patient via the patient ID (patientID) passed from the profile
            //    using (var dataReaderGoals = goals.FindPatientGoals(connection, patientID))
            //    {
            //        if (dataReaderGoals.HasRows)
            //        {
            //            // read data ? with else to do something if there are no rows?
            //        }

            //        while (dataReaderGoals.Read())
            //        {
            //            // Take the appropriate fields from the datareader
            //            // and put them in proper labels
            //            goals.Activity_One = dataReaderGoals[""].ToString();
            //            goals.Activity_One = dataReaderGoals[""].ToString();
            //            goals.Activity_One = dataReaderGoals[""].ToString();
            //            goals.Activity_One = dataReaderGoals[""].ToString();
            //            goals.Activity_One = dataReaderGoals[""].ToString();
            //            goals.Activity_One = dataReaderGoals[""].ToString();
            //            goals.Activity_One = dataReaderGoals[""].ToString();

            //        }
            //    }
            //}


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

        private void myTimer_Tick(object sender, System.EventArgs e)
        {
            panelDBMessage.Visible = false;
            myTimer.Stop();
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

        private void clearFields()
        {
            tbActivityOne.Clear();
            tbActivityTwo.Clear();
            tbActivityThree.Clear();
            tbPatientTreatmentGoals.Clear();


            for (int i = 0; i < gbActivtyOneScore.Controls.Count; i++)
            {
                RadioButton rb = (RadioButton)gbActivtyOneScore.Controls[i];
                rb.Checked = false;
            }
            for (int j = 0; j < gbActivityTwoScore.Controls.Count; j++)
            {
                RadioButton rb = (RadioButton)gbActivityTwoScore.Controls[j];
                rb.Checked = false;
            }
            for (int k = 0; k < gbActivityThreeScore.Controls.Count; k++)
            {
                RadioButton rb = (RadioButton)gbActivityThreeScore.Controls[k];
                rb.Checked = false;
            }
        }

        private void btnSavePTGoals_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Button Clciked");
            PatientGoals newPatientGoals = new PatientGoals();
            newPatientGoals.PatientID = pID;
            newPatientGoals.Activity_One = tbActivityOne.Text;
            newPatientGoals.Activity_One_Score = activityOneScore;
            newPatientGoals.Activity_Two = tbActivityTwo.Text;
            newPatientGoals.Activity_Two_Score = activityTwoScore;
            newPatientGoals.Activity_Three = tbActivityThree.Text;
            newPatientGoals.Activity_Three_Score = activityThreeScore;
            newPatientGoals.Patient_Goals = tbPatientTreatmentGoals.Text;

            // If an error in the information occurs
            if (newPatientGoals.Feedback.Contains("Error:"))
            {
                // Display the error message inside the form feedback label
                lblFeedback.Text = newPatientGoals.Feedback;
            }
            else // If there are no errors, continue to Caregiver Form
            {
                lblFeedback.Text = "";

                using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
                {
                    int dbSuccess = 0;

                    dbSuccess = int.Parse(newPatientGoals.AddRecord(connection));

                    if (dbSuccess == 1)
                    {
                        lblFeedback.Text = "Patient Goals Saved";
                        myTimer.Interval = 5000;
                        myTimer.Start();
                        panelDBMessage.Visible = true;
                        lblDBFeedback.Text = "Patient Goals Saved!";
                        // Clear all feilds
                        clearFields();
                    }
                    else
                    {
                        lblFeedback.Text = "Oops! There was a problem saving Patient Goals\n Try again";
                        myTimer.Interval = 5000;
                        myTimer.Start();
                        panelDBMessage.BackColor = Color.Red;
                        panelDBMessage.Visible = true;
                        lblDBFeedback.Text = "Patient Goals NOT Saved!";
                    }

                } // end using()

            }

        }
    }
}
