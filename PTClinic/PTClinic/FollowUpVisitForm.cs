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
    public partial class FollowUpVisitForm : Form
    {
        private Form Admin;
        private Form Login;
        private Form PatientProfile;
        public int patientID;

        public FollowUpVisitForm()
        {
            InitializeComponent();
            // Set Button Icons
            setButtonIcon();

            // Set Admin, Login, and PatientProfile forms to the ones passed in to FollowUpVisitForm

            /*
             * 
             * Set Patient ID
             * Patient Name
             * Diagnosis
             * And
             * PT Goals
             * 
             * They should all be passed over from the patient info form
             * 
             * 
             */

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
            // TODO -- functionality
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
