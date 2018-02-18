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
        private string patientVisitStatus;
        private Boolean PSFS = false;
        bool visitSaved;
        StringBuilder followupVisitString;
        StringBuilder ptDiagnosisLists; 
        private string diagnosisStr;
        private string ptGoalStr;
        private string ptDiagnosisStr;

        public FollowUpVisitForm(string PatientID, string PatientName, string PatientVisitStatus, Boolean needPSFS, Form adminForm, Form Login, Form PatientProfile)
        {
            InitializeComponent();
            panelMessage.Visible = false;

            patientVisitStatus = PatientVisitStatus;
            visitSaved = false;


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

            // Fill Drop Downs
            FillSupervisedModalities();
            FillConstantAttendance();
            FillTherapeuticProcedures();

            if (PatientVisitStatus.Equals("re-assessment") || PatientVisitStatus.Equals("re-assessment pending"))
            {
                this.Text = "Re-assessment Visit Form";
                lblHeaderText.Text = "Patient Re-assessment Visit Information";
                lblVisitInformation.Text = "Patient Re-assessment Visit Information";
                btnAddFollowUp.Text = "Add Visit Info";
            }



            PatientInfo tempPatient = new PatientInfo();
            using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
            {
                // Gather info about this patient via the patient ID (intPID) passed from the search and store it in a data reader
                using (var dataReaderPatient = tempPatient.FindOnePatient(connection, patientID))
                {
                    while (dataReaderPatient.Read())
                    {
                        // Take the appropriate fields from the datareader
                        // and put them in proper labels

                        tbDiagnosis.Text = dataReaderPatient["medicalhistory_diagnosis"].ToString();
                        diagnosisStr = dataReaderPatient["medicalhistory_diagnosis"].ToString();

                    }
                }
            }

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
                        tbProviderID.Text = dataReaderPatientVisit["provider_id"].ToString();

                        tbPTGoals.Text = dataReaderPatientVisit["pt_goals"].ToString();
                        ptGoalStr = dataReaderPatientVisit["pt_goals"].ToString();

                        var ptDiagnosis = dataReaderPatientVisit["pt_diagnosis"].ToString();

                        char[] splitChar = { '+' };
                        string[] diagnosisArray = null;
                        StringBuilder sb = new StringBuilder();

                        diagnosisArray = ptDiagnosis.Split(splitChar);

                        /** Create acronym for print ability -- currently to long
Impaired Joint Mobility, Motor Function, Muscle Performance, and Range of motion Associated with Connective Tissue Dysfunction
Impaired Joint Mobility, Motor Function, Muscle Performance, and Range of motion Associated with Localized Inflammation
Impaired Joint Mobility, Motor Function, Muscle Performance, and Range of motion Associated with and Reflex Integrity associated with Spinal Disorders
Impaired Posture
Primary Prevention/Risk Reduction for Skeletal Demineralization
Primary Prevention/Risk Reduction for Loss of Balance and Falling
Impaired Motor Function and Sensory Integrity Associated with Nonprogressive Disorders of the Central Nervous System - Congenital Origin or Acquired in Infancy or Childhood
Impaired Motor Function and Sensory Integrity Associated with Nonprogressive Disorders of the Central Nervous System - Acquired in Adolescence or Adulthood
Impaired Motor Function and Sensory Integrity Associated with Progressive Disorders of the Central Nervous System
Impaired Peripheral Nerve Integrity and Muscle Performance Associated with Peripheral Nerve Injury
Impaired Motor Function and Sensory Integrity Associated with Acute or Chronic Poly Neuropathies
Primary Prevention/Risk Reduction for Cardiovascular/Pulmonary Disorders
Impaired Aerobic Capacity/Endurance Associated with Deconditioning
Impaired Aerobic Capacity/Endurance Associated with Cardiovascular Pump Dysfunction or Failure
                        **/

                        for (int i = 0; i < diagnosisArray.Length; i++)
                        {
                            sb.AppendLine("- " + diagnosisArray[i]);
           
                        }

                        tbPTDiagnosis.Text = sb.ToString();
                        ptDiagnosisStr = sb.ToString();
                    }
                }
            } // End of -- using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))

            // Populate form with data, if Patients visit status shows the follow up pending completion
            // Else just populate the three fields with data from the initial form
            if (PatientVisitStatus.Equals("follow up pending"))
            {
                // Create variable for a Patients initial Visit Information
                FollowUpVisitInfo tempPatientFUVisit = new FollowUpVisitInfo();

                using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
                {
                    // Gather info about this patient via the patient ID (intPID) passed from the search and store it in a data reader
                    using (var dataReaderPatientFUVisit = tempPatientFUVisit.FindOnePatientFUVisit(connection, patientID))
                    {
                        while (dataReaderPatientFUVisit.Read())
                        {
                            // Take the appropriate fields from the datareader
                            // and put them in proper text boxes / selections
                            tbProviderID.Text = dataReaderPatientFUVisit["provider_id"].ToString();
                            DateTime dos = Convert.ToDateTime(dataReaderPatientFUVisit["visit_date"].ToString());
                            dtpDateOfService.Value = dos;
                          
                            tbSubjective.Text = dataReaderPatientFUVisit["subjective"].ToString();
                            tbObjective.Text = dataReaderPatientFUVisit["objective"].ToString();
                            tbAssessment.Text = dataReaderPatientFUVisit["assessment"].ToString();
                            tbPlan.Text = dataReaderPatientFUVisit["plan"].ToString();
                            tbStudentProvider.Text = dataReaderPatientFUVisit["student_name"].ToString();
                            tbProviderName.Text = dataReaderPatientFUVisit["provider_name"].ToString();
                   

                            //Drop downs
                            cbTherapeuticProcedures.SelectedItem = dataReaderPatientFUVisit["therapeutic_procedures"].ToString();
                            cbSupervisedModalities.SelectedItem = dataReaderPatientFUVisit["supervised_modalities"].ToString();
                            cbConstantAttendance.SelectedItem = dataReaderPatientFUVisit["constant_attendance"].ToString();
                        }
                    }
                } // End of -- using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
            }

            // Getting Todays date
            // And setting the three date labels (todays, student, and provider) to it
            DateTime date = DateTime.Now;
            string shortDateStr = date.ToShortDateString();
            lblTodaysDate.Text = shortDateStr;
            lblStudentDate.Text = shortDateStr;
            lblProviderDate.Text = shortDateStr;
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
            cbTherapeuticProcedures.Items.Add("97110 Theraputic Ex Units - 1");
            cbTherapeuticProcedures.Items.Add("97110 Theraputic Ex Units - 2");
            cbTherapeuticProcedures.Items.Add("97110 Theraputic Ex Units - 3");
            cbTherapeuticProcedures.Items.Add("97110 Theraputic Ex Units - 4");
            cbTherapeuticProcedures.Items.Add("97112 Neuromuscular Re-ed Units - 1");
            cbTherapeuticProcedures.Items.Add("97112 Neuromuscular Re-ed Units - 2");
            cbTherapeuticProcedures.Items.Add("97112 Neuromuscular Re-ed Units - 3");
            cbTherapeuticProcedures.Items.Add("97112 Neuromuscular Re-ed Units - 4");
            cbTherapeuticProcedures.Items.Add("97113 Aquatic Therapy w ther ex Units - 1");
            cbTherapeuticProcedures.Items.Add("97113 Aquatic Therapy w ther ex Units - 2");
            cbTherapeuticProcedures.Items.Add("97113 Aquatic Therapy w ther ex Units - 3");
            cbTherapeuticProcedures.Items.Add("97113 Aquatic Therapy w ther ex Units - 4");
            cbTherapeuticProcedures.Items.Add("97116 Gait Training (includes stairs) Units - 1");
            cbTherapeuticProcedures.Items.Add("97116 Gait Training (includes stairs) Units - 2");
            cbTherapeuticProcedures.Items.Add("97116 Gait Training (includes stairs) Units - 3");
            cbTherapeuticProcedures.Items.Add("97116 Gait Training (includes stairs) Units - 4");
            cbTherapeuticProcedures.Items.Add("97124 Massage Units - 1");
            cbTherapeuticProcedures.Items.Add("97124 Massage Units - 2");
            cbTherapeuticProcedures.Items.Add("97124 Massage Units - 3");
            cbTherapeuticProcedures.Items.Add("97124 Massage Units - 4");
            cbTherapeuticProcedures.Items.Add("97140 Manual Therapy one+regions Units - 1");
            cbTherapeuticProcedures.Items.Add("97140 Manual Therapy one+regions Units - 2");
            cbTherapeuticProcedures.Items.Add("97140 Manual Therapy one+regions Units - 3");
            cbTherapeuticProcedures.Items.Add("97140 Manual Therapy one+regions Units - 4");
            cbTherapeuticProcedures.Items.Add("97530 Theraputic Activities 1-1 Units - 1");
            cbTherapeuticProcedures.Items.Add("97530 Theraputic Activities 1-1 Units - 2");
            cbTherapeuticProcedures.Items.Add("97530 Theraputic Activities 1-1 Units - 3");
            cbTherapeuticProcedures.Items.Add("97530 Theraputic Activities 1-1 Units - 4");
            cbTherapeuticProcedures.SelectedIndex = 0;
        }

        // Setting the Icons for Logout and Home Buttons
        private void setButtonIcon()
        {
            btnLogOut.Image = Image.FromFile("..\\..\\Resources\\ic_power_settings_new_white_24dp_1x.png");
            btnBackHome.Image = Image.FromFile("..\\..\\Resources\\ic_home_white_24dp_1x.png");
            btnBackToProfile.Image = Image.FromFile("..\\..\\Resources\\ic_arrow_back_white_24dp_1x.png");
            btnBackToSearch.Image = Image.FromFile("..\\..\\Resources\\ic_arrow_back_white_24dp_1x.png");
            btnPrintVisitDetails.Image = Image.FromFile("..\\..\\Resources\\ic_print_white_24dp_1x.png");
        }

        // Home Button Click
        // Send back to Admin Page
        private void btnBackHome_Click(object sender, EventArgs e)
        {
            if (visitSaved == true)
            {
                this.Hide();
                Admin.Show();
            }
            else
            {
                if (patientVisitStatus.Equals("follow up"))
                {
                    AddFollowUpVisit();
                }
                else if (patientVisitStatus.Equals("follow up pending"))
                {
                    UpdateFollowUpVisit();
                }

          
                this.Hide();
                Admin.Show();
            }
   
        }

        // Logout Button Click
        // Send back to Login Page
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (visitSaved == true)
            {
                this.Hide();
                Login.Show();
            }
            else
            {
                if (patientVisitStatus.Equals("follow up"))
                {
                    AddFollowUpVisit();
                }
                else if (patientVisitStatus.Equals("follow up pending"))
                {
                    UpdateFollowUpVisit();
                }

                this.Hide();
                Login.Show();
            }
        }

        // Back to Profile button click
        // Send back to Profile page
        private void btnBackToProfile_Click(object sender, EventArgs e)
        {
            // If patient goals were updated create new profile form
            if (visitSaved == true)
            {
                this.Hide();
                //  public PatientProfile(int intPID, Form adminForm, Form Login, Form search, Form PatientInfo, bool isNewRecord
                Search newSearchForm = new Search(Admin, Login);
                PatientInformation newPatientForm = new PatientInformation(0, Admin, Login);
                PatientProfile refreshProfile = new PatientProfile(patientID, Admin, Login, newSearchForm, newPatientForm, false);
                refreshProfile.Show();
            }
            else
            {
        
                if (patientVisitStatus.Equals("follow up"))
                {
                    AddFollowUpVisit();
                    this.Hide();
                    //  public PatientProfile(int intPID, Form adminForm, Form Login, Form search, Form PatientInfo, bool isNewRecord
                    Search newSearchForm = new Search(Admin, Login);
                    PatientInformation newPatientForm = new PatientInformation(0, Admin, Login);
                    PatientProfile refreshProfile = new PatientProfile(patientID, Admin, Login, newSearchForm, newPatientForm, false);
                    refreshProfile.Show();
                }
                else if(patientVisitStatus.Equals("follow up pending"))
                {
                    UpdateFollowUpVisit();
                    this.Hide();
                    PatientProfile.Show();
                }
            }

        }

        // Add Follow Up Information to DB
        private void btnAddFollowUp_Click(object sender, EventArgs e)
        {

            if (cbCompleted.Checked == true)
            {
                if (patientVisitStatus.Equals("follow up"))
                {
                    AddFollowUpVisit();

                    btnAddFollowUp.Visible = false;
                    btnPrintVisitDetails.Visible = true;
                }
                else if (patientVisitStatus.Equals("follow up pending"))
                {
                    UpdateFollowUpVisit();
      
                    btnAddFollowUp.Visible = false;
                    btnPrintVisitDetails.Visible = true;
                }

            }
            else
            {
                MessageBox.Show("To finalize form make sure you check off:\n\n - 'Is the form Complete' checkbox", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

           
        }

        // Reset form back
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void FollowUpVisitForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {

                if (visitSaved == false)
                {
                    DialogResult dResult = MessageBox.Show("You are about to exit the application!\n\nWould you like to save everything?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dResult == DialogResult.OK)
                    {
                        if (patientVisitStatus.Equals("follow up"))
                        {
                            AddFollowUpVisit();
                        }
                        else
                        {
                            UpdateFollowUpVisit();
                        }
                    }
                }
        
            }
        }

        private void clearForm()
        {
            tbProviderID.Clear();
            tbSubjective.Clear();
            tbObjective.Clear();
            tbAssessment.Clear();
            tbPlan.Clear();

            cbSupervisedModalities.SelectedIndex = 0;
            cbConstantAttendance.SelectedIndex = 0;
            cbTherapeuticProcedures.SelectedIndex = 0;

            tbStudentProvider.Clear();
            tbProviderName.Clear();
        }

        private void AddFollowUpVisit()
        {
            followupVisitString = new StringBuilder();

            FollowUpVisitInfo newVisit = new FollowUpVisitInfo();

            newVisit.PatientID = patientID;

            followupVisitString.AppendLine("Visit Date: " + dtpDateOfService.Value.ToShortDateString());
            followupVisitString.AppendLine("Patient ID: " + patientID);

            newVisit.ProviderID = tbProviderID.Text;

            followupVisitString.AppendLine("Provider ID: " + tbProviderID.Text);

            newVisit.PatientName = lblPatientName.Text;

            followupVisitString.AppendLine("Patient Name: " + lblPatientName.Text);
            followupVisitString.AppendLine("Diagnosis:\n " + breakUpString(diagnosisStr));
            followupVisitString.AppendLine("PT Goals: \n" + breakUpString(ptGoalStr));
            followupVisitString.AppendLine("PT Diagnosis: \n" + ptDiagnosisLists);

            newVisit.Subjective = tbSubjective.Text;

            followupVisitString.AppendLine("Subjective: \n" + breakUpString(tbSubjective.Text) + "\n");

            newVisit.Objective = tbObjective.Text;

            followupVisitString.AppendLine("Objective: \n" + breakUpString(tbObjective.Text) + "\n");

            newVisit.SupervisedModalities = cbSupervisedModalities.Text;

            followupVisitString.AppendLine("Supervised Modalities - " + cbSupervisedModalities.Text);

            newVisit.ConstantAttendance = cbConstantAttendance.Text;
            followupVisitString.AppendLine("Constant Attendance - " + cbConstantAttendance.Text);
            newVisit.TherapeuticProcedures = cbTherapeuticProcedures.Text;
            followupVisitString.AppendLine("Therapeutic Procedures - " + cbTherapeuticProcedures.Text + "\n");
           
            newVisit.Assessment = tbAssessment.Text;
            followupVisitString.AppendLine("Assessment: \n" + breakUpString(tbAssessment.Text));

            newVisit.Plan = tbPlan.Text;
            followupVisitString.AppendLine("Plan: \n" + breakUpString(tbPlan.Text));

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
            string shortDateStr = dtpDateOfService.Value.ToShortDateString();
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
                       

                        using (OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
                        {
                            PatientInfo changeVisitStatus = new PatientInfo();

                            /* UPDATE PATIENTS VISIT STATUS HERE -- BASED ON IF THEY COMPLETED THE FORM AND ARE DISCHARGED OR NEED REASSESSMENT */
                            if (cbCompleted.Checked == true)
                            {
                                changeVisitType = "follow up";
                            }
                            else
                            {
                                changeVisitType = "follow up pending";
                            }

                            try
                            {
                                int visitTypeSuccess = changeVisitStatus.UpdatePatientStatus(connection, patientID, changeVisitType);

                                if (visitTypeSuccess == 1)
                                {
                                    panelMessage.Visible = true;
                                    visitSaved = true;
                                    //lblFeedback.Text = "Patient's Visit Information has been saved";

                                    // clearForm();
                           
                                }
                                else
                                {
                                    lblFeedback.Text = "Patient's Visit Status was not changed";
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


        private void UpdateFollowUpVisit()
        {
            //FollowUpVisitInfo newVisit = new FollowUpVisitInfo();

            //newVisit.PatientID = patientID;
            //newVisit.ProviderID = tbProviderID.Text;
            //newVisit.PatientName = lblPatientName.Text;
            //newVisit.Subjective = tbSubjective.Text;
            //newVisit.Objective = tbObjective.Text;

            //newVisit.SupervisedModalities = cbSupervisedModalities.Text;
            //newVisit.ConstantAttendance = cbConstantAttendance.Text;
            //newVisit.TherapeuticProcedures = cbTherapeuticProcedures.Text;

            //newVisit.Assessment = tbAssessment.Text;
            //newVisit.Plan = tbPlan.Text;


            followupVisitString = new StringBuilder();

            FollowUpVisitInfo newVisit = new FollowUpVisitInfo();

            newVisit.PatientID = patientID;

            followupVisitString.AppendLine("Visit Date: " + dtpDateOfService.Value.ToShortDateString());
            followupVisitString.AppendLine("Patient ID: " + patientID);

            newVisit.ProviderID = tbProviderID.Text;

            followupVisitString.AppendLine("Provider ID: " + tbProviderID.Text);

            newVisit.PatientName = lblPatientName.Text;

            followupVisitString.AppendLine("Patient Name: " + lblPatientName.Text);
            followupVisitString.AppendLine("Diagnosis:\n " + breakUpString(diagnosisStr));
            followupVisitString.AppendLine("PT Goals: \n" + breakUpString(ptGoalStr));
            followupVisitString.AppendLine("PT Diagnosis: \n" + breakUpString(ptDiagnosisStr));

            newVisit.Subjective = tbSubjective.Text;

            followupVisitString.AppendLine("Subjective: \n" + breakUpString(tbSubjective.Text) + "\n");

            newVisit.Objective = tbObjective.Text;

            followupVisitString.AppendLine("Objective: \n" + breakUpString(tbObjective.Text) + "\n");

            newVisit.SupervisedModalities = cbSupervisedModalities.Text;

            followupVisitString.AppendLine("Supervised Modalities - " + cbSupervisedModalities.Text);

            newVisit.ConstantAttendance = cbConstantAttendance.Text;
            followupVisitString.AppendLine("Constant Attendance - " + cbConstantAttendance.Text);
            newVisit.TherapeuticProcedures = cbTherapeuticProcedures.Text;
            followupVisitString.AppendLine("Therapeutic Procedures - " + cbTherapeuticProcedures.Text + "\n");

            newVisit.Assessment = tbAssessment.Text;
            followupVisitString.AppendLine("Assessment: \n" + breakUpString(tbAssessment.Text));

            newVisit.Plan = tbPlan.Text;
            followupVisitString.AppendLine("Plan: \n" + breakUpString(tbPlan.Text));

            newVisit.StudentProviderName = tbStudentProvider.Text;

            /* Student Signature Date */
            // Get Current Date String (Set as a Short Date Time)
            string shortDateOfServiceStr = lblStudentDate.Text;
            // And convert it back into a Date Time 
            DateTime shortDate = Convert.ToDateTime(shortDateOfServiceStr);

            newVisit.StudentProviderNameDate = shortDate;

           // MessageBox.Show(shortDate.ToShortDateString());



            newVisit.ProviderName = tbProviderName.Text;

            /* Provider Signature Date */
            // Get Current Date String (Set as a Short Date Time)
            string shortProviderDateStr = lblProviderDate.Text;
            // And convert it back into a Date Time 
            DateTime shortProviderDate = Convert.ToDateTime(shortProviderDateStr);

            newVisit.VisitDate = shortProviderDate;

            // Get Current Date String (Set as a Short Date Time)
            string shortDateStr = dtpDateOfService.Value.ToShortDateString();
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
                    int dbSuccess = newVisit.UpdateOneFUVisit();

                    // If patient follow up visit was updated successfully... update the Patient Info table with their Visit Status
                    if (dbSuccess == 1)
                    {
                        //lblFeedback.Text = "Patient's Visit Information has been saved";

                        using (OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
                        {
                            PatientInfo changeVisitStatus = new PatientInfo();

                            if (cbCompleted.Checked == true)
                            {
                                changeVisitType = "follow up";
                            }
                            else
                            {
                                changeVisitType = "follow up pending";
                            }

                            try
                            {
                                int visitTypeSuccess = changeVisitStatus.UpdatePatientStatus(connection, patientID, changeVisitType);

                                if (visitTypeSuccess == 1)
                                {
                                    panelMessage.Visible = true;
                                    visitSaved = true;

                                    clearForm();
                           
                                }
                                else
                                {
                                    lblFeedback.Text = "Patient's Visit Status was not changed";
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

        private void btnBackToSearch_Click(object sender, EventArgs e)
        {
            Search search = new Search(Admin, Login);
           // If visit information was completed + saved 
            if (visitSaved == true)
            {
                this.Hide();
                search.Show();
            }
            else
            {

                if (patientVisitStatus.Equals("follow up"))
                {
                    AddFollowUpVisit();
                }
                else
                {
                    UpdateFollowUpVisit();
                }
                this.Hide();
                search.Show();
            }
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            using (Font font1 = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Point))
            {

                Rectangle rect1 = new Rectangle(100, 100, 650, 25);
                StringFormat SF = new StringFormat();
                SF.Alignment = StringAlignment.Center;
                SF.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString("Follow Up Visit Overview", font1, Brushes.Black, rect1, SF);
                e.Graphics.DrawRectangle(Pens.Black, rect1);
            }

            e.Graphics.DrawString(followupVisitString.ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new PointF(100, 160));

        }

        private void btnPrintVisitDetails_Click(object sender, EventArgs e)
        {
           
            //printDialog.Document = printDocument;
            //if (printDialog.ShowDialog() == DialogResult.OK)
            //{
            //    printDocument.Print();
            //}


            // !!! To view print layout uncomment this

            if (printPreviewDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }

        }

        public static string breakUpString(string s)
        {
            StringBuilder result = new StringBuilder();

            while (s.Length > 70)
            {
                if (Char.IsWhiteSpace(s[69]) || Char.IsWhiteSpace(s[70]) ||
                    s[69] == '-' || s[70] == '-')
                {
                    result.AppendLine(s.Substring(0, 70));
                }
                else
                {
                    result.AppendLine(s.Substring(0, 70) + "-");
                }

                s = s.Substring(70);

            }

            result.AppendLine(s);

            return result.ToString();
        }

    }
}
