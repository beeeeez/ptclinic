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
    public partial class FollowUpVisitForm : Form
    {
        private Form Admin;
        private Form Login;
        private Form PatientProfile;
        public int patientID;
        private string changeVisitType = "";
        private Boolean PSFS = false;

        public FollowUpVisitForm(string PatientID, string PatientName, string PatientVisitStatus, Boolean needPSFS, Form adminForm, Form Login, Form PatientProfile)
        {
            InitializeComponent();
            panelMessage.Visible = false;

            if (PatientVisitStatus.Equals("re-assessment"))
            {
                this.Text = "Re-assessment Visit Form";
                lblHeaderText.Text = "Patient Re-assessment Visit Information";
                lblVisitInformation.Text = "Patient Re-assessment Visit Information";
                btnAddFollowUp.Text = "Add Visit Info";
            }


            // Set Button Icons
            setButtonIcon();

            // Set Admin, Login, and PatientProfile forms to the ones passed in to FollowUpVisitForm
            this.Login = Login;
            this.Admin = adminForm;
            this.PatientProfile = PatientProfile;

            // Setting Patient ID to the Patient ID Label
            lblPID.Text = PatientID;

            // Set Patient Name to the patient name label
            lblPatientName.Text = PatientName;

            patientID = Convert.ToInt32(PatientID);

            // Create variable for a Patients initial Visit Information
            VisitInfo tempPatientVisit = new VisitInfo();

            using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
            {
                // Gather info about this patient via the patient ID (intPID) passed from the search and store it in a data reader
                using (var dataReaderPatientVisit = tempPatientVisit.FindOnePatientVisit(connection, patientID))
                {
                    while (dataReaderPatientVisit.Read())
                    {
                        // Take the appropriate fields from the datareader
                        // and put them in proper labels
                        tbDiagnosis.Text = dataReaderPatientVisit["diagnosis"].ToString();
                        tbPTGoals.Text = dataReaderPatientVisit["pt_goals"].ToString();
                    }
                }
            } // End of -- using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))

            // Getting Todays date
            // And setting the three date labels (todays, student, and provider) to it
            DateTime date = DateTime.Now;
            string shortDateStr = date.ToShortDateString();
            lblTodaysDate.Text = shortDateStr;
            lblStudentDate.Text = shortDateStr;
            lblProviderDate.Text = shortDateStr;

            // Show PSFS button if they need to fill it out, else show No Label

            if (needPSFS == true)
            {
                PSFS = true;
                lblPSFSNeeded.Text = "Yes";
            }
            else
            {
                lblPSFSNeeded.Text = "No";
            }


            // Fill Drop Downs
            FillSupervisedModalities();
            FillConstantAttendance();
            FillTherapeuticProcedures();
        }

        // Fill SupervisedModalities Function
        public void FillSupervisedModalities()
        {
            // Fills Evaluation list drop down list
            cbSupervisedModalities.Items.Insert(0, "Select One"); // Index 0
            cbSupervisedModalities.Items.Add("97010 hot/cold pack");
            cbSupervisedModalities.Items.Add("97012 Traction-mechanical");
            cbSupervisedModalities.Items.Add("GO 283 ES 97014 E Stim Unattended");
            cbSupervisedModalities.SelectedIndex = 0; 
        }

        // FillConstantAttendance Function
        public void FillConstantAttendance()
        {
            // Fills Constat Attendance list drop down list
            cbConstantAttendance.Items.Insert(0, "Select One"); // Index 0
            cbConstantAttendance.Items.Add("97032 E-Stim Manual - one or many areas");
            cbConstantAttendance.Items.Add("97033 Iontophroesis");
            cbConstantAttendance.Items.Add("97035 Ultrasound");
            cbConstantAttendance.Items.Add("97039 Low Level Laser");
            cbConstantAttendance.SelectedIndex = 0;
        }

        // FillTheraputicProcedures Function
        public void FillTherapeuticProcedures()
        {
            // Fills Theraputic Procedures list drop down list
            cbTherapeuticProcedures.Items.Insert(0, "Select One"); // Index 0
            cbTherapeuticProcedures.Items.Add("97110 Theraputic Ex");
            cbTherapeuticProcedures.Items.Add("97112 Neuromuscular Re-ed");
            cbTherapeuticProcedures.Items.Add("97116 Gait Training (includes stairs)");
            cbTherapeuticProcedures.Items.Add("97124 Massage");
            cbTherapeuticProcedures.Items.Add("97140 Manual Therapy one+regions");
            cbTherapeuticProcedures.Items.Add("97530 Theraputic Activities 1-1");
            cbTherapeuticProcedures.SelectedIndex = 0;
        }

        // Setting the Icons for Logout and Home Buttons
        private void setButtonIcon()
        {
            btnLogOut.Image = Image.FromFile("..\\..\\Resources\\ic_power_settings_new_white_24dp_1x.png");
            btnBackHome.Image = Image.FromFile("..\\..\\Resources\\ic_home_white_24dp_1x.png");
            btnBackToProfile.Image = Image.FromFile("..\\..\\Resources\\ic_arrow_back_white_24dp_1x.png");
        }

        // Home Button Click
        // Send back to Admin Page
        private void btnBackHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin.Show();
        }

        // Logout Button Click
        // Send back to Login Page
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.Show();
        }

        // Back to Profile button click
        // Send back to Profile page
        private void btnBackToProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientProfile.Show();
        }

        // Add Follow Up Information to DB
        private void btnAddFollowUp_Click(object sender, EventArgs e)
        {
            FollowUpVisitInfo newVisit = new FollowUpVisitInfo();

            newVisit.PatientID = patientID;
            newVisit.ProviderID = tbProviderID.Text;
            newVisit.PatientName = lblPatientName.Text;
            newVisit.Diagnosis = tbDiagnosis.Text;
            newVisit.PTGoals = tbPTGoals.Text;
            newVisit.Subjective = tbSubjective.Text;
            newVisit.Objective = tbObjective.Text;
            
            newVisit.SupervisedModalities = cbSupervisedModalities.Text;
            newVisit.ConstantAttendance = cbConstantAttendance.Text;
            newVisit.TherapeuticProcedures = cbTherapeuticProcedures.Text;
            newVisit.TherapeuticProcedures2 = tbTherapeuticProcedures2.Text;


            newVisit.Assessment = tbAssessment.Text;
            newVisit.Plan = tbPlan.Text;

            Nullable<bool> reassessment = null;
            if (rbReassessmentYes.Checked == true)
            {
                reassessment = true;
            }
            else if (rbReassessmentNo.Checked == true)
            {
                reassessment = false;
            }
            newVisit.Reassessment = reassessment;

            Nullable<bool> discharge = null;
            if (rbDischargeYes.Checked == true)
            {
                discharge = true;
            }
            else if (rbDischargeNo.Checked == true)
            {
                discharge = false;
            }
            newVisit.ReferForDischarge = discharge;

            newVisit.StudentProviderName = tbStudentProvider.Text;

            /* Student Signature Date */
            // Get Current Date String (Set as a Short Date Time)
            string shortStudentDateStr = lblStudentDate.Text;
            // And convert it back into a Date Time 
            DateTime shortStudentDate = Convert.ToDateTime(shortStudentDateStr);

            newVisit.StudentProviderNameDate = shortStudentDate;



            newVisit.ProviderName = tbProviderName.Text;

            /* Provider Signature Date */
            // Get Current Date String (Set as a Short Date Time)
            string shortProviderDateStr = lblProviderDate.Text;
            // And convert it back into a Date Time 
            DateTime shortProviderDate = Convert.ToDateTime(shortProviderDateStr);

            newVisit.VisitDate = shortProviderDate;

            // Get Current Date String (Set as a Short Date Time)
            string shortDateStr = lblTodaysDate.Text;
            // And convert it back into a Date Time 
            DateTime shortDateVisit = Convert.ToDateTime(shortDateStr);

            newVisit.VisitDate = shortDateVisit;

            // If statement to check if there are field erros

            // If an error in the information occurs
            if (newVisit.Feedback.Contains("Error:"))
            {
                // Display the error message inside the form feedback label
                lblFeedback.Text = newVisit.Feedback;
            }
            else // If there are no errors, continue to Caregiver Form
            {
                lblFeedback.Text = "";

                try
                {
                    int dbSuccess = newVisit.AddFollowUpVisit();

                    // If patient record was added successfully update the Patient Info table with their Visit Status
                    if (dbSuccess == 1)
                    {
                        //lblFeedback.Text = "Patient's Visit Information has been saved";

                        /* UPDATE PATIENTS VISIT STATUS HERE -- BASED ON IF THEY ARE DISCHARGED OR NEED REASSESSMENT */

                        if (reassessment == true)
                        {
                            changeVisitType = "re-assessment";
                        }
                        else if (discharge == true)
                        {
                            changeVisitType = "discharge";
                        }
                        else
                        {
                            changeVisitType = "follow up";
                        }

                        using (OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
                        {
                            PatientInfo changeVisitStatus = new PatientInfo();

                            try
                            {
                                int visitTypeSuccess = changeVisitStatus.UpdatePatientStatus(connection, patientID, changeVisitType);

                                if (visitTypeSuccess == 1)
                                {
                                    panelMessage.Visible = true;
                                    //lblFeedback.Text = "Patient's Visit Information has been saved";

                                    if (PSFS == true)
                                    {
                                        MessageBox.Show("Patient Information Saved.\n Please complete Patient Goals.");
                                        this.Hide();
                                        bool fromProfile = false;
                                        PatientGoalsForm temp = new PatientGoalsForm(patientID, fromProfile, Admin, Login, this);
                                        temp.Show();
                                    }
                                }
                                else
                                {
                                    lblFeedback.Text = "Patient's Visit Information was not saved";
                                }


                            }
                            catch (Exception ex)
                            {
                                lblFeedback.Text = ex.ToString();
                            }
                        }
                    }
                    else
                    {
                        lblFeedback.Text = "Patient's Visit Information was not saved";
                    }
                }
                catch (Exception ex)
                {
                    lblFeedback.Text = ex.ToString();
                }
            }
        }

        // Reset form back
        private void btnClear_Click(object sender, EventArgs e)
        {
            tbProviderID.Clear();
            tbSubjective.Clear();
            tbObjective.Clear();
            cbSupervisedModalities.SelectedIndex = 0;
            cbConstantAttendance.SelectedIndex = 0;
            cbTherapeuticProcedures.SelectedIndex = 0;
            tbTherapeuticProcedures2.Clear();
            tbAssessment.Clear();
            tbPlan.Clear();
            rbReassessmentYes.Checked = false;
            rbReassessmentNo.Checked = false;
            rbDischargeYes.Checked = false;
            rbDischargeNo.Checked = false;
            tbStudentProvider.Clear();
            tbProviderName.Clear();
        }
    }
}
