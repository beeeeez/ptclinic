using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClinic
{
    class CaregiverInfo
    {
        // Private variables only the class can access.
        // Caregiver variables
        private int patientID;
        private string name;
        private string address;
        private string city;
        private string state;
        private string zip;
        private string phone;
        private string phoneExtension;
        private string phoneType;
        private string phone2;
        private string phone2Extension;
        private string phone2Type;
        protected string feedback;


        // Creating the public variables that are the front end to the private variables

        public virtual string Feedback
        {
            get { return feedback; }
        }

        public int PatientID
        {
            get { return patientID; }
            set { patientID = value; }
        }

        // Public variable specifically for Caregiver Name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Public variable specifically for Address
        public string Address
        {
            get { return address; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Enter an Address\n";
                }
                else
                {
                    address = value;
                }
            }
        }

        // Public variable specifically for City
        public string City
        {
            get { return city; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Enter an City\n";
                }
                else
                {
                    city = value;
                }
               
            }
        }

        // Public variable specifically for State
        public string State
        {
            get { return state; }
            set
            {
                if (value.Equals("Select One") || string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Select a State\n";
                }
                else
                {
                    state = value;
                }
            }
        }

        // Public variable specifically for Zipcode
        public string Zip
        {
            get { return zip; }
            set
            {
                if (string.IsNullOrEmpty(value) || Validation.IsValidLength(value, 5))
                {
                    feedback += "Error: Enter a Zipcode\n";
                }
                else
                {
                    zip = value;
                }
            }
        }

        // Public variable specifically for Phone
        public string Phone
        {
            get { return phone; }
            set
            {
                if (string.IsNullOrEmpty(value) || Validation.IsValidLength(value, 14))
                {
                    feedback += "Error: Enter Telephone 1\n";
                }
                else
                {
                    phone = value;
                }
            }
        }

        // Public variable specifically for Phone Extension
        public string PhoneExtension
        {
            get { return phoneExtension; }
            set
            {
                phoneExtension = value;
            }
        }

        // Public variable specifically for Phone Type
        public string PhoneType
        {
            get { return phoneType; }
            set
            {
                if (value.Equals("Select One"))
                {
                    feedback += "Error: Select Telephone 1 Type\n";
                }
                else
                {
                    phoneType = value;
                }
               
            }
        }

        // Public variable specifically for Phone2
        public string Phone2
        {
            get { return phone2; }
            set
            {
                phone2 = value;
            }
        }

        // Public variable specifically for Phone2 Extension
        public string Phone2Extension
        {
            get { return phone2Extension; }
            set
            {
                phone2Extension = value;
            }
        }

        // Public variable specifically for Phone2 Type
        public string Phone2Type
        {
            get { return phone2Type; }
            set
            {
                if (!Validation.IsValidLength(Phone2, 14))
                {
                    if (value.Equals("Select One"))
                    {
                        feedback += "Error: Select Telephone 2 Type\n";
                    }
                    else
                    {
                        phone2Type = value;
                    }
                }
                else
                {
                    phone2Type = " ";
                }

            }
        }

        // Default Constructor
        public CaregiverInfo()
        {
            //Start by giving feedback an empty string
            //feedback = "";
            name = "";
            phone = "";
            phoneExtension = "";
            phone2 = "";
            phone2Extension = "";
            feedback = "";
        }

        // Overloaded Constructor
        public CaregiverInfo(int patientID, string name, string phone, string phoneExtension, string phoneType, string phone2, string phone2Extension, string phone2Type, string address, string city, string state, string zip)
        {
            //this.Name = name;
            feedback = "";
            PatientID = patientID;
            Name = name;
            Phone = phone;
            PhoneExtension = phoneExtension;
            PhoneType = phoneType;
            Phone2 = phone2;
            Phone2Extension = phone2Extension;
            Phone2Type = phone2Type;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
        }

        // Adding a record
        public virtual string AddRecord()
        {
            string strFeedback = "";

         
            // SQL command to add a record to the Caregiver table
            string strSQL = "INSERT INTO Caregiver (patient_id, caregiver_name, caregiver_phone1, caregiver_phone1_extension, caregiver_phone1_type, caregiver_phone2, caregiver_phone2_extension, caregiver_phone2_type, caregiver_address, caregiver_city, caregiver_state, caregiver_zip)" +
                " VALUES (@PatientID, @Name, @Phone, @PhoneExtension, @PhoneType, @Phone2, @Phone2Extension, @Phone2Type, @Address, @City, @State, @Zip);";

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
            comm.Parameters.AddWithValue(@"PatientID", PatientID);
            comm.Parameters.AddWithValue(@"Name", Name);
            comm.Parameters.AddWithValue(@"Phone", Phone);
            comm.Parameters.AddWithValue(@"PhoneExtension", PhoneExtension);
            comm.Parameters.AddWithValue(@"PhoneType", PhoneType);
            comm.Parameters.AddWithValue(@"Phone2", Phone2);
            comm.Parameters.AddWithValue(@"Phone2Extension", Phone2Extension);
            comm.Parameters.AddWithValue(@"Phone2Type", Phone2Type);
            comm.Parameters.AddWithValue(@"Address", Address);
            comm.Parameters.AddWithValue(@"City", City);
            comm.Parameters.AddWithValue(@"State", State);
            comm.Parameters.AddWithValue(@"Zip", Zip);


            try
            {
                // open a connection to the database
                conn.Open();

                // Giving strFeedback the number of records added
                strFeedback = comm.ExecuteNonQuery().ToString() + " Patient Record has been saved";

                // close the database
                conn.Close();
            }
            catch (Exception err)
            {
                strFeedback = "ERROR: " + err.Message;
            }
            return strFeedback;
        } // End of AddRecord


        // Find one Caregiver method
        // Returns a data reader filled with all the data of one patient
        public OleDbDataReader FindOneCaregiver(OleDbConnection conn, int intPID)
        {
            string strFeedback = "";
            OleDbCommand comm = new OleDbCommand();

            // Connection string to be used
            //string strConn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;";

            //SQL Command string to pull up one Patients Data
            string strSQL = "SELECT caregiver_name, caregiver_phone1, caregiver_phone1_extension, caregiver_phone1_type, caregiver_address, caregiver_city, caregiver_state, caregiver_zip FROM Caregiver WHERE patient_id = @PID;";

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
        } // End of FindOnePatient


    } // End of Class CaregiverInfo
}
