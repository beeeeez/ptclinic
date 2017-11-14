using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClinic
{
    class PatientInfo
    {
        // Private variables only the class can access.

        // Patient variables
        private string fName;
        private string mInitial;
        private string lName;
        private string gender;
        private DateTime dob;
        private string address;
        private string address2;
        private string city;
        private string state;
        private string zip;
        // Unsure if this should be string or boolean
        private bool hasInsurance;
        private string insurer;
        private string otherInsurer;
        private string phone;
        private string phoneExtension;
        private string phoneType;
        private string phone2;
        private string phone2Extension;
        private string phone2Type;
        // Unsure if this should be string or boolean.
        private bool leaveMessage;
        private string email;

        /* 
         * Caregiver given own class
         * since it has its own table in the Database
         * 
         */

        // Creating the public variables that are the front end to the private variables

        // Public variable specifically for First Name
        public string Fname
        {
            get { return fName; }
            set
            {
                // TODO -- error handling goes here?
                fName = value;
            }
        }

        // Public variable specifically for Middle Initial
        public string MInitial
        {
            get { return mInitial; }
            set
            {
                // TODO -- error handling goes here? (or we could limit the character value of the textbox for only 1 character)
                mInitial = value;
            }
        }

        // Public variable specifically for Last Name
        public string Lname
        {
            get { return lName; }
            set
            {
                // TODO -- error handling goes here~
                lName = value;
            }
        }

        // Public variable specifically for Gender
        public string Gender
        {
            get { return gender; }
            set
            {
                // TODO -- error handling goes here~
                gender = value;
            }
        }

        //Public variable for Date of Birth
        public DateTime Birthdate
        {
            get { return dob; }
            set { dob = value; }
        }

        // Public variable specifically for Address
        public string Address
        {
            get { return address; }
            set
            {
                // TODO -- error handling goes here?
                address = value;
            }
        }

        // Public variable specifically for Address2
        public string Address2
        {
            get { return address2; }
            set
            {
                // TODO -- error handling goes here?
                address2 = value;
            }
        }

        // Public variable specifically for City
        public string City
        {
            get { return city; }
            set
            {
                // TODO -- error handling goes here?
                city = value;
            }
        }

        // Public variable specifically for State
        public string State
        {
            get { return state; }
            set
            {
                // TODO -- error handling goes here?
                state = value;
            }
        }

        // Public variable specifically for Zipcode
        public string Zip
        {
            get { return zip; }
            set
            {
                // TODO -- error handling goes here?
                zip = value;
            }
        }

        // Public variable specifically for HasInsurance
        // May change?
        public bool HasInsurance
        {
            get { return hasInsurance; }
            set
            {
                hasInsurance = value;
            }
        }

        // Public variable specifically for Insurer
        public string Insurer
        {
            get { return insurer; }
            set
            {
                // TODO >> is validation needed here?
                // Can we make a "select one" in the dropdown disabled?
                insurer = value;
            }
        }

        // Public variable specifically for Other Insurers
        public string OtherInsurer
        {
            get { return otherInsurer; }
            set
            {
                // TODO >> is validation needed here?
                otherInsurer = value;
            }
        }

        // Public variable specifically for Phone
        public string Phone
        {
            get { return phone; }
            set
            {
                // TODO -- error handling goes here?
                phone = value;
            }
        }

        // Public variable specifically for Phone Extension
        public string PhoneExtension
        {
            get { return phoneExtension; }
            set
            {
                // TODO -- error handling goes here?
                phoneExtension = value;
            }
        }

        // Public variable specifically for Phone Type
        public string PhoneType
        {
            get { return phoneType; }
            set
            {
                // TODO -- error handling goes here?
                phoneType = value;
            }
        }

        // Public variable specifically for Phone2
        public string Phone2
        {
            get { return phone2; }
            set
            {
                // TODO -- error handling goes here?
                phone2 = value;
            }
        }

        // Public variable specifically for Phone2 Extension
        public string Phone2Extension
        {
            get { return phone2Extension; }
            set
            {
                // TODO -- error handling goes here?
                phone2Extension = value;
            }
        }

        // Public variable specifically for Phone2 Type
        public string Phone2Type
        {
            get { return phone2Type; }
            set
            {
                // TODO -- error handling goes here?
                phone2Type = value;
            }
        }
        
        // Public variable for LeaveMessage
        public bool LeaveMessage
        {
            get { return leaveMessage; }
            set
            {
                leaveMessage = value;
            }
        }

        // Public variable specifically for Email
        public string Email
        {
            get { return email; }
            set
            {
                // TODO >> Email validation here--
                email = value;
            }
        }

        // Default Constructor
        public PatientInfo()
        {
            //Start by giving feedback an empty string
            //feedback = "";
            fName = "";
            mInitial = "";
            lName = "";
            phone = "";
            phoneExtension = "";
            phone2 = "";
            phone2Extension = "";
        }
        
        // Overloaded Constructor
        public PatientInfo(string fName, string mInitial, string lName, string gender, DateTime dob, string address, string address2, string city, string state, string zip, bool hasInsurance, string insurer, string otherInsurer, string phone, string phoneExtension, string phoneType, string phone2, string phone2Extension, string phone2Type, bool leaveMessage, string email)
        {
            //this.Name = name;
            Fname = fName;
            MInitial = mInitial;
            Lname = lName;
            Gender = gender;
            Birthdate = dob;
            Address = address;
            Address2 = address2;
            City = city;
            State = state;
            Zip = zip;
            HasInsurance = hasInsurance;
            Insurer = insurer;
            OtherInsurer = otherInsurer;
            Phone = phone;
            PhoneExtension = phoneExtension;
            PhoneType = phoneType;
            Phone2 = phone2;
            Phone2Extension = phone2Extension;
            Phone2Type = phone2Type;
            LeaveMessage = leaveMessage;
            Email = email;
        }

        // Adding a record
        public virtual int AddRecord()
        {
            string strFeedback = "";
            int success = 0;

            // SQL command to add a record to the Patients table
            string strSQL = "INSERT INTO Patients (patient_first_name, patient_middle_initial, patient_last_name, patient_gender, patient_dob, patient_address, patient_address2, patient_city, patient_state, patient_zip, patient_has_insurance, patient_insurer, patient_phone1, patient_phone1_extension, patient_phone1_type, patient_phone2, patient_phone2_extension, patient_phone2_type, contact_patient, patient_email, patient_other_insurance)" +
                " VALUES (@Fname, @MInitial, @Lname, @Gender, @Birthdate, @Address, @Address2, @City, @State, @Zip, @HasInsurance, @Insurer, @Phone, @PhoneExtension, @PhoneType, @Phone2, @Phone2Extension, @Phone2Type, @LeaveMessage, @Email, @OtherInsurance);";

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
            comm.Parameters.AddWithValue(@"Fname", Fname);
            comm.Parameters.AddWithValue(@"MInitial", MInitial);
            comm.Parameters.AddWithValue(@"Lname", Lname);
            comm.Parameters.AddWithValue(@"Gender", Gender);
            comm.Parameters.AddWithValue(@"BirthDate", Birthdate).ToString();
            comm.Parameters.AddWithValue(@"Address", Address);
            comm.Parameters.AddWithValue(@"Address2", Address2);
            comm.Parameters.AddWithValue(@"City", City);
            comm.Parameters.AddWithValue(@"State", State);
            comm.Parameters.AddWithValue(@"Zip", Zip);

            comm.Parameters.AddWithValue(@"HasInsurance", HasInsurance);
            comm.Parameters.AddWithValue(@"Insurer", Insurer);

            comm.Parameters.AddWithValue(@"Phone", Phone);
            comm.Parameters.AddWithValue(@"PhoneExtension", PhoneExtension);
            comm.Parameters.AddWithValue(@"PhoneType", PhoneType);
            comm.Parameters.AddWithValue(@"Phone2", Phone2);
            comm.Parameters.AddWithValue(@"Phone2Extension", Phone2Extension);
            comm.Parameters.AddWithValue(@"Phone2Type", Phone2Type);
            comm.Parameters.AddWithValue(@"LeaveMessage", LeaveMessage);
            comm.Parameters.AddWithValue(@"Email", Email);
            comm.Parameters.AddWithValue(@"OtherInsurer", OtherInsurer);


            try
            {
                // open a connection to the database
                conn.Open();

                // Giving strFeedback the number of records added
                //strFeedback = comm.ExecuteNonQuery().ToString() + " Patient Info Added";
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



        // Search Functionality 
        public DataSet SearchPatients(string myFirst, string myLast)
        {
            string strFeedback = "";
            // Create an empty dataset ( a copy of the DB or Table)
            DataSet dataSet = new DataSet();

            // conn - how and where to connect to a DB
            OleDbConnection conn = new OleDbConnection();

            // comm -- for what SQL command we want to use
            OleDbCommand comm = new OleDbCommand();

            // DataAdatper used as translator between the dataset and comm
            OleDbDataAdapter da = new OleDbDataAdapter();

            // SQL command to get record(s) from the Patient Info table
            string strSQL = "SELECT patient_id, patient_first_name, patient_middle_initial, patient_last_name, patient_dob FROM Patients WHERE 0=0";

            // Create the connection string
            string strConn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;";

            // Setting the connection string
            conn.ConnectionString = strConn;

            // Point comm towards which connection to use
            comm.Connection = conn;

            // If first name is filled in, use it as criteria for the search
            if (myFirst.Length > 0)
            {
                strSQL += " AND patient_first_name LIKE @Fname";
                comm.Parameters.AddWithValue("@Fname", "%" + myFirst + "%");
            }

            // If last name is filled in, use it as criteria for the search
            if (myLast.Length > 0)
            {
                strSQL += " AND patient_last_name LIKE @Lname";
                comm.Parameters.AddWithValue("@Lname", "%" + myLast + "%");
            }

            // Tell comm what to say
            comm.CommandText = strSQL;

            // DataAdapter which command object to translate for
            da.SelectCommand = comm;


            try
            {
                // open a connection to the database
                conn.Open();

                da.Fill(dataSet, "patientInfo");

                // close the database
                conn.Close();
            }
            catch (Exception err)
            {
                strFeedback = "ERROR: " + err.Message;
            }

            return dataSet;
        } // End of SearchPatients


        // Find one Patient method
        // Returns a data reader filled with all the data of one patient
        public OleDbDataReader FindOnePatient(OleDbConnection conn, int intPID)
        {
            string strFeedback = "";
            OleDbCommand comm = new OleDbCommand();

           // Connection string to be used
            //string strConn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;";

            //SQL Command string to pull up one Patients Data
            string strSQL = "SELECT patient_id, patient_first_name, patient_middle_initial, patient_last_name, patient_gender, patient_dob, patient_address, patient_address2, patient_city, patient_state, patient_zip, patient_phone1, patient_phone1_extension, patient_phone1_type FROM Patients WHERE patient_id = @PID;";

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

    } // End of PatientInfo
}
