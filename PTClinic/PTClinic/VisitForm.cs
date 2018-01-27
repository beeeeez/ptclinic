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
    public partial class VisitForm : Form
    {
        // Variables for the admin and login forms
        private Form Admin;
        private Form Login;
        private Form PatientProfile;
        public int patientID;
        private string changeVisitType;
        private string patientStatus;
        bool visitSaved;


        public VisitForm(string PatientID, string PatientName, Form adminForm, Form Login, Form PatientProfile)
        {
            InitializeComponent();

            setButtonIcon();
            panelMessage.Visible = false;

            visitSaved = false;
            patientStatus = "";

            this.Login = Login;
            this.Admin = adminForm;
            this.PatientProfile = PatientProfile;

            // Getting Todays date
            // And setting the date label to it
            DateTime date = DateTime.Now;
            string shortDateStr = date.ToShortDateString();
            lblDate.Text = shortDateStr;

            // Set the PatientID
            lblPID.Text = PatientID;

            // set the private patientID int variable to the patients ID for use in the add patient section
            patientID = Convert.ToInt32(PatientID);

            // Set the Patient Name
            lblPatientName.Text = "Patient Name: " + PatientName;

            // Fill Drop Downs
            FillEvaluation();
            FillConstantAttendance();
            FillTherapeuticProcedures();

            PatientInfo tempPatient = new PatientInfo();
            VisitInfo tempVisitInfo = new VisitInfo();
            using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
            {
                // Gather info about this patient via the patient ID (intPID) passed from the search and store it in a data reader
                using (var dataReaderPatient = tempPatient.FindOnePatient(connection, patientID))
                {
                    while (dataReaderPatient.Read())
                    {
                        // Take the appropriate fields from the datareader
                        // and put them in proper labels

                        patientStatus = dataReaderPatient["patient_status"].ToString();
                    }
                }


                MessageBox.Show(patientStatus);

                if (patientStatus == "visit pending")
                {
                    MessageBox.Show("POPULATE FORM FIELDS FOR UPDATE");


                    // Gather info about this patient via the patient ID (intPID) passed from the search and store it in a data reader
                    using (var dataReaderVisit = tempVisitInfo.FindOnePatientVisit(connection, patientID))
                    {
                        while (dataReaderVisit.Read())
                        {
                            // Take the appropriate fields from the datareader
                            // and put them in proper labels

                            // patient_id, provider_id, visit_date, chief_complaint, diagnosis, medical_history, durable_medical_equipment, 
                            // medications, subjective, objective, pt_goals, treatment_plan, dme_needs, evaluation, constant_attendance,
                            // therapeutic_procedures, therapeutic_procedures2, functional_limitations, assessment, pt_diagnosis, followup_treatment 

                            tbProviderID.Text = dataReaderVisit["provider_id"].ToString();


                            tbChiefComplaint.Text = dataReaderVisit["chief_complaint"].ToString();
                            tbDiagnosis.Text = dataReaderVisit["diagnosis"].ToString();
                            tbMedicalHistory.Text = dataReaderVisit["medical_history"].ToString();
                            tbDME.Text = dataReaderVisit["durable_medical_equipment"].ToString();

                            tbMedications.Text = dataReaderVisit["medications"].ToString();
                            tbSubjective.Text = dataReaderVisit["subjective"].ToString();
                            tbObjective.Text = dataReaderVisit["objective"].ToString();
                            tbPTGoals.Text = dataReaderVisit["pt_goals"].ToString();
                            tbTreatmentPlan.Text = dataReaderVisit["treatment_plan"].ToString();
                            tbDMENeeds.Text = dataReaderVisit["dme_needs"].ToString();

                            var evaluation = dataReaderVisit["evaluation"].ToString();

                            if (String.IsNullOrEmpty(evaluation) || evaluation.Equals(""))
                            {
                                cbEvaluation.SelectedItem = "Select One";
                            }
                            else
                            {
                                cbEvaluation.SelectedItem = dataReaderVisit["evaluation"].ToString();
                            }

                            var constAttendance = dataReaderVisit["constant_attendance"].ToString();

                            if (String.IsNullOrEmpty(constAttendance) || constAttendance.Equals(""))
                            {
                                cbConstantAttendance.SelectedItem = "Select One";
                            }
                            else
                            {
                                cbConstantAttendance.SelectedItem = dataReaderVisit["constant_attendance"].ToString();
                            }

                            var therapeuticProcedures = dataReaderVisit["therapeutic_procedures"].ToString();

                            if (String.IsNullOrEmpty(therapeuticProcedures) || therapeuticProcedures.Equals(""))
                            {
                                cbTherapeuticProcedures.SelectedItem = "Select One";
                            }
                            else
                            {
                                cbTherapeuticProcedures.SelectedItem = dataReaderVisit["therapeutic_procedures"].ToString();
                            }

                            tbTherapeuticProcedures2.Text = dataReaderVisit["therapeutic_procedures2"].ToString();
                            tbFunctionalLimitations.Text = dataReaderVisit["functional_limitations"].ToString();
                            tbAssessment.Text = dataReaderVisit["assessment"].ToString();

                            // CHECKLISTBOX 
                            tbPTDiagnosis.Text = dataReaderVisit["pt_diagnosis"].ToString();

                            tbFollowUpTreatment.Text = dataReaderVisit["followup_treatment"].ToString();

                        }
                    }

                } // END using (findOneVisit)


               
            }

         

        }

        // FillEvaluation Function
        public void FillEvaluation()
        {
            // Fills Evaluation list drop down list
            cbEvaluation.Items.Insert(0, "Select One"); // Index 0
            cbEvaluation.Items.Add("97161 20min Low");
            cbEvaluation.Items.Add("97162 30min Moderate");
            cbEvaluation.Items.Add("97163 40min High");
            cbEvaluation.Items.Add("97164 20-30min");
            cbEvaluation.SelectedIndex = 0;
        }

        // FillConstantAttendance Function
        public void FillConstantAttendance()
        {
            // Fills Constat Attendance list drop down list
            cbConstantAttendance.Items.Insert(0, "Select One"); // Index 0
            cbConstantAttendance.Items.Add("97032 E-stim manual - one or many areas");
            cbConstantAttendance.Items.Add("97033 Iontophroesis");
            cbConstantAttendance.Items.Add("97034 Contrastbath");
            cbConstantAttendance.Items.Add("97035 Ultrasound");
            cbConstantAttendance.Items.Add("97036 Hubbard tank");
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
            cbTherapeuticProcedures.Items.Add("97113 Aquatic Therapy w ther ex");
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

        // Add Visit Button Click
        // Add Visit Information to DB
        private void btnAddVisit_Click(object sender, EventArgs e)
        {
            VisitInfo newVisit = new VisitInfo();

            newVisit.PatientID = patientID;
            newVisit.ProviderID = tbProviderID.Text;

            // Get Current Date String (Set as a Short Date Time)
            string shortDateStr = lblDate.Text;
            // And convert it back into a Date Time 
            DateTime shortDateVisit = Convert.ToDateTime(shortDateStr);

            newVisit.VisitDate = shortDateVisit;
            newVisit.ChiefComplaint = tbChiefComplaint.Text;
            newVisit.Diagnosis = tbDiagnosis.Text;

            newVisit.MedicalHistory = tbMedicalHistory.Text;
            newVisit.DurableMedicalEquipment = tbDME.Text;
            newVisit.Medications = tbMedications.Text;
            newVisit.Subjective = tbSubjective.Text;
            newVisit.Objective = tbObjective.Text;
            newVisit.PTGoals = tbPTGoals.Text;
            newVisit.TreatmentPlan = tbTreatmentPlan.Text;
            newVisit.DMENeeds = tbDMENeeds.Text;
            newVisit.Evaluation = cbEvaluation.Text;
            newVisit.ConstantAttendance = cbConstantAttendance.Text;

            newVisit.TherapeuticProcedures = cbTherapeuticProcedures.Text;
            newVisit.TherapeuticProcedures2 = tbTherapeuticProcedures2.Text;
            newVisit.FunctionalLimitations = tbFunctionalLimitations.Text;
            newVisit.Assessment = tbAssessment.Text;
            newVisit.PhysicalTherapyDiagnosis = tbPTDiagnosis.Text;

            newVisit.FollowUpTreatment = tbFollowUpTreatment.Text;

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
                    //lblFeedback.Text = newPatient.AddRecord();
                    int dbSuccess = newVisit.AddVisit();

                    // If patient record was added successfully update Patient Info with their new Visit Status
                    if (dbSuccess == 1)
                    {
                        //lblFeedback.Text = "Patient's Visit Information has been saved";

                        /* UPDATE PATIENTS VISIT TYPE INFO HERE*/
                        using (OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
                        {
                            PatientInfo changeVisitStatus = new PatientInfo();

                            changeVisitType = "follow up";

                            try
                            {
                                int visitTypeSuccess = changeVisitStatus.UpdatePatientStatus(connection, patientID, changeVisitType);

                                if (visitTypeSuccess == 1)
                                {
                                    panelMessage.Visible = true;
                                    visitSaved = true;
                                    clearForm();
                                    //lblFeedback.Text = "Patient's Visit Information has been saved";
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

        // Back Home Button Click
        // Send to Admin Page
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

            // If patient goals were updated create new profile form
            if (visitSaved == true)
            {
                //  public PatientProfile(int intPID, Form adminForm, Form Login, Form search, Form PatientInfo, bool isNewRecord
                Search newSearchForm = new Search(Admin, Login);
                PatientInformation newPatientForm = new PatientInformation(0, Admin, Login);
                PatientProfile refreshProfile = new PatientProfile(patientID, Admin, Login, newSearchForm, newPatientForm, false);
                refreshProfile.Show();
            }
            else
            {
                PatientProfile.Show();
            }

        }

        // Clear Form Button Click
        // Reset form to original selections / blank text boxes
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void clearForm()
        {
            // Clear Text Boxes
            tbChiefComplaint.Clear();
            tbDiagnosis.Clear();
            tbFollowUpTreatment.Clear();
            tbFunctionalLimitations.Clear();
            tbMedicalHistory.Clear();
            tbDME.Clear();
            tbMedications.Clear();
            tbObjective.Clear();
            tbProviderID.Clear();
            tbPTDiagnosis.Clear();
            tbPTGoals.Clear();
            tbSubjective.Clear();
            tbTreatmentPlan.Clear();
            tbDMENeeds.Clear();
            tbAssessment.Clear();

            // Set ComboBoxes to index 0 (Select One)
            cbConstantAttendance.SelectedIndex = 0;
            cbEvaluation.SelectedIndex = 0;
            cbTherapeuticProcedures.SelectedIndex = 0;
        }

        private void VisitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dResult = MessageBox.Show("Would you like to save everything?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dResult == DialogResult.OK)
                {
                    MessageBox.Show("YOU DON SAVED IT ALL! CONGRATS");
                }
            }
        }

        public void SaveVisitInfo()
        {
            VisitInfo newVisit = new VisitInfo();

            newVisit.PatientID = patientID;
            newVisit.ProviderID = tbProviderID.Text;

            // Get Current Date String (Set as a Short Date Time)
            string shortDateStr = lblDate.Text;
            // And convert it back into a Date Time 
            DateTime shortDateVisit = Convert.ToDateTime(shortDateStr);

            newVisit.VisitDate = shortDateVisit;
            newVisit.ChiefComplaint = tbChiefComplaint.Text;
            newVisit.Diagnosis = tbDiagnosis.Text;

            newVisit.MedicalHistory = tbMedicalHistory.Text;
            newVisit.DurableMedicalEquipment = tbDME.Text;
            newVisit.Medications = tbMedications.Text;
            newVisit.Subjective = tbSubjective.Text;
            newVisit.Objective = tbObjective.Text;
            newVisit.PTGoals = tbPTGoals.Text;
            newVisit.TreatmentPlan = tbTreatmentPlan.Text;
            newVisit.DMENeeds = tbDMENeeds.Text;
            newVisit.Evaluation = cbEvaluation.Text;
            newVisit.ConstantAttendance = cbConstantAttendance.Text;

            newVisit.TherapeuticProcedures = cbTherapeuticProcedures.Text;
            newVisit.TherapeuticProcedures2 = tbTherapeuticProcedures2.Text;
            newVisit.FunctionalLimitations = tbFunctionalLimitations.Text;
            newVisit.Assessment = tbAssessment.Text;
            newVisit.PhysicalTherapyDiagnosis = tbPTDiagnosis.Text;

            newVisit.FollowUpTreatment = tbFollowUpTreatment.Text;

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
                    //lblFeedback.Text = newPatient.AddRecord();
                    int dbSuccess = newVisit.AddVisit();

                    // If patient record was added successfully update Patient Info with their new Visit Status
                    if (dbSuccess == 1)
                    {
                        //lblFeedback.Text = "Patient's Visit Information has been saved";

                        /* UPDATE PATIENTS VISIT TYPE INFO HERE*/
                        using (OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
                        {
                            PatientInfo changeVisitStatus = new PatientInfo();

                            if (cbCompletedForm.Checked == true)
                            {
                                changeVisitType = "follow up";
                            }
                            else
                            {
                                changeVisitType = "visit pending";
                            }

                            try
                            {
                                int visitTypeSuccess = changeVisitStatus.UpdatePatientStatus(connection, patientID, changeVisitType);

                                if (visitTypeSuccess == 1)
                                {
                                    panelMessage.Visible = true;
                                    visitSaved = true;
                                    clearForm();
                                    //lblFeedback.Text = "Patient's Visit Information has been saved";
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

        public void UpdateVisitInfo()
        {
            VisitInfo newVisit = new VisitInfo();

            newVisit.PatientID = patientID;
            newVisit.ProviderID = tbProviderID.Text;

            // Get Current Date String (Set as a Short Date Time)
            string shortDateStr = lblDate.Text;
            // And convert it back into a Date Time 
            DateTime shortDateVisit = Convert.ToDateTime(shortDateStr);

            newVisit.VisitDate = shortDateVisit;
            newVisit.ChiefComplaint = tbChiefComplaint.Text;
            newVisit.Diagnosis = tbDiagnosis.Text;

            newVisit.MedicalHistory = tbMedicalHistory.Text;
            newVisit.DurableMedicalEquipment = tbDME.Text;
            newVisit.Medications = tbMedications.Text;
            newVisit.Subjective = tbSubjective.Text;
            newVisit.Objective = tbObjective.Text;
            newVisit.PTGoals = tbPTGoals.Text;
            newVisit.TreatmentPlan = tbTreatmentPlan.Text;
            newVisit.DMENeeds = tbDMENeeds.Text;
            newVisit.Evaluation = cbEvaluation.Text;
            newVisit.ConstantAttendance = cbConstantAttendance.Text;

            newVisit.TherapeuticProcedures = cbTherapeuticProcedures.Text;
            newVisit.TherapeuticProcedures2 = tbTherapeuticProcedures2.Text;
            newVisit.FunctionalLimitations = tbFunctionalLimitations.Text;
            newVisit.Assessment = tbAssessment.Text;
            newVisit.PhysicalTherapyDiagnosis = tbPTDiagnosis.Text;

            newVisit.FollowUpTreatment = tbFollowUpTreatment.Text;

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
                    //lblFeedback.Text = newPatient.AddRecord();
                    int dbSuccess = newVisit.UpdateVisit();

                    // If patient record was added successfully update Patient Info with their new Visit Status
                    if (dbSuccess == 1)
                    {
                        //lblFeedback.Text = "Patient's Visit Information has been saved";

                        /* UPDATE PATIENTS VISIT TYPE INFO HERE*/
                        using (OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
                        {
                            PatientInfo changeVisitStatus = new PatientInfo();

                            if (cbCompletedForm.Checked == true)
                            {
                                changeVisitType = "follow up";
                            }
                            else
                            {
                                changeVisitType = "visit pending";
                            }

                            try
                            {
                                int visitTypeSuccess = changeVisitStatus.UpdatePatientStatus(connection, patientID, changeVisitType);

                                if (visitTypeSuccess == 1)
                                {
                                    panelMessage.Visible = true;
                                    visitSaved = true;
                                    clearForm();
                                    //lblFeedback.Text = "Patient's Visit Information has been saved";
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
    }
}
