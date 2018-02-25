using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClinic
{
    class FollowUpVisitInfo
    {
        // Private variables only the class can access.
        // Follow Up Visit Info variables
        private int patientID;
        private string providerID;
        private string patientName;
        //private string diagnosis;
        //private string ptGoals;
        private string subjective;
        private string objective;
        private string supervisedModalities;
        private string constantAttendance;
        private string therapeuticProcedures;
        private string assessment;
        private string plan;
        private Nullable<bool> reassessment;
        private string studentProviderName;
        private DateTime studentProviderNameDate;
        private string providerName;
        private DateTime providerNameDate;
        private DateTime visitDate;
        protected string feedback;


        // Creating the public variables that are the front end to the private variables
        public virtual string Feedback
        {
            get { return feedback; }
        }

        // Public variable for Patient ID
        public int PatientID
        {
            get { return patientID; }
            set { patientID = value; }
        }

        // Public variable for Provider ID
        public string ProviderID
        {
            get { return providerID; }
            set
            {
                providerID = value;
                //if (string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Enter ProviderID\n";
                //}
                //else
                //{
                //    providerID = value;
                //}

            }
        }

        // Public variable for Patient Name
        public string PatientName
        {
            get { return patientName; }
            set { patientName = value; }
        }

        // Public variable for Diagnosis
        //public string Diagnosis
        //{
        //    get { return diagnosis; }
        //    set
        //    {
        //        diagnosis = value;
        //        //if (string.IsNullOrEmpty(value))
        //        //{
        //        //    feedback += "Error: Enter a Diagnosis\n";
        //        //}
        //        //else
        //        //{
        //        //    diagnosis = value;
        //        //}

        //    }
        //}

        //// Public variable for PT Goals
        //public string PTGoals
        //{
        //    get { return ptGoals; }
        //    set
        //    {
        //        ptGoals = value;
        //        //if (string.IsNullOrEmpty(value))
        //        //{
        //        //    feedback += "Error: Enter PT Goals\n";
        //        //}
        //        //else
        //        //{
        //        //    ptGoals = value;
        //        //}

        //    }
        //}

        // Public variable for Subjective
        public string Subjective
        {
            get { return subjective; }
            set
            {
                subjective = value;
                //if (string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Enter an Objective\n";
                //}
                //else
                //{
                //    subjective = value;
                //}

            }
        }

        // Public variable for Objective
        public string Objective
        {
            get { return objective; }
            set
            {
                objective = value;
                //if (string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Enter an Objective\n";
                //}
                //else
                //{
                //    objective = value;
                //}

            }
        }

        // Public variable for Supervised Modalities
        public string SupervisedModalities
        {
            get { return supervisedModalities; }
            set
            {
                supervisedModalities = value;
                //if (value.Equals("Select One") || string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Select a Supervised Modality\n";
                //}
                //else
                //{
                //    supervisedModalities = value;
                //}
            }
        }

        // Public variable for Constant Attendance
        public string ConstantAttendance
        {
            get { return constantAttendance; }
            set
            {
                constantAttendance = value;
                //if (value.Equals("Select One") || string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Select a Constant Attendance\n";
                //}
                //else
                //{
                //    constantAttendance = value;
                //}
            }
        }

        // Public variable for Theraputic Procedures
        public string TherapeuticProcedures
        {
            get { return therapeuticProcedures; }
            set
            {
                therapeuticProcedures = value;
                //if (value.Equals("Select One") || string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Select a Theraputic Procedure\n";
                //}
                //else
                //{
                //    therapeuticProcedures = value;
                //}
            }
        }

        // Public variable for Assessment
        public string Assessment
        {
            get { return assessment; }
            set
            {
                assessment = value;
                //if (string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Enter an Assessment\n";
                //}
                //else
                //{
                //    assessment = value;
                //}

            }
        }

        // Public variable for Plan
        public string Plan
        {
            get { return plan; }
            set
            {
                plan = value;
                //if (string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Enter a Plan\n";
                //}
                //else
                //{
                //    plan = value;
                //}

            }
        }

        // Public variable specifically for Reassessment
        public Nullable<bool> Reassessment
        {
            get { return reassessment; }
            set
            {
                reassessment = value;
                ////if (value.Equals(null))
                ////{
                ////    feedback += "Error: Select Yes or No for Patient Re-assessment\n";
                ////}
                ////else
                ////{
                ////    reassessment = value;
                ////}

            }
        }

        // Public variable for Student Provider Name
        public string StudentProviderName
        {
            get { return studentProviderName; }
            set
            {
                studentProviderName = value;
                //if (string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Enter Student Provider\n";
                //}
                //else
                //{
                //    studentProviderName = value;
                //}

            }
        }

        // Public variable for Provider Name
        public string ProviderName
        {
            get { return providerName; }
            set
            {
                providerName = value;
                //if (string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Enter Provider Name\n";
                //}
                //else
                //{
                //    providerName = value;
                //}

            }
        }

        // Public variable for Visit Date
        public DateTime VisitDate
        {
            get { return visitDate; }
            set { visitDate = value; }
        }

        // Public variable for Student Provider Date
        public DateTime StudentProviderNameDate
        {
            get { return studentProviderNameDate; }
            set { studentProviderNameDate = value; }
        }

        // Public variable for Provider Name Date
        public DateTime ProviderNameDate
        {
            get { return providerNameDate; }
            set { providerNameDate = value; }
        }

        // Default Constructor
        public FollowUpVisitInfo()
        {
            //diagnosis = "";
            //ptGoals = "";
            subjective = "";
            objective = "";
            assessment = "";
            plan = "";
            studentProviderName = "";
            providerName = "";
            feedback = "";
        }

        // Adding the first visit to the DB
        public virtual int AddFollowUpVisit()
        {
            string strFeedback = "";
            int success = 0;

            // SQL command to add a record to the Patient_Visit table
            string strSQL = "INSERT INTO Patient_FollowUp_Visit (patient_id, provider_id, patient_name, subjective, objective, supervised_modalities, constant_attendance, therapeutic_procedures, assessment, plan, student_name, student_date, provider_name, provider_date, visit_date)" +
                " VALUES (@PatientID, @ProviderID, @PatientName, @Subjective, @Objective, @SupervisedModalities, @ConstantAttendance, @TherapeuticProcedures, @Assessment, @Plan, @StudentProviderName, @StudentProviderNameDate, @ProviderName, @ProviderNameDate, @VisitDate);";

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
            comm.Parameters.AddWithValue(@"ProviderID", ProviderID);
            comm.Parameters.AddWithValue(@"PatientName", PatientName);
            //comm.Parameters.AddWithValue(@"Diagnosis", Diagnosis);
            //comm.Parameters.AddWithValue(@"PTGoals", PTGoals);
            comm.Parameters.AddWithValue(@"Subjective", Subjective);
            comm.Parameters.AddWithValue(@"Objective", Objective);

            comm.Parameters.AddWithValue(@"SupervisedModalities", SupervisedModalities);
            comm.Parameters.AddWithValue(@"ConstantAttendance", ConstantAttendance);
            comm.Parameters.AddWithValue(@"TherapeuticProcedures", TherapeuticProcedures);

            comm.Parameters.AddWithValue(@"Assessment", Assessment);
            comm.Parameters.AddWithValue(@"Plan", Plan);
            comm.Parameters.AddWithValue(@"StudentProviderName", StudentProviderName);
            comm.Parameters.AddWithValue(@"StudentProviderNameDate", StudentProviderNameDate).ToString();
            comm.Parameters.AddWithValue(@"ProviderName", ProviderName);
            comm.Parameters.AddWithValue(@"ProviderNameDate", ProviderNameDate).ToString();

            comm.Parameters.AddWithValue(@"VisitDate", VisitDate).ToString();


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
        } // End of AddFollowUpVisit


        // Updating patient's follow up visit information
        public virtual int UpdateOneFUVisit()
        {
            string strFeedback = "";
            int success = 0;

            //string strSQL = "INSERT INTO Patient_FollowUp_Visit (patient_id, provider_id, patient_name, diagnosis, pt_goals, subjective, objective, supervised_modalities, constant_attendance, therapeutic_procedures, therapeutic_procedures2, assessment, plan, student_name, student_date, provider_name, provider_date, visit_date)" +
            //    " VALUES (@PatientID, @ProviderID, @PatientName, @Diagnosis, @PTGoals, @Subjective, @Objective, @SupervisedModalities, @ConstantAttendance, @TherapeuticProcedures, @TherapeuticProcedures2, @Assessment, @Plan, @StudentProviderName, @StudentProviderNameDate, @ProviderName, @ProviderNameDate, @VisitDate);";

            // SQL command to add a record to the Patients table
            string strSQL = "UPDATE Patient_FollowUp_Visit SET provider_id = @ProviderID, patient_name = @PatientName, subjective = @Subjective, objective = @Objective, supervised_modalities = @SupervisedModalities, constant_attendance = @ConstantAttendance, therapeutic_procedures = @TherapeuticProcedures, assessment = @Assessment, plan = @Plan, student_name = @StudentProviderName, student_date = @StudentProviderNameDate, provider_name = @ProviderName, provider_date = @ProviderNameDate, visit_date = @VisitDate" +
                " WHERE patient_id = @PatientID AND followup_visit_id = (SELECT MAX(followup_visit_id) FROM Patient_FollowUp_Visit);";

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
            comm.Parameters.AddWithValue(@"ProviderID", ProviderID);
            comm.Parameters.AddWithValue(@"PatientName", PatientName);
            //comm.Parameters.AddWithValue(@"Diagnosis", Diagnosis);
            //comm.Parameters.AddWithValue(@"PTGoals", PTGoals);
            comm.Parameters.AddWithValue(@"Subjective", Subjective);
            comm.Parameters.AddWithValue(@"Objective", Objective);

            comm.Parameters.AddWithValue(@"SupervisedModalities", SupervisedModalities);
            comm.Parameters.AddWithValue(@"ConstantAttendance", ConstantAttendance);
            comm.Parameters.AddWithValue(@"TherapeuticProcedures", TherapeuticProcedures);

            comm.Parameters.AddWithValue(@"Assessment", Assessment);
            comm.Parameters.AddWithValue(@"Plan", Plan);
            comm.Parameters.AddWithValue(@"StudentProviderName", StudentProviderName);
            comm.Parameters.AddWithValue(@"StudentProviderNameDate", StudentProviderNameDate).ToString();
            comm.Parameters.AddWithValue(@"ProviderName", ProviderName);
            comm.Parameters.AddWithValue(@"ProviderNameDate", ProviderNameDate).ToString();

            comm.Parameters.AddWithValue(@"VisitDate", VisitDate).ToString();
            comm.Parameters.AddWithValue(@"PatientID", PatientID);

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
        } // End of UpdateOneFUVisit


        // Find Patient Follow Up Visit Info  method
        // Returns a data reader filled with all the data of the patients follow up / re-assessment visit
        public OleDbDataReader FindOnePatientFUVisit(OleDbConnection conn, int intPID)
        {
            string strFeedback = "";
            OleDbCommand comm = new OleDbCommand();

            // Connection string to be used
            //string strConn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;";

            //SQL Command string to pull up one Patients Data
            string strSQL = "SELECT patient_id, provider_id, patient_name, subjective, objective, supervised_modalities, constant_attendance, therapeutic_procedures, assessment, plan, student_name, student_date, provider_name, provider_date, visit_date FROM Patient_FollowUp_Visit WHERE patient_id = @PID AND followup_visit_id = (SELECT MAX(followup_visit_id) FROM Patient_FollowUp_Visit);";

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
        } // End of FindOnePatientFUVisit

    } // End of FollowUpVisitInfo Class
}
