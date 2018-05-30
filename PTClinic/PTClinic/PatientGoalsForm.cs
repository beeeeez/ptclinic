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
        private string pName;
        private string activityOneScore;
        private string activityTwoScore;
        private string activityThreeScore;
        private int pID;
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        private bool updatedGoals;
        private bool refreshProfile;

        public PatientGoalsForm()
        {
            InitializeComponent();
        
        }

        public PatientGoalsForm(int patientID, string pName, bool fromProfile, Form Admin, Form Login, Form PatientProfile)
        {

            updatedGoals = false;
            refreshProfile = false;

            InitializeComponent();
            setButtonIcon();
            myTimer.Tick += new System.EventHandler(myTimer_Tick);

            pID = patientID;

            this.Admin = Admin;
            this.Login = Login;
            this.PatientProfile = PatientProfile;
            this.pName = pName;
            patientName = new PatientInfo();

            // If PT Goals form was openedd from Visit hide "Back to profile" button
            if (!fromProfile)
            {
                btnBackToProfile.Visible = false;
            }
            else
            {
                refreshProfile = true;
                btnBackToProfile.Visible = true;
            }

            FillInterpretedBy();

            /** Event Handlers For Group Boxes **/
            for (int i = 0; i < gbActivtyOneScore.Controls.Count; i++)
            {
                RadioButton rb = (RadioButton)gbActivtyOneScore.Controls[i];
                rb.CheckedChanged += new System.EventHandler(gbActivityOneScore_CheckChanged);
            }
            for (int j = 0; j < gbActivityTwoScore.Controls.Count; j++)
            {
                RadioButton rb = (RadioButton)gbActivityTwoScore.Controls[j];
                rb.CheckedChanged += new System.EventHandler(gbActivityTwoScore_CheckChanged);
            }
            for (int k = 0; k < gbActivityThreeScore.Controls.Count; k++)
            {
                RadioButton rb = (RadioButton)gbActivityThreeScore.Controls[k];
                rb.CheckedChanged += new System.EventHandler(gbActivityThreeScore_CheckChanged);
            }

            PatientGoals goals = new PatientGoals();

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


                // Gather info about this patient via the patient ID (patientID) passed from the profile
                using (var dataReaderGoals = goals.FindPatientGoals(connection, patientID))
                {
                    //if (dataReaderGoals.HasRows)
                    //{
                    //    // read data ? with else to do something if there are no rows?
                    //}

                    while (dataReaderGoals.Read())
                    {
                        // Take the appropriate fields from the datareader
                        // and put them in proper labels
                        goals.Activity_One = dataReaderGoals["activity1"].ToString();
                        goals.Activity_One_Score = dataReaderGoals["activity1_score"].ToString();
                        goals.Activity_Two = dataReaderGoals["activity2"].ToString();
                        goals.Activity_Two_Score = dataReaderGoals["activity2_score"].ToString();
                        goals.Activity_Three = dataReaderGoals["activity3"].ToString();
                        goals.Activity_Three_Score = dataReaderGoals["activity3_score"].ToString();
                        goals.Patient_Notes_Observations = dataReaderGoals["patient_notes_observations"].ToString();
                        goals.Activity_One_InterpretedBy = dataReaderGoals["activity1_interpretedby"].ToString();
                        goals.Activity_Two_InterpretedBy = dataReaderGoals["activity2_interpretedby"].ToString();
                        goals.Activity_Three_InterpretedBy = dataReaderGoals["activity3_interpretedby"].ToString();

                        tbActivityOne.Text = goals.Activity_One;
                        tbActivityTwo.Text = goals.Activity_Two;
                        tbActivityThree.Text = goals.Activity_Three;

                        // Loop through group box radio buttons to check if rb value equals whats returning from Datareader column
                        for (int i = 0; i < gbActivtyOneScore.Controls.Count; i++)
                        {
                            RadioButton rb = (RadioButton)gbActivtyOneScore.Controls[i];
                            if (rb.Text == goals.Activity_One_Score)
                            {
                                rb.Checked = true;
                            }
                        }

                        cbInterpBy1.SelectedItem = goals.Activity_One_InterpretedBy;

                        for (int j = 0; j < gbActivityTwoScore.Controls.Count; j++)
                        {
                            RadioButton rb = (RadioButton)gbActivityTwoScore.Controls[j];
                            if (rb.Text == goals.Activity_Two_Score)
                            {
                                rb.Checked = true;
                            }
                        }

                        cbInterpBy2.SelectedItem = goals.Activity_Two_InterpretedBy;

                        for (int k = 0; k < gbActivityThreeScore.Controls.Count; k++)
                        {
                            RadioButton rb = (RadioButton)gbActivityThreeScore.Controls[k];
                            if (rb.Text == goals.Activity_Three_Score)
                            {
                                rb.Checked = true;
                            }
                        }

                        cbInterpBy3.SelectedItem = goals.Activity_Three_InterpretedBy;

                        tbNotesObservations.Text = goals.Patient_Notes_Observations;
                       // MessageBox.Show("Activity One Score: " + goals.Activity_One_Score + " Activity Two Score: " + goals.Activity_Two_Score + " Activity Three Score: " + goals.Activity_Three_Score);

                    }
                }

            } // end using()

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
            }
        }

        private void gbActivityTwoScore_CheckChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton rb = (RadioButton)sender;
                activityTwoScore = rb.Text;
            }
        }

        private void gbActivityThreeScore_CheckChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton rb = (RadioButton)sender;
                activityThreeScore = rb.Text;
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
            // If patient goals were updated create new profile form
            if (updatedGoals == true || refreshProfile == true)
            {
                //  public PatientProfile(int intPID, Form adminForm, Form Login, Form search, Form PatientInfo, bool isNewRecord
                Search newSearchForm = new Search(Admin, Login);
                PatientInformation newPatientForm = new PatientInformation(0, Admin, Login);
                PatientProfile refreshProfile = new PatientProfile(pID, Admin, Login, newSearchForm, newPatientForm, false);
                refreshProfile.Show();
            }
            else
            {
                PatientProfile.Show();
            }
            this.Hide();

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
            tbNotesObservations.Clear();


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

            cbInterpBy1.SelectedIndex = 0;
            cbInterpBy2.SelectedIndex = 0;
            cbInterpBy3.SelectedIndex = 0;

        }

        public void FillInterpretedBy()
        {
            cbInterpBy1.Items.Insert(0, "Choose");
            cbInterpBy1.Items.Add("Patient");
            cbInterpBy1.Items.Add("Caregiver");
            cbInterpBy1.Items.Add("Provider");
            cbInterpBy1.SelectedIndex = 0;

            cbInterpBy2.Items.Insert(0, "Choose");
            cbInterpBy2.Items.Add("Patient");
            cbInterpBy2.Items.Add("Caregiver");
            cbInterpBy2.Items.Add("Provider");
            cbInterpBy2.SelectedIndex = 0;

            cbInterpBy3.Items.Insert(0, "Choose");
            cbInterpBy3.Items.Add("Patient");
            cbInterpBy3.Items.Add("Caregiver");
            cbInterpBy3.Items.Add("Provider");
            cbInterpBy3.SelectedIndex = 0;
        }

        private void btnSavePTGoals_Click(object sender, EventArgs e)
        {
            PatientGoals newPatientGoals = new PatientGoals();
            newPatientGoals.PatientID = pID;
            newPatientGoals.Activity_One = tbActivityOne.Text;
            newPatientGoals.Activity_One_Score = activityOneScore;
            newPatientGoals.Activity_Two = tbActivityTwo.Text;
            if (string.IsNullOrEmpty(activityTwoScore))
            {
                newPatientGoals.Activity_Two_Score = "";
            }
            else
            {
                newPatientGoals.Activity_Two_Score = activityTwoScore;
            }
            newPatientGoals.Activity_Three = tbActivityThree.Text;
            if (string.IsNullOrEmpty(activityThreeScore))
            {
                newPatientGoals.Activity_Three_Score = "";
            }
            else
            {
                newPatientGoals.Activity_Three_Score = activityThreeScore;
            }
            newPatientGoals.Patient_Notes_Observations = tbNotesObservations.Text;
            newPatientGoals.Activity_One_InterpretedBy = cbInterpBy1.Text;
            newPatientGoals.Activity_Two_InterpretedBy = cbInterpBy2.Text;
            newPatientGoals.Activity_Three_InterpretedBy = cbInterpBy3.Text;

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
                        updatedGoals = true;
                        myTimer.Interval = 5000;
                        myTimer.Start();
                        panelDBMessage.Visible = true;
                        lblDBFeedback.Text = "Patient Goals Saved";
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
                        lblDBFeedback.Text = "Patient Goals NOT Saved";

                    }

                } // end using()

            }

        }

        private void button1_Click(object sender, EventArgs e)//this goes to the search patient goals page
        {
            ViewPastGoals pastGoals = new ViewPastGoals(pID, pName, Admin, Login, PatientProfile, this);
            pastGoals.Show();
            this.Hide();
        }
    }
}
