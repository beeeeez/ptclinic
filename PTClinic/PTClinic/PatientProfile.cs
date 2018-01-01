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
    public partial class PatientProfile : Form
    {
        //Private variable to store the patient ID ?
        private string PatientID;
        public int pID; // patient ID to pass to Appointment or visit form
        private string pName; // String to pass a Patients name to visit form

        // Variables for the admin and login and Search forms
        private Form Admin;
        private Form Login;
        private Form Search;
        private Form PatientInfo;
        PatientInfo patientDetails;
        private string lastUpdated; // PT Goals last update time
        private string patientStatus;

        public PatientProfile()
        {
            InitializeComponent();
            setButtonIcon();
        }

        // OVERLOADED CONSTRUCTOR --- used for pulling up existing data
        public PatientProfile(int intPID, Form adminForm, Form Login, Form search, Form PatientInfo, bool isNewRecord)
        {
            InitializeComponent();
            setButtonIcon();

            pID = intPID;

            patientDetails = new PatientInfo();

            this.Login = Login;
            this.Admin = adminForm;
            this.Search = search;
            this.PatientInfo = PatientInfo;

            // If isNewRecord == true display "Patient information has been saved!
            if (isNewRecord == true)
            {
                // Display the Patient Saved Panel
                panelMessage.Visible = true;
                PatientInfo.Hide();
            }
            else
            {
                panelMessage.Visible = false;
                Search.Hide();
            }

            // Create variable for PatientInfo
            PatientInfo tempPatient = new PatientInfo();

            // Create variable for CaregiverInfo
            CaregiverInfo tempCG = new CaregiverInfo();

            // Create variable for EmergencyContact
            EmergencyContact tempEC = new EmergencyContact();

            // Create variable for VisitInfo
            VisitInfo tempVisit = new VisitInfo();

            // Create variable for PT Goals Class
            PatientGoals ptGoals = new PatientGoals();


            using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
            {
                // Gather info about this patient via the patient ID (intPID) passed from the search and store it in a data reader
                using (var dataReaderPatient = tempPatient.FindOnePatient(connection, intPID))
                {
                    while (dataReaderPatient.Read())
                    {
                        // Take the appropriate fields from the datareader
                        // and put them in proper labels
                       
                        patientDetails.Fname = dataReaderPatient["patient_first_name"].ToString();
                        patientDetails.Lname = dataReaderPatient["patient_last_name"].ToString();
                        patientDetails.Address = dataReaderPatient["patient_address"].ToString();
                        patientDetails.Address2 = dataReaderPatient["patient_address2"].ToString();
                        patientDetails.City = dataReaderPatient["patient_city"].ToString();
                        patientDetails.State = dataReaderPatient["patient_state"].ToString();
                        patientDetails.Zip = dataReaderPatient["patient_zip"].ToString();
                        patientDetails.Phone = dataReaderPatient["patient_phone1"].ToString();
                        patientDetails.PhoneExtension = dataReaderPatient["patient_phone1_extension"].ToString();
                        patientDetails.PhoneType = dataReaderPatient["patient_phone1_type"].ToString();

                        // Get Patient Status
                        patientStatus = dataReaderPatient["patient_status"].ToString();
                        
                        //Grab the patients name to send over to visit forms / appointments etc.
                        pName = dataReaderPatient["patient_first_name"].ToString() + " " + dataReaderPatient["patient_middle_initial"].ToString() + " " + dataReaderPatient["patient_last_name"].ToString();

                        // Patient Name
                        lblName.Text = dataReaderPatient["patient_first_name"].ToString() + " " + dataReaderPatient["patient_middle_initial"].ToString() + " " + dataReaderPatient["patient_last_name"].ToString();
                        // Gender
                        lblGender.Text = dataReaderPatient["patient_gender"].ToString();
                        // DOB
                        string shortDateStr = dataReaderPatient["patient_dob"].ToString();
                        DateTime shortDateBirthday = Convert.ToDateTime(shortDateStr);
                        lblDateOfBirth.Text = shortDateBirthday.ToShortDateString();
                        // Address
                        lblAddress.Text = dataReaderPatient["patient_address"].ToString() + " " + dataReaderPatient["patient_address2"].ToString();
                        // City
                        lblCity.Text = dataReaderPatient["patient_city"].ToString();
                        // State
                        lblState.Text = dataReaderPatient["patient_state"].ToString();
                        // Zip
                        lblZip.Text = dataReaderPatient["patient_zip"].ToString();
                        // Phone
                        lblPhone.Text = dataReaderPatient["patient_phone1"].ToString() + "  Ext: " + dataReaderPatient["patient_phone1_extension"].ToString() + "  Type: " + dataReaderPatient["patient_phone1_type"].ToString();

                        //Set the Patient ID = to the one from the DB
                        PatientID = dataReaderPatient["patient_id"].ToString();

                        //MessageBox.Show(PatientID);
                    }
                }

                // Gather info about this patient's caregiver via the patient ID (intPID) passed from the search and store it in a data reader
                using (var dataReaderCG = tempCG.FindOneCaregiver(connection, intPID))
                {
                    while (dataReaderCG.Read())
                    {
                        // Take the appropriate fields from the datareader
                        // and put them in proper labels
                        // Caregiver Name
                        lblCGName.Text = dataReaderCG["caregiver_name"].ToString();
                        // CaregiverPhone
                        lblCGPhone.Text = dataReaderCG["caregiver_phone1"].ToString() + "  Ext: " + dataReaderCG["caregiver_phone1_extension"].ToString() + "  Type: " + dataReaderCG["caregiver_phone1_type"].ToString();
                    }
                } // End of -- using (var dataReaderCG = tempCG.FindOneCaregiver(connection, intPID))



                // Gather info about this patient's emergency contact via the patient ID (intPID) passed from the search and store it in a data reader
                using (var dataReaderEC = tempEC.FindOneEmergencyContact(connection, intPID))
                {
                    while (dataReaderEC.Read())
                    {
                        // Take the appropriate fields from the datareader
                        // and put them in proper labels

                        // Emergency Contact Fullname
                        lblECFullname.Text = dataReaderEC["ec_fullname"].ToString();
                        // Emergency Contact Phone Number 
                        lblECPhone.Text = dataReaderEC["ec_telephone"].ToString() + "  Ext: " + dataReaderEC["ec_telephone_ext"].ToString() + "  Type: " + dataReaderEC["ec_telephone_type"].ToString();
                        // Emergency Contact Relationship 
                        lblECRelationship.Text = dataReaderEC["ec_relationship"].ToString();

                    }
                } // End of --  using (var dataReaderEC = tempEC.FindOneEmergencyContact(connection, intPID))

                // Gather info about the patients diagnosis
                using (var dataReaderVisitInfo = tempVisit.FindOnePatientVisit(connection, intPID))
                {
                    while (dataReaderVisitInfo.Read())
                    {
                        // Take the appropriate fields from the datareader
                        // and put them in proper labels

                        // Patient Diagnosis
                        tbDiagnosis.Text = dataReaderVisitInfo["diagnosis"].ToString();
                        tbPTGoals.Text = dataReaderVisitInfo["pt_goals"].ToString();
                    }
                } // End of -- using(var dataReaderVisitInfo = tempVisit.FindOnePatientVisit(connection, intPID)

                // Gather the date for the last update PT Goals for patient
                using (var dataReaderPTGoals = ptGoals.FindPatientGoals(connection, intPID))
                {
                    while (dataReaderPTGoals.Read())
                    {
                        lastUpdated  = dataReaderPTGoals["goal_date"].ToString();
                    }
                } // End of -- using(var dataReaderVisitInfo = tempVisit.FindOnePatientVisit(connection, intPID)

            } // End of -- using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))

            // Checks pt goals last update time and alerts user to update goals if greater than 1 month
            CalculateDateRange();
          
        }

        private void CalculateDateRange()
        {
            if (string.IsNullOrEmpty(lastUpdated) || lastUpdated.Equals(""))
            {
                panelPTGoalsMessage.Visible = false;
            }
            else
            {
                DateTime ptLastUpdate = Convert.ToDateTime(lastUpdated);
                int daySincePTUpdated = (DateTime.Now.Date - ptLastUpdate.Date).Days;

                if (daySincePTUpdated >= 30)
                {
                    //MessageBox.Show("Update Patient Goals \n Last Updated : " + daySincePTUpdated + " days ago" );
                    panelPTGoalsMessage.Visible = true;
                }
                else
                {
                    panelPTGoalsMessage.Visible = false;
                }

            }
         
        }

        // Setting the Icons for Logout and Home Buttons
        private void setButtonIcon()
        {
            btnLogOut.Image = Image.FromFile("..\\..\\Resources\\ic_power_settings_new_white_24dp_1x.png");
            btnBackHome.Image = Image.FromFile("..\\..\\Resources\\ic_home_white_24dp_1x.png");
            btnScheduleAppointment.Image = Image.FromFile("..\\..\\Resources\\ic_event_black_24dp_1x.png");
            btnUpdateInformation.Image = Image.FromFile("..\\..\\Resources\\ic_mode_edit_black_24dp_1x.png");
            btnPatientGoals.Image = Image.FromFile("..\\..\\Resources\\ic_trending_up_black_24dp_1x.png");
            btnPatientVisit.Image = Image.FromFile("..\\..\\Resources\\ic_favorite_black_24dp_1x.png");
            btnBackToSearch.Image = Image.FromFile("..\\..\\Resources\\ic_arrow_back_white_24dp_1x.png");
            btnPrintPatientInfo.Image = Image.FromFile("..\\..\\Resources\\ic_print_black_24dp_1x.png");
        }

        // Back to Home Button
        private void btnBackHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin.Show();
        }

        // Logout Button
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.Show();
        }

        // Back to Search Button
        private void btnBackToSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search newSearchForm = new Search(Admin, Login);
            newSearchForm.Show();
        }

        // Schedule Appointment Button
        private void btnScheduleAppointment_Click(object sender, EventArgs e)
        {
           
            AppointmentForm newAppointment = new AppointmentForm(this, Admin, Login, pID, patientDetails);

            newAppointment.Show();

        }

        // Patient Visit Button
        private void btnPatientVisit_Click(object sender, EventArgs e)
        {
            this.Hide();


            // TODO Complete check for status and initialize forms accordingly
        
            if (patientStatus.ToLower().Equals("initial"))
            {
                VisitForm initialVisitForm = new VisitForm(PatientID, pName, Admin, Login, this);
                initialVisitForm.Show();
            }
            else
            {
                FollowUpVisitForm followUpForm = new FollowUpVisitForm(PatientID, pName, Admin, Login, this);
                followUpForm.Show();
            }
         
        }

        // Patient Goals Button
        private void btnPatientGoals_Click(object sender, EventArgs e)
        {
            this.Hide();
            bool fromProfile = true;
            PatientGoalsForm temp = new PatientGoalsForm(pID, fromProfile, Admin, Login, this);
            temp.Show();
        }

        // Update Info  Button
        private void btnUpdateInformation_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Patient ID being passed back is " + pID);
            PatientInformation updatePatientInfo = new PatientInformation(pID, Admin, Login);
            updatePatientInfo.Show();
            this.Hide();

        }

        // Print Patient Information
        private void btnPrintPatientInfo_Click(object sender, EventArgs e)
        {
            // TODO - Print Patient Demographic -- Emergency Contact - Caregiver Info + PT Goals Diagnosis if there are any
            //MessageBox.Show("Print Patient Info Here");

            if (printPreviewDialog.ShowDialog() == DialogResult.OK)
            {
                printPatientInfo.Print();
            }

        }

        private void printPatientInfo_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            using (Font font1 = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Point))
            {

                Rectangle rect1 = new Rectangle(100, 100, 650, 25);
                StringFormat SF = new StringFormat();
                SF.Alignment = StringAlignment.Center;
                SF.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString("Patient Information",font1, Brushes.Black, rect1, SF);
                e.Graphics.DrawRectangle(Pens.Black, rect1);

            }
          //  e.Graphics.DrawString("Patient Information", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 100));
            e.Graphics.DrawString("Darrel Derkinonws", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new PointF(100, 130));
        }
    }
}
