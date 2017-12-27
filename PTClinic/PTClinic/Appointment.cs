using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTClinic
{
    class Appointment
    {
        private int patientID;
        private DateTime appointmentDate;
        private string appointmentTime;
        private string appointmentType;
        protected string feedback;

        public virtual string Feedback
        {
            get { return feedback; }
        }

        public int PatientID
        {
            get { return patientID; }
            set { patientID = value; }
        }

        public DateTime AppointmentDate
        {
            get { return appointmentDate; }
            set
            {
                appointmentDate = value;
            }
        }

        public string AppointmentTime
        {
            get { return appointmentTime; }
            set { appointmentTime = value; }
        }

        public string AppointmentType
        {
            get { return appointmentType; }
            set { appointmentType = value; }
        }

        public Appointment()
        {

        }

        public Appointment(int patientID, DateTime appointmentDate, string appointmentTime, string appointmentType)
        {
            feedback = "";
            PatientID = patientID;
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;
            AppointmentType = appointmentType;
        }

        public virtual int AddRecord()
        {
            return 0;
        }
    }
}
