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
            string shortDateStr = date.ToLongDateString();
            lblDate.Text = shortDateStr;

            // Fill Drop Downs
            FillEvaluation();
            FillConstantAttendance();
            FillTheraputicProcedures();
            FillTheraputicProcedures2();
        }

        // FillEvaluation Function
        public void FillEvaluation()
        {
            // Fills Evaluation list drop down list
            cbEvaluation.Items.Insert(0, "Select One"); // Index 0
            /*
             * GET DROP DOWN INFORMATION
             * AND ADD IT HERE
             * 
             * */
            cbEvaluation.SelectedIndex = 0;
        }

        // FillConstantAttendance Function
        public void FillConstantAttendance()
        {
            // Fills Constat Attendance list drop down list
            cbConstantAttendance.Items.Insert(0, "Select One"); // Index 0
            /*
             * GET DROP DOWN INFORMATION
             * AND ADD IT HERE
             * 
             * */
            cbConstantAttendance.SelectedIndex = 0;
        }

        // FillTheraputicProcedures Function
        public void FillTheraputicProcedures()
        {
            // Fills Theraputic Procedures list drop down list
            cbTheraputicProcedures.Items.Insert(0, "Select One"); // Index 0
            /*
             * GET DROP DOWN INFORMATION
             * AND ADD IT HERE
             * 
             * */
            cbTheraputicProcedures.SelectedIndex = 0;
        }

        // FillTheraputicProcedures2 Function
        public void FillTheraputicProcedures2()
        {
            // Fills Theraputic Procedures2 list drop down list
            cbTheraputicProcedures2.Items.Insert(0, "Select One"); // Index 0
            /*
             * GET DROP DOWN INFORMATION
             * AND ADD IT HERE
             * 
             * */
            cbTheraputicProcedures2.SelectedIndex = 0;
        }

        // Setting the Icons for Logout and Home Buttons
        private void setButtonIcon()
        {
            btnLogOut.Image = Image.FromFile("..\\..\\Resources\\ic_power_settings_new_white_24dp_1x.png");
            btnBackHome.Image = Image.FromFile("..\\..\\Resources\\ic_home_white_24dp_1x.png");
        }

        // Add Visit Button Click
        // Add Visit Information to DB
        private void btnAddVisit_Click(object sender, EventArgs e)
        {
            // TODO -- functionality
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

        // Clear Form Button Click
        // Reset form to original selections / blank text boxes
        private void btnClear_Click(object sender, EventArgs e)
        {
            // TODO -- functionality
        }
    }
}
