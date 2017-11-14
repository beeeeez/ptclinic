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

        public PatientProfile()
        {
            InitializeComponent();
        }

        // OVERLOADED CONSTRUCTOR --- used for pulling up existing data
        public PatientProfile(int intPID)
        {
            InitializeComponent();

            // Gather info about this patient and store it in a data reader
            PatientInfo temp = new PatientInfo();


            using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
            {
                using (var dataReader = temp.FindOnePatient(connection, intPID))
                {
                    while (dataReader.Read())
                    {
                        // Take the appropriate fields from the datareader
                        // and put them in proper labels
                        // Name
                        lblName.Text = dataReader["patient_first_name"].ToString() + " " + dataReader["patient_middle_initial"].ToString() + " " + dataReader["patient_last_name"].ToString();
                        // Gender
                        lblGender.Text = dataReader["patient_gender"].ToString();
                        // DOB
                        string shortDateStr = dataReader["patient_dob"].ToString();
                        DateTime shortDateBirthday = Convert.ToDateTime(shortDateStr);
                        lblDateOfBirth.Text = shortDateBirthday.ToShortDateString();
                        // Address
                        lblAddress.Text = dataReader["patient_address"].ToString() + " " + dataReader["patient_address2"].ToString();
                        // City
                        lblCity.Text = dataReader["patient_city"].ToString();
                        // State
                        lblState.Text = dataReader["patient_state"].ToString();
                        // Zip
                        lblZip.Text = dataReader["patient_zip"].ToString();
                        // Phone
                        lblPhone.Text = dataReader["patient_phone1"].ToString() + "  Ext: " + dataReader["patient_phone1_extension"].ToString() + "  Type: " + dataReader["patient_phone1_type"].ToString();

                        //Set the Patient ID = to the one from the DB
                        PatientID = dataReader["patient_id"].ToString();

                        MessageBox.Show(PatientID);
                    }
                }
            }




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

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {

        }
    }
}
