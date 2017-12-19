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
    public partial class VisitForm : Form
    {
        // Variables for the admin and login forms
        private Form Admin;
        private Form Login;
        private Form PatientProfile;
        public int patientID;


        public VisitForm(string PatientID, Form adminForm, Form Login, Form PatientProfile)
        {
            InitializeComponent();

            setButtonIcon();

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

            // Set the Patient Name here~~~
            /* Get Patient Name Passing Over! */

            // Fill Drop Downs
            FillEvaluation();
            FillConstantAttendance();
            FillTheraputicProcedures();
           
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
        public void FillTheraputicProcedures()
        {
            // Fills Theraputic Procedures list drop down list
            cbTheraputicProcedures.Items.Insert(0, "Select One"); // Index 0
            cbTheraputicProcedures.Items.Add("97110 Theraputic Ex");
            cbTheraputicProcedures.Items.Add("97112 Neuromuscular Re-ed");
            cbTheraputicProcedures.Items.Add("97113 Aquatic Therapy w ther ex");
            cbTheraputicProcedures.Items.Add("97116 Gait Training (includes stairs)");
            cbTheraputicProcedures.Items.Add("97124 Massage");
            cbTheraputicProcedures.Items.Add("97140 Manual Therapy one+regions");
            cbTheraputicProcedures.Items.Add("97530 Theraputic Activities 1-1");
            cbTheraputicProcedures.SelectedIndex = 0;
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

            newVisit.PatientID = Convert.ToInt32(lblPID.Text);
            newVisit.ProviderID = tbProviderID.Text;

            // Get Current Date String (Set as a Short Date Time)
            string shortDateStr = lblDate.Text;
            // And convert it back into a Date Time 
            DateTime shortDateVisit = Convert.ToDateTime(shortDateStr);

            newVisit.VisitDate = shortDateVisit;
            newVisit.ChiefComplaint = tbChiefComplaint.Text;
            newVisit.Diagnosis = tbDiagnosis.Text;

            newVisit.MedicalHistory = tbMedicalHistory.Text;
            newVisit.Medications = tbMedications.Text;
            newVisit.Subjective = tbSubjective.Text;
            newVisit.Objective = tbObjective.Text;
            newVisit.PTGoals = tbPTGoals.Text;
            newVisit.TreatmentPlan = tbTreatmentPlan.Text;
            newVisit.Evaluation = cbEvaluation.Text;
            newVisit.ConstantAttendance = cbConstantAttendance.Text;

            newVisit.TheraputicProcedures = cbTheraputicProcedures.Text;
            newVisit.TheraputicProcedures2 = tbTheraputicProcedures2.Text;
            newVisit.FunctionalLimitations = tbFunctionalLimitations.Text;
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

                    // If patient record was added successfully get patient id from that insert
                    if (dbSuccess == 1)
                    {
                        lblFeedback.Text = "Patient's Visit Information has been saved";
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
            PatientProfile.Show();
        }

        // Clear Form Button Click
        // Reset form to original selections / blank text boxes
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear Text Boxes
            tbChiefComplaint.Clear();
            tbDiagnosis.Clear();
            tbFollowUpTreatment.Clear();
            tbFunctionalLimitations.Clear();
            tbMedicalHistory.Clear();
            tbMedications.Clear();
            tbObjective.Clear();
            tbProviderID.Clear();
            tbPTDiagnosis.Clear();
            tbPTGoals.Clear();
            tbSubjective.Clear();
            tbTreatmentPlan.Clear();

            // Set ComboBoxes to index 0 (Select One)
            cbConstantAttendance.SelectedIndex = 0;
            cbEvaluation.SelectedIndex = 0;
            cbTheraputicProcedures.SelectedIndex = 0;
        }
    }
}
