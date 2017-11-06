using System;
using System.Collections.Generic;
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
        private Boolean hasInsurance;
        private string insurer;
        private string phone;
        private string phoneExtension;
        private string phoneType;
        private string phone2;
        private string phone2Extension;
        private string phone2Type;
        // Unsure if this should be string or boolean.
        private Boolean leaveMessage;
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
        public Boolean HasInsurance
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
        public Boolean LeaveMessage
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
        public PatientInfo(string fName, string mInitial, string lName, string gender, DateTime dob, string address, string address2, string city, string state, string zip, bool hasInsurance, string insurer, string phone, string phoneExtension, string phoneType, string phone2, string phone2Extension, string phone2Type, bool leaveMessage, string email)
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
        public virtual string AddRecord()
        {
            string strFeedback = "";

            // SQL command to add a record to the Patients table
            string strSQL = "INSERT INTO Patients (patient_first_name, patient_middle_initial, patient_last_name, patient_gender, patient_dob, patient_address, patient_address2, patient_city, patient_state, patient_zip, patient_has_insurance, patient_insurer, patient_phone1, patient_phone1_extension, patient_phone1_type, patient_phone2, patient_phone2_extension, patient_phone2_type, contact_patient, patient_email)" +
                " VALUES (@Fname, @MInitial, @Lname, @Gender, @Birthdate, @Address, @Address2, @City, @State, @Zip, @HasInsurance, @Insurer, @Phone, @PhoneExtension, @PhoneType, @Phone2, @Phone2Extension, @Phone2Type, @LeaveMessage, @Email);";

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
            comm.Parameters.AddWithValue(@"Phone", Phone);
            comm.Parameters.AddWithValue(@"PhoneExtension", PhoneExtension);
            comm.Parameters.AddWithValue(@"PhoneType", PhoneType);
            comm.Parameters.AddWithValue(@"Phone2", Phone2);
            comm.Parameters.AddWithValue(@"Phone2Extension", Phone2Extension);
            comm.Parameters.AddWithValue(@"Phone2Type", Phone2Type);
            comm.Parameters.AddWithValue(@"LeaveMessage", LeaveMessage);
            comm.Parameters.AddWithValue(@"Email", Email);


            try
            {
                // open a connection to the database
                conn.Open();

                // Giving strFeedback the number of records added
                strFeedback = comm.ExecuteNonQuery().ToString() + " Records Added";

                // close the database
                conn.Close();
            }
            catch (Exception err)
            {
                strFeedback = "ERROR: " + err.Message;
            }
            return strFeedback;
        } // End of AddRecord
        
    } // End of PatientInfo
}
