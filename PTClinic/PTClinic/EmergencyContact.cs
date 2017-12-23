using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClinic
{
    class EmergencyContact
    {
        private int patientID;
        private string fullname;
        private string phone;
        private string phoneExtension;
        private string phoneType;
        private string relationship;
        private string feedback;


        public int PatientID
        {
            get { return patientID; }
            set { patientID = value; }
        }


        public virtual string Feedback
        {
            get { return feedback; }

        }


        public string Fullname
        {
            get { return fullname; }
            set
            {

                if (string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Enter Emergency Contact Name\n";
                }
                else
                {
                    fullname = value;
                }

            }
        }

        // Public variable for Emegerncy Contact Phone
        public string Phone
        {
            get { return phone; }
            set
            {
                if (string.IsNullOrEmpty(value) || Validation.IsValidLength(value, 14))
                {
                    feedback += "Error: Enter Emergency Contact Phone\n";
                }
                else
                {
                    phone = value;
                }

            }
        }

        // Public variable specifically for Emegerncy Contact Phone Extension
        public string PhoneExtension
        {
            get { return phoneExtension; }
            set
            {
                phoneExtension = value;
            }
        }

        // Public variable specifically for Emegerncy Contact Phone Type
        public string PhoneType
        {
            get { return phoneType; }
            set
            {
                if (value.Equals("Select One"))
                {
                    feedback += "Error: Select Emergency Contact Phone Type\n";
                }
                else
                {
                    phoneType = value;
                }

            }
        }


        public string Relationship
        {
            get { return relationship; }
            set
            {

                if (string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Enter Emergency Contact Relationship\n";
                }
                else
                {
                    relationship = value;
                }

            }
        }


        public EmergencyContact()
        {
            fullname = "";
            phone = "";
            phoneExtension = "";
            phoneType = "";
            relationship = "";
            feedback = "";
        }

        public EmergencyContact(string fullname, string phone, string phoneExtension, string phoneType, string relationship, int patientID)
        {
            Fullname = fullname;
            Phone = phone;
            PhoneExtension = phoneExtension;
            PhoneType = phoneType;
            Relationship = relationship;
            PatientID = patientID;
            feedback = "";

        }


        // Adding a record
        public virtual int AddRecord()
        {
            string strFeedback = "";
            int success = 0;


            // SQL command to add a record to the Caregiver table
            string strSQL = "INSERT INTO Emergency_Contact (ec_fullname, ec_telephone, ec_telephone_ext, ec_telephone_type, ec_relationship, patient_id)" +
                " VALUES (@Fullname, @Phone, @PhoneExtension, @PhoneType, @Relationship, @PatientID);";

            // creating database connection 
            OleDbConnection conn = new OleDbConnection();
            // Create the who what and where of the DB
            string strConn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;";
            // Creating the connection string using the oldedb conn variable and equaling it to the information gathered from connectionstring website
            conn.ConnectionString = strConn;

            // creating database command connection
            OleDbCommand comm = new OleDbCommand();
            comm.CommandText = strSQL; // Commander knows what to say
            comm.Connection = conn;   // Getting the connection

            // Fill in the parameters (has to be created in same sequence as they are used in SQL Statement.)
            comm.Parameters.AddWithValue(@"Fullname", Fullname);
            comm.Parameters.AddWithValue(@"Phone", Phone);
            comm.Parameters.AddWithValue(@"PhoneExtension", PhoneExtension);
            comm.Parameters.AddWithValue(@"PhoneType", PhoneType);
            comm.Parameters.AddWithValue(@"Relationship", Relationship);
            comm.Parameters.AddWithValue(@"PatientID", PatientID);


            try
            {
                // open a connection to the database
                conn.Open();

                // Giving strFeedback the number of records added
                success = comm.ExecuteNonQuery();

                // close the database
                conn.Close();
            }
            catch (Exception err)
            {
                strFeedback = "ERROR: " + err.Message;
            }

            return success;
        } // End of AddRecord


        // Find one Caregiver method
        // Returns a data reader filled with all the data of one patient
        public OleDbDataReader FindOneEmergencyContact(OleDbConnection conn, int intPID)
        {
            string strFeedback = "";
            OleDbCommand comm = new OleDbCommand();

            // Connection string to be used
            //string strConn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;";

            //SQL Command string to pull up one Patients Data
            string strSQL = "SELECT * FROM Emergency_Contact WHERE patient_id = @PID;";

            // Set the connection string
            //conn.ConnectionString = strConn;

            // Give command object info it needs
            comm.Connection = conn;
            comm.CommandText = strSQL;
            comm.Parameters.AddWithValue("@PID", intPID);

            try
            {
                // open a connection to the database
                conn.Open();


            }
            catch (Exception err)
            {
                strFeedback = "ERROR: " + err.Message;
                return null;
            }


            // Return some form of feedback
            return comm.ExecuteReader(CommandBehavior.CloseConnection); // Returning dataset to be used by the calling form.


        } // End of FindOneEmergencyContact

        // Updating Emergency Containct information
        public virtual int UpdateOneRecord(int patientID)
        {
            string strFeedback = "";
            int success = 0;

            // SQL command to Update a record in Emergency Contact table
            string strSQL = "UPDATE Emergency_Contact SET ec_fullname = @Fullname, ec_telephone = @Phone, ec_telephone_ext = @PhoneExtension, ec_telephone_type = @PhoneType, ec_relationship = @Relationship WHERE patient_id = @PatientID;"; 
          
            // creating database connection 
            OleDbConnection conn = new OleDbConnection();
            // Create the who what and where of the DB
            string strConn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;";
            // Creating the connection string using the oldedb conn variable and equaling it to the information gathered from connectionstring website
            conn.ConnectionString = strConn;

            // creating database command connection
            OleDbCommand comm = new OleDbCommand();
            comm.CommandText = strSQL; // Commander knows what to say
            comm.Connection = conn;   // Getting the connection

            // Fill in the parameters (has to be created in same sequence as they are used in SQL Statement.)
            comm.Parameters.AddWithValue(@"Fullname", Fullname);
            comm.Parameters.AddWithValue(@"Phone", Phone);
            comm.Parameters.AddWithValue(@"PhoneExtension", PhoneExtension);
            comm.Parameters.AddWithValue(@"PhoneType", PhoneType);
            comm.Parameters.AddWithValue(@"Relationship", Relationship);
            comm.Parameters.AddWithValue(@"PatientID", patientID);

            try
            {
                // open a connection to the database
                conn.Open();

                // Giving strFeedback the number of records added
                //strFeedback = comm.ExecuteNonQuery().ToString() + " Patient Info Updated";
                success = comm.ExecuteNonQuery();

                // close the database
                conn.Close();
            }
            catch (Exception err)
            {
                strFeedback = "ERROR: " + err.Message;
            }

            return success;
        } // End of UpdateOneRecord



    }
}
