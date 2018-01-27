using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClinic
{
    class VisitInfo
    {
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
        private string durableMedicalEquipment;
        private string medications;
        private string subjective;
        private string objective;
        private string ptGoals;
        private string treatmentPlan;
        private string dmeNeeds;
        private string evaluation;
        private string constantAttendance;
        private string therapeuticProcedures;
        private string therapeuticProcedures2;
        private string functionalLimitations;
        private string assessment;
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

        // Public variable for Chief Complaint
        public string ChiefComplaint
        {
            get { return chiefComplaint; }
            set
            {
                chiefComplaint = value;
                //if (string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Enter Chief Complaint\n";
                //}
                //else
                //{
                //    chiefComplaint = value;
                //}
            }
        }

        // Public variable for Diagnosis
        public string Diagnosis
        {
            get { return diagnosis; }
            set
            {
                diagnosis = value;
                //if (string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Enter a Diagnosis\n";
                //}
                //else
                //{
                //    diagnosis = value;
                //}
            }
        }

        // Public variable for Medical History
        public string MedicalHistory
        {
            get { return medicalHistory; }
            set
            {
                medicalHistory = value;
                //if (string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Enter Medical History\n";
                //}
                //else
                //{
                //    medicalHistory = value;
                //}
            }
        }

        // Public variable for DurableMedicalEquipment
        public string DurableMedicalEquipment
        {
            get { return durableMedicalEquipment; }
            set { durableMedicalEquipment = value; }
        }

        // Public variable for Medications
        public string Medications
        {
            get { return medications; }
            set
            {
                medications = value;
                //if (string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Enter Medications\n";
                //}
                //else
                //{
                //    medications = value;
                //}
            }
        }

        // Public variable for Subjective
        public string Subjective
        {
            get { return subjective; }
            set
            {
                subjective = value;
                //if (string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Enter a Subjective\n";
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

        // Public variable for PT Goals
        public string PTGoals
        {
            get { return ptGoals; }
            set
            {
                ptGoals = value;
                //if (string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Enter PT Goals\n";
                //}
                //else
                //{
                //    ptGoals = value;
                //}
            }
        }

        // Public variable for Treatment Plan
        public string TreatmentPlan
        {
            get { return treatmentPlan; }
            set
            {
                treatmentPlan = value;
                //if (string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Enter Treatment Plan\n";
                //}
                //else
                //{
                //    treatmentPlan = value;
                //}
            }
        }

        // Public variable for DMENeeds
        public string DMENeeds
        {
            get { return dmeNeeds; }
            set { dmeNeeds = value; }
        }

        // Public variable for Evaluation
        public string Evaluation
        {
            get { return evaluation; }
            set
            {
                evaluation = value;
                //if (value.Equals("Select One") || string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Select an Evaluation\n";
                //}
                //else
                //{
                //    evaluation = value;
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

        // Public variable for Theraputic Procedures Second Portion
        public string TherapeuticProcedures2
        {
            get { return therapeuticProcedures2; }
            set
            {
                therapeuticProcedures2 = value;
                /*   Commenting out until we find out actual information on what will be in it
                if (value.Equals("Select One") || string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Specify a CPT 97139 Theraputic Procedure\n";
                }
                else
                {
                    theraputicProcedures2 = value;
                }*/
            }
        }

        // Public variable for Functional Limitations
        public string FunctionalLimitations
        {
            get { return functionalLimitations; }
            set
            {
                functionalLimitations = value;
                //if (string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Enter Functional Limitations\n";
                //}
                //else
                //{
                //    functionalLimitations = value;
                //}
            }
        }

        // Public variable for Assessment
        public string Assessment
        {
            get { return assessment; }
            set { assessment = value; }
        }

        // Public variable for Physical Therapy Diagnosis
        public string PhysicalTherapyDiagnosis
        {
            get { return physicalTherapyDiagnosis; }
            set
            {
                physicalTherapyDiagnosis = value;
                //if (string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Enter Physical Therapy Diagnosis\n";
                //}
                //else
                //{
                //    physicalTherapyDiagnosis = value;
                //}
            }
        }

        // Public variable for Follow Up Treatment
        public string FollowUpTreatment
        {
            get { return followUpTreatment; }
            set
            {
                followUpTreatment = value;

                //if (string.IsNullOrEmpty(value))
                //{
                //    feedback += "Error: Enter Follow Up Treatment\n";
                //}
                //else
                //{
                //    followUpTreatment = value;
                //}
            }
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
            durableMedicalEquipment = "";
            medications = "";
            subjective = "";
            objective = "";
            ptGoals = "";
            treatmentPlan = "";
            dmeNeeds = "";
            functionalLimitations = "";
            assessment = "";
            physicalTherapyDiagnosis = "";
            followUpTreatment = ""; // Will need to be fixed if this is not a text box
            feedback = "";
        }

        // Overloaded Constructor
        public VisitInfo(int patientID, string providerID, DateTime visitDate, string chiefComplaint, string diagnosis, string medicalHistory, string durableMedicalEquipment, string medications, string subjective, string objective, string ptGoals, string treatmentPlan, string dmeNeeds, string evaluation, string constantAttendance, string therapeuticProcedures, string therapeuticProcedures2, string functionalLimitations, string assessment, string physicalTherapyDiagnosis, string followUpTreatment)
        {
            feedback = "";
            PatientID = patientID;
            ProviderID = providerID;
            VisitDate = visitDate;
            ChiefComplaint = chiefComplaint;
            Diagnosis = diagnosis;
            MedicalHistory = medicalHistory;
            DurableMedicalEquipment = durableMedicalEquipment;
            Medications = medications;
            Subjective = subjective;
            Objective = objective;
            PTGoals = ptGoals;
            TreatmentPlan = treatmentPlan;
            DMENeeds = dmeNeeds;
            Evaluation = evaluation;
            ConstantAttendance = constantAttendance;
            TherapeuticProcedures = therapeuticProcedures;
            TherapeuticProcedures2 = therapeuticProcedures2;
            FunctionalLimitations = functionalLimitations;
            Assessment = assessment;
            PhysicalTherapyDiagnosis = physicalTherapyDiagnosis;
            FollowUpTreatment = followUpTreatment;
        }

        // Adding the first visit to the DB
        public virtual int AddVisit()
        {
            string strFeedback = "";
            int success = 0;

            // SQL command to add a record to the Patient_Visit table
            string strSQL = "INSERT INTO Patient_Visit (patient_id, provider_id, visit_date, chief_complaint, diagnosis, medical_history, durable_medical_equipment, medications, subjective, objective, pt_goals, treatment_plan, dme_needs, evaluation, constant_attendance, therapeutic_procedures, therapeutic_procedures2, functional_limitations, assessment, pt_diagnosis, followup_treatment)" +
                " VALUES (@PatientID, @ProviderID, @VisitDate, @ChiefComplaint, @Diagnosis, @MedicalHistory, @DurableMedicalEquipment, @Medications, @Subjective, @Objective, @PTGoals, @TreatmentPlan, @DMENeeds, @Evaluation, @ConstantAttendance, @TherapeuticProcedures, @TherapeuticProcedures2, @FunctionalLimitations, @Assessment, @PhysicalTherapyDiagnosis, @FollowUpTreatment);";

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
            comm.Parameters.AddWithValue(@"DurableMedicalEquipment", DurableMedicalEquipment);
            comm.Parameters.AddWithValue(@"Medications", Medications);
            comm.Parameters.AddWithValue(@"Subjective", Subjective);
            comm.Parameters.AddWithValue(@"Objective", Objective);
            comm.Parameters.AddWithValue(@"PTGoals", PTGoals);

            comm.Parameters.AddWithValue(@"TreatmentPlan", TreatmentPlan);
            comm.Parameters.AddWithValue(@"DMENeeds", DMENeeds);
            comm.Parameters.AddWithValue(@"Evaluation", Evaluation);

            comm.Parameters.AddWithValue(@"ConstantAttendance", ConstantAttendance);
            comm.Parameters.AddWithValue(@"TherapeuticProcedures", TherapeuticProcedures);
            comm.Parameters.AddWithValue(@"TherapeuticProcedures2", TherapeuticProcedures2);
            comm.Parameters.AddWithValue(@"FunctionalLimitations", FunctionalLimitations);
            comm.Parameters.AddWithValue(@"Assessment", Assessment);
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


        // Find Patient Visit Info  method
        // Returns a data reader filled with all the data of the patients initial visit
        public OleDbDataReader FindOnePatientVisit(OleDbConnection conn, int intPID)
        {
            string strFeedback = "";
            OleDbCommand comm = new OleDbCommand();

            // Connection string to be used
            //string strConn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;";

            //SQL Command string to pull up one Patients Data
            // patient_id, provider_id, visit_date, chief_complaint, diagnosis, medical_history, durable_medical_equipment, medications, subjective, objective, pt_goals, treatment_plan, dme_needs, evaluation, constant_attendance, therapeutic_procedures, therapeutic_procedures2, functional_limitations, assessment, pt_diagnosis, followup_treatment 
            string strSQL = "SELECT * FROM Patient_Visit WHERE patient_id = @PID;";

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
        } // End of FindOnePatientVisit


        // Adding the first visit to the DB
        public virtual int UpdateVisit()
        {
            string strFeedback = "";
            int success = 0;

            // SQL command to add a record to the Patient_Visit 

            string strSQL = "UPDATE Patient_Visit SET provider_id = @ProviderID, visit_date = @VisitDate, chief_complaint = @ChiefComplaint," +
                 "diagnosis = @Diagnosis, medical_history = @MedicalHistory, durable_medical_equipment = @DurableMedicalEquipment, medications = @Medications, subjective = @Subjective," +
                 "objective = @Objective, pt_goals = @PTGoals, treatment_plan = @TreatmentPlan, dme_needs = @, evaluation = @Evaluation," +
                 "constant_attendance = @ConstantAttendance, therapeutic_procedures = @TherapeuticProcedures, therapeutic_procedures2 = @TherapeuticProcedures2, functional_limitations = @FunctionalLimitations," +
                 "assessment = @Assessment, pt_diagnosis = @PhysicalTherapyDiagnosis, followup_treatment @FollowUpTreatment" + 
                 " WHERE patient_id = @PatientID;";
   
 
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
            comm.Parameters.AddWithValue(@"VisitDate", VisitDate).ToString();
            comm.Parameters.AddWithValue(@"ChiefComplaint", ChiefComplaint);
            comm.Parameters.AddWithValue(@"Diagnosis", Diagnosis);
            comm.Parameters.AddWithValue(@"MedicalHistory", MedicalHistory);
            comm.Parameters.AddWithValue(@"DurableMedicalEquipment", DurableMedicalEquipment);
            comm.Parameters.AddWithValue(@"Medications", Medications);
            comm.Parameters.AddWithValue(@"Subjective", Subjective);
            comm.Parameters.AddWithValue(@"Objective", Objective);
            comm.Parameters.AddWithValue(@"PTGoals", PTGoals);

            comm.Parameters.AddWithValue(@"TreatmentPlan", TreatmentPlan);
            comm.Parameters.AddWithValue(@"DMENeeds", DMENeeds);
            comm.Parameters.AddWithValue(@"Evaluation", Evaluation);

            comm.Parameters.AddWithValue(@"ConstantAttendance", ConstantAttendance);
            comm.Parameters.AddWithValue(@"TherapeuticProcedures", TherapeuticProcedures);
            comm.Parameters.AddWithValue(@"TherapeuticProcedures2", TherapeuticProcedures2);
            comm.Parameters.AddWithValue(@"FunctionalLimitations", FunctionalLimitations);
            comm.Parameters.AddWithValue(@"Assessment", Assessment);
            comm.Parameters.AddWithValue(@"PhysicalTherapyDiagnosis", PhysicalTherapyDiagnosis);
            comm.Parameters.AddWithValue(@"FollowUpTreatment", FollowUpTreatment);
            comm.Parameters.AddWithValue(@"PatientID", PatientID);


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
        } // End of UpdateVisit

    } // End of Visit Info Class
}
