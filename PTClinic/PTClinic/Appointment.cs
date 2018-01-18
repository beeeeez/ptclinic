using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
        private string appointmentAddress;
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
                DateTime checkDate;

                bool valid = DateTime.TryParse(value.ToString(), out checkDate);
                if (valid && checkDate == DateTime.Today || checkDate < DateTime.Now)
                {
                    feedback += "Error: Appointment dates cannot be before today\n";
                }
                else
                {
                    appointmentDate = value;
                }
              
            }
        }

        public string AppointmentTime
        {
            get { return appointmentTime; }
            set
            {
                if (DateTime.Now.ToString("hh:mm tt").Equals(value))
                {
                    feedback += "Error: Appointment time must be selected\n";
                }
                else
                {
                    appointmentTime = value;
                }
             
            }
        }

        public string AppointmentType
        {
            get { return appointmentType; }
            set
            {
                if (value.Equals("Select One"))
                {
                    feedback += "Error: Please select appointment type\n";
                }
                else
                {
                    appointmentType = value;
                }
            }
        }

        public string AppointmentAddress
        {
            get { return appointmentAddress; }
            set
            {
                if (value.Equals("Select One"))
                {
                    feedback += "Error: Please select appointment address\n";
                }
                else
                {
                    appointmentAddress = value;
                }
            }
        }

        public Appointment()
        {
            feedback = "";
            appointmentTime = "";
            appointmentType = "";

        }

        public Appointment(int patientID, DateTime appointmentDate, string appointmentTime, string appointmentType, string appointmentAddress)
        {
            feedback = "";
            PatientID = patientID;
            AppointmentDate = appointmentDate;
            AppointmentTime = appointmentTime;
            AppointmentType = appointmentType;
            AppointmentAddress = appointmentAddress;
        }

        public virtual int AddRecord(OleDbConnection conn)
        {
            string strFeedback = "";
            int success = 0;

            string appointmentSQL = "INSERT INTO Appointments ([patient_id], [appointment_date], [appointment_time], [appointment_type], [appointment_address]) VALUES (@patientID, @app_date, @app_time, @app_type, @app_address);";


            OleDbCommand comm = new OleDbCommand();
            comm.CommandText = appointmentSQL; // Commander knows what to say
            comm.Connection = conn; // Heres the connection

            // Get Appointment Short Date for DB
            string shortDateStr = AppointmentDate.ToShortDateString();
            DateTime shortDate = Convert.ToDateTime(shortDateStr);
        

            comm.Parameters.AddWithValue("@patientID", PatientID);
            comm.Parameters.AddWithValue("@app_date", shortDate);
            comm.Parameters.AddWithValue("@app_time", AppointmentTime);
            comm.Parameters.AddWithValue("@app_type", AppointmentType);
            comm.Parameters.AddWithValue("@app_address", AppointmentAddress);

            try
            {
                // open a connection to the database
                conn.Open();

                // Giving strFeedback the number of records added
                //strFeedback = comm.ExecuteNonQuery().ToString() + " Patient Appointment Added";
                success = comm.ExecuteNonQuery();

            }
            catch (Exception err)
            {
                strFeedback = "ERROR: " + err.Message;
            }
            finally
            {
                conn.Close();
            }



            return success;
        }
    }
}
