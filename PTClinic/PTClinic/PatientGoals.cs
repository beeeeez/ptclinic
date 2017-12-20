using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClinic
{
    class PatientGoals
    {

        // Private variables only the class can access.
        //  Patient Goals Form Variables
        private int patientID;
        private string activity_one;
        private string activity_two;
        private string activity_three;
        private string activity_one_score;
        private string activity_two_score;
        private string activity_three_score;
        private string patient_goals;
  
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

        // Public variable for activiy one
        public string Activity_One
        {
            get { return activity_one; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Enter Activity-1 Description\n";
                }
                else
                {
                    activity_one = value;
                }
            }
        }

        // Public variable for activiy one score
        public string Activity_One_Score
        {
            get { return activity_one_score; }
            set
            {
                if (!string.IsNullOrEmpty(Activity_One) && string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Check A Score For Activity-1\n";
                }
                else
                {
                    activity_one_score = value;
                }
            }
        }


        // Public variable for activiy two
        public string Activity_Two
        {
            get { return activity_two; }
            set
            {
  
                    activity_two = value;
                
            }
        }

        // Public variable for activiy two score
        public string Activity_Two_Score
        {
            get { return activity_two_score; }
            set
            {
                if (!string.IsNullOrEmpty(Activity_Two) && string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Check A Score For Activity-2\n";
                }
                else
                {
                    activity_two_score = value;
                }
            }
        }


        // Public variable for activiy three
        public string Activity_Three
        {
            get { return activity_three; }
            set
            {
                    activity_three = value;
                
            }
        }

        // Public variable for activiy three score
        public string Activity_Three_Score
        {
            get { return activity_three_score; }
            set
            {
                if (!string.IsNullOrEmpty(Activity_Three) && string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Check A Score For Activity-3\n";
                }
                else
                {
                    activity_three_score = value;
                }
            }
        }


        // Public variable for patients goals for treatment
        public string Patient_Goals
        {
            get { return patient_goals; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Enter the patients goal for receiving treatment\n";
                }
                else
                {
                    patient_goals = value;
                }
            }
        }

      

        // Default Constructor
        public PatientGoals()
        {
            //Start by giving feedback an empty string
            //feedback = "";
            activity_one = "";
            activity_two = "";
            activity_three = "";
            activity_one_score = "";
            activity_two_score = "";
            activity_three_score = "";
            patient_goals = "";
            feedback = "";
    }

        // Overloaded Constructor
        public PatientGoals(int patientID, string activity_one, string activity_two, string activity_three, string activity_one_score, string activity_two_score, string activity_three_score, string patient_goals)
        {
            //this.Name = name;
            feedback = "";
            PatientID = patientID;
            Activity_One = activity_one;
            Activity_Two = activity_two;
            Activity_Three = activity_three;
            Activity_One_Score = activity_one_score;
            Activity_Two_Score = activity_two_score;
            Activity_Three_Score = activity_three_score;
            Patient_Goals = patient_goals;
        }

        // Adding a record
        public virtual string AddRecord(OleDbConnection conn)
        {
            string strFeedback = "";


            // SQL command to add a record to the Patient Goals table
            string strSQL = "INSERT INTO Patient_Goals (patient_id, activity1, activity1_score, activity2, activity2_score, activity3, activity3_score, goal_date, patient_goals)" +
                " VALUES (@PatientID, @ActivityOne, @Activity1Score, @Activity2, @Activity2Score, @Activity3, @Activity3Score, @GoalDate, @PatientGoals);";

            //// creating database connection 
            //OleDbConnection conn = new OleDbConnection();
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
            comm.Parameters.AddWithValue(@"ActivityOne", Activity_One);
            comm.Parameters.AddWithValue(@"Activity1Score", Activity_One_Score);
            comm.Parameters.AddWithValue(@"Activity2", Activity_Two);
            comm.Parameters.AddWithValue(@"Activity2Score", Activity_Two_Score);
            comm.Parameters.AddWithValue(@"Activity3", Activity_Three);
            comm.Parameters.AddWithValue(@"Activity3Score", Activity_Three_Score);
            DateTime date = DateTime.Now;
            string shortDateStr = date.ToShortDateString();
            DateTime shortDate = Convert.ToDateTime(shortDateStr);
            comm.Parameters.AddWithValue(@"GoalDate", shortDate);
            comm.Parameters.AddWithValue(@"PatientGoals", Patient_Goals);
          

            try
            {
                // open a connection to the database
                conn.Open();

                // Giving strFeedback the number of records added
                strFeedback = comm.ExecuteNonQuery().ToString();

                // close the database
                conn.Close();
            }
            catch (Exception err)
            {
                strFeedback = "ERROR: " + err.Message;
            }
            return strFeedback;
        } // End of AddRecord


        // Find one patient goals method for most recently updated goals
        // Returns a data reader filled with all the data of one patient
        public OleDbDataReader FindPatientGoals(OleDbConnection conn, int patientID)
        {
            string strFeedback = "";
            OleDbCommand comm = new OleDbCommand();

            // Connection string to be used
            //string strConn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;";

            //SQL Command string to pull up one Patients Data
            string strSQL = "SELECT activity1, activity1_score, activity2, activity2_score, activity3, activity3_score, goal_date, patient_goals FROM Patient_Goals WHERE patient_id = @PID AND goal_id = (SELECT MAX(goal_id) FROM Patient_Goals)";

            // Set the connection string
            //conn.ConnectionString = strConn;

            // Give command object info it needs
            comm.Connection = conn;
            comm.CommandText = strSQL;
            comm.Parameters.AddWithValue("@PID", patientID);

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


    }
}
