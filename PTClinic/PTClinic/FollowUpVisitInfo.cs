using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClinic
{
    class FollowUpVisitInfo
    {
        // TODO -- functionality
        /* TODO'S ~~~
         * 1- Private variables -- DONE
         * 2- Public facing variables -- DONE
         * 3- Default Constructor
         * 4- Overloaded Constructor
         * 5- Add Follow Up Information to DB
         * */

        // Private variables only the class can access.
        // Follow Up Visit Info variables
        private int patientID;
        /*
         * Provider ID will just be a string correct?
         * 
         * */
        private string providerID;
        private string patientName;
        private string diagnosis;
        private string ptGoals;
        private string subjective;
        private string objective;
        private string supervisedModalities;
        private string constantAttendance;
        private string theraputicProcedures;
        private string theraputicProcedures2;
        private string assessment;
        private string plan;
        private Nullable<bool> reassessment;
        private Nullable<bool> referForDischarge;
        private string studentProvider;
        private DateTime studentProviderDate;
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

        // Public variable for Patient Name
        public string PatientName
        {
            get { return patientName; }
            set { patientName = value; }
        }

        // Public variable for Diagnosis
        public string Diagnosis
        {
            get { return diagnosis; }
            set { diagnosis = value; }
        }

        // Public variable for PT Goals
        public string PTGoals
        {
            get { return ptGoals; }
            set { ptGoals = value; }
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

        // Public variable for Supervised Modalities
        public string SupervisedModalities
        {
            get { return supervisedModalities; }
            set
            {

                if (value.Equals("Select One") || string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Select a Supervised Modality\n";
                }
                else
                {
                    supervisedModalities = value;
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

        // Public variable for Assessment
        public string Assessment
        {
            get { return assessment; }
            set { assessment = value; }
        }

        // Public variable for Plan
        public string Plan
        {
            get { return plan; }
            set { plan = value; }
        }

        // Public variable specifically for Reassessment
        public Nullable<bool> Reassessment
        {
            get { return reassessment; }
            set
            {
                if (value.Equals(null))
                {
                    feedback += "Error: Select Yes or No for Patient Re-assessment\n";
                }
                else
                {
                    reassessment = value;
                }

            }
        }

        // Public variable specifically for ReferForDischarge
        public Nullable<bool> ReferForDischarge
        {
            get { return referForDischarge; }
            set
            {
                if (value.Equals(null))
                {
                    feedback += "Error: Select Yes or No for Refer for discharge\n";
                }
                else
                {
                    referForDischarge = value;
                }

            }
        }

        // Public variable for Student Provider
        public string StudentProvider
        {
            get { return studentProvider; }
            set
            {

                if (string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Enter Student Provider\n";
                }
                else
                {
                    studentProvider = value;
                }

            }
        }

        // Public variable for Provider Name
        public string ProviderName
        {
            get { return providerName; }
            set
            {

                if (string.IsNullOrEmpty(value))
                {
                    feedback += "Error: Enter Provider Name\n";
                }
                else
                {
                    providerName = value;
                }

            }
        }

        // Public variable for Visit Date
        public DateTime VisitDate
        {
            get { return visitDate; }
            set { visitDate = value; }
        }

        // Public variable for Student Provider Date
        public DateTime StudentProviderDate
        {
            get { return studentProviderDate; }
            set { studentProviderDate = value; }
        }

        // Public variable for Provider Name Date
        public DateTime ProviderNameDate
        {
            get { return providerNameDate; }
            set { providerNameDate = value; }
        }

        /*
         * 
         * Constructors
         * 
         * and
         * 
         * Add to DB function needed
         * 
         * */

    } // End of FollowUpVisitInfo Class
}
