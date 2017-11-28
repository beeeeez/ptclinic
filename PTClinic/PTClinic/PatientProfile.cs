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

        // Variables for the admin and login and Search forms
        private Form Admin;
        private Form Login;
        private Form Search;
        private Form PatientInfo;

        public PatientProfile()
        {
            InitializeComponent();
        }

        // OVERLOADED CONSTRUCTOR --- used for pulling up existing data
        public PatientProfile(int intPID, Form adminForm, Form Login, Form search, Form PatientInfo, bool isNewRecord)
        {
            InitializeComponent();
         

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


            using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
            {
                // Gather info about this patient via the patient ID (intPID) passed from the search and store it in a data reader
                using (var dataReaderPatient = tempPatient.FindOnePatient(connection, intPID))
                {
                    while (dataReaderPatient.Read())
                    {
                        // Take the appropriate fields from the datareader
                        // and put them in proper labels
                        // Name
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

            } // End of -- using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))




            //OleDbDataReader dataReader = temp.FindOnePatient(intPID);

            //// Use this infor to fill out the form
            //while (dataReader.Read())
            //{
            //    // Take the appropriate fields from the datareader
            //    // and put them in proper labels
            //    // Name
            //    lblName.Text = dataReader["patient_first_name"].ToString() + " " + dataReader["patient_middle_initial"].ToString() + " " + dataReader["patient_last_name"].ToString();
            //    // Gender
            //    lblGender.Text = dataReader["patient_gender"].ToString();
            //    // DOB
            //    string shortDateStr = dataReader["patient_dob"].ToString();
            //    DateTime shortDateBirthday = Convert.ToDateTime(shortDateStr);
            //    lblDateOfBirth.Text = shortDateBirthday.ToShortDateString();
            //    // Address
            //    lblAddress.Text = dataReader["patient_address"].ToString() + " " + dataReader["patient_address2"].ToString();
            //    // City
            //    lblCity.Text = dataReader["patient_city"].ToString();
            //    // State
            //    lblState.Text = dataReader["patient_state"].ToString();
            //    // Zip
            //    lblZip.Text = dataReader["patient_zip"].ToString();
            //    // Phone
            //    lblPhone.Text = dataReader["patient_phone1"].ToString() + "  Ext: " + dataReader["patient_phone1_extension"].ToString() + "  Type: " + dataReader["patient_phone1_type"].ToString();

            //    //Set the Patient ID = to the one from the DB
            //    PatientID = dataReader["patient_id"].ToString();

            //    MessageBox.Show(PatientID);
            //}
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


    }
}
