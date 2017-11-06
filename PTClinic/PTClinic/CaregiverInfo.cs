using System;
using System.Collections.Generic;
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


        // Creating the public variables that are the front end to the private variables

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
                // TODO -- error handling goes here?
                address = value;
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
        }

        //Adding a record
        public virtual string AddRecord()
        {
            string strFeedback = "";

            // TODO Figure out how to pass in the Patient ID?

            // TODO -- FIX EVERYTHING IN HERE-- 

            // SQL command to add a record to the Persons database
            string strSQL = "INSERT INTO Persons (Fname, Mname, Lname, Street1, Street2, City, State, Zip, Phone, Email, MyAge, NumOfPets, BirthDate) VALUES (@Fname, @Mname, @Lname, @Street1, @Street2, @City, @State, @Zip, @Phone, @Email, @MyAge, @NumOfPets, @BirthDate);";

            //creating database connection 
            OleDbConnection conn = new OleDbConnection();
            //Create the who what and where of the DB
            string strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Contacts.accdb; Persist Security Info=False;";
            //Creating the connection string using the oldedb conn variable and equaling it to the information gathered from connectionstring website
            conn.ConnectionString = strConn;

            //creating database command connection
            OleDbCommand comm = new OleDbCommand();
            comm.CommandText = strSQL; //Commander knows what to say
            comm.Connection = conn;   //Getting the connection

            //Fill in the parameters (has to be created in same sequence as they are used in SQL Statement.)
            //comm.Parameters.AddWithValue(@"Fname", Fname);
            //comm.Parameters.AddWithValue(@"Mname", Mname);
            //comm.Parameters.AddWithValue(@"Lname", Lname);
            //comm.Parameters.AddWithValue(@"Street1", Street1);
            //comm.Parameters.AddWithValue(@"Street2", Street2);
            //comm.Parameters.AddWithValue(@"City", City);
            //comm.Parameters.AddWithValue(@"State", State);
            //comm.Parameters.AddWithValue(@"Zip", Zip);
            //comm.Parameters.AddWithValue(@"Phone", Phone);
            //comm.Parameters.AddWithValue(@"Email", Email);
            //comm.Parameters.AddWithValue(@"MyAge", MyAge);
            //comm.Parameters.AddWithValue(@"BirthDate", BDay).ToString();


            try
            {
                //open a connection to the database
                conn.Open();

                //Here is where we will add a record in the future.....
                strFeedback = comm.ExecuteNonQuery().ToString() + " Records Added";

                //close the database
                conn.Close();
            }
            catch (Exception err)
            {
                strFeedback = "ERROR: " + err.Message;
            }
            return strFeedback;
        } // End of AddRecord


    } // End of Class CaregiverInfo
}
