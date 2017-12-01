using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClinic
{
    class VisitInfo
    {
        /* TODO'S ~~~
         * 1- Private variables -- DONE
         * 2- Public facing variables -- DONE
         * 3- Default Constructor -- DONE
         * 4- Overloaded Constructor -- DONE
         * 5- Add Visit Information to DB -- UNDER CONSTRUCTION
         * 6- Find Visit Infor ??
         * 7- Update Visit Information to DB ??
         * */

        // Private variables only the class can access.
        // Visit Info variables
        private int patientID;
        /*
         * Provider ID will just be a string correct?
         * 
         * */
        private string providerID;
        private string chiefComplaint;
        private string diagnosis;
        private string medicalHistory;
        private string medications;
        private string subjective;
        private string objective;
        private string ptGoals;
        private string treatmentPlan;
        private string evaluation;
        private string constantAttendance;
        private string theraputicProcedures;
        private string theraputicProcedures2;
        private string functionalLimitations;
        private string physicalTherapyDiagnosis;
        private string followUpTreatment;
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

                if (string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Enter ProviderID\n";
                }
                else
                {
                    providerID = value;
                }

            }
        }

        // Public variable for Chief Complaint
        public string ChiefComplaint
        {
            get { return chiefComplaint; }
            set { chiefComplaint = value; }
        }

        // Public variable for Diagnosis
        public string Diagnosis
        {
            get { return diagnosis; }
            set { diagnosis = value; }
        }

        // Public variable for Medical History
        public string MedicalHistory
        {
            get { return medicalHistory; }
            set { medicalHistory = value; }
        }

        // Public variable for Medications
        public string Medications
        {
            get { return medications; }
            set { medications = value; }
        }

        // Public variable for Subjective
        public string Subjective
        {
            get { return subjective; }
            set { subjective = value; }
        }

        // Public variable for Objective
        public string Objective
        {
            get { return objective; }
            set { objective = value; }
        }

        // Public variable for PT Goals
        public string PTGoals
        {
            get { return ptGoals; }
            set { ptGoals = value; }
        }

        // Public variable for Treatment Plan
        public string TreatmentPlan
        {
            get { return treatmentPlan; }
            set { treatmentPlan = value; }
        }

        // Public variable for Evaluation
        public string Evaluation
        {
            get { return evaluation; }
            set
            {

                if (value.Equals("Select One") || string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Select an Evaluation\n";
                }
                else
                {
                    evaluation = value;
                }
            }
        }

        // Public variable for Constant Attendance
        public string ConstantAttendance
        {
            get { return constantAttendance; }
            set
            {

                if (value.Equals("Select One") || string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Select a Constant Attendance\n";
                }
                else
                {
                    constantAttendance = value;
                }
            }
        }

        // Public variable for Theraputic Procedures
        public string TheraputicProcedures
        {
            get { return theraputicProcedures; }
            set
            {

                if (value.Equals("Select One") || string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Select a Theraputic Procedure\n";
                }
                else
                {
                    theraputicProcedures = value;
                }
            }
        }

        // Public variable for Theraputic Procedures Second Portion
        public string TheraputicProcedures2
        {
            get { return theraputicProcedures2; }
            set
            {

                if (value.Equals("Select One") || string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Specify a CPT 97139 Theraputic Procedure\n";
                }
                else
                {
                    theraputicProcedures2 = value;
                }
            }
        }

        // Public variable for Functional Limitations
        public string FunctionalLimitations
        {
            get { return functionalLimitations; }
            set { functionalLimitations = value; }
        }

        // Public variable for Physical Therapy Diagnosis
        public string PhysicalTherapyDiagnosis
        {
            get { return physicalTherapyDiagnosis; }
            set { physicalTherapyDiagnosis = value; }
        }

        // Public variable for Follow Up Treatment
        public string FollowUpTreatment
        {
            get { return followUpTreatment; }
            set { followUpTreatment = value; }
        }

        // Public variable for Visit Date
        public DateTime VisitDate
        {
            get { return visitDate; }
            set { visitDate = value; }
        }

        // Default Constructor
        public VisitInfo()
        {
            chiefComplaint = "";
            diagnosis = "";
            medicalHistory = "";
            medications = "";
            subjective = "";
            objective = "";
            ptGoals = "";
            treatmentPlan = "";
            functionalLimitations = "";
            physicalTherapyDiagnosis = "";
            followUpTreatment = ""; // Will need to be fixed if this is not a text box
            feedback = "";
        }

        // Overloaded Constructor
        public VisitInfo(int patientID, string providerID, DateTime visitDate, string chiefComplaint, string diagnosis, string medicalHistory, string medications, string subjective, string objective, string ptGoals, string treatmentPlan, string evaluation, string constantAttendance, string theraputicProcedures, string theraputicProcedures2, string functionalLimitations, string physicalTherapyDiagnosis, string followUpTreatment)
        {
            feedback = "";
            PatientID = patientID;
            ProviderID = providerID;
            VisitDate = visitDate;
            ChiefComplaint = chiefComplaint;
            Diagnosis = diagnosis;
            MedicalHistory = medicalHistory;
            Medications = medications;
            Subjective = subjective;
            Objective = objective;
            PTGoals = ptGoals;
            TreatmentPlan = treatmentPlan;
            Evaluation = evaluation;
            ConstantAttendance = constantAttendance;
            TheraputicProcedures = theraputicProcedures;
            TheraputicProcedures2 = theraputicProcedures2;
            FunctionalLimitations = functionalLimitations;
            PhysicalTherapyDiagnosis = physicalTherapyDiagnosis;
            FollowUpTreatment = followUpTreatment;
        }

        // Adding the first visit to the DB
        public virtual int AddVisit()
        {
            string strFeedback = "";
            int success = 0;

            // SQL command to add a record to the Patient_Visit table
            string strSQL = "INSERT INTO Patient_Visit (patient_id, provider_id, visit_date, chief_complaint, diagnosis, medical_history, medications, subjective, objective, pt_goals, treatment_plan, evaluation, constant_attendance, theraputic_procedures, theraputic_procedures2, functional_limitations, pt_diagnosis, followup_treatment)" +
                " VALUES (@PatientID, @ProviderID, @VisitDate, @ChiefComplaint, @Diagnosis, @MedicalHistory, @Medications, @Subjective, @Objective, @PTGoals, @TreatmentPlan, @Evaluation, @ConstantAttendance, @TheraputicProcedures, @TheraputicProcedures2, @FunctionalLimitations, @PhysicalTherapyDiagnosis, @FollowUpTreatment);";

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
            comm.Parameters.AddWithValue(@"VisitDate", VisitDate).ToString();
            comm.Parameters.AddWithValue(@"ChiefComplaint", ChiefComplaint);
            comm.Parameters.AddWithValue(@"Diagnosis", Diagnosis);
            comm.Parameters.AddWithValue(@"MedicalHistory", MedicalHistory);
            comm.Parameters.AddWithValue(@"Medications", Medications);
            comm.Parameters.AddWithValue(@"Subjective", Subjective);
            comm.Parameters.AddWithValue(@"Objective", Objective);
            comm.Parameters.AddWithValue(@"PTGoals", PTGoals);

            comm.Parameters.AddWithValue(@"TreatmentPlan", TreatmentPlan);
            comm.Parameters.AddWithValue(@"Evaluation", Evaluation);

            comm.Parameters.AddWithValue(@"ConstantAttendance", ConstantAttendance);
            comm.Parameters.AddWithValue(@"TheraputicProcedures", TheraputicProcedures);
            comm.Parameters.AddWithValue(@"TheraputicProcedures2", TheraputicProcedures2);
            comm.Parameters.AddWithValue(@"FunctionalLimitations", FunctionalLimitations);
            comm.Parameters.AddWithValue(@"PhysicalTherapyDiagnosis", PhysicalTherapyDiagnosis);
            comm.Parameters.AddWithValue(@"FollowUpTreatment", FollowUpTreatment);


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
        } // End of AddVisit

    } // End of Visit Info Class
}
