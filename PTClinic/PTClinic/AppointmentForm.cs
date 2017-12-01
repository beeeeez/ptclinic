using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTClinic
{
    public partial class AppointmentForm : Form
    {
        private Form PatientProfile;
        private int patientID;

        public AppointmentForm()
        {
            InitializeComponent();
        }

        public AppointmentForm(Form patientProfile, int patientID, PatientInfo patientDetails)
        {

            InitializeComponent();

            this.PatientProfile = patientProfile;
            PatientProfile.Hide();

            this.patientID = patientID;

            lblPatientID.Text = patientID.ToString();
            lblPatientName.Text = patientDetails.Fname;

            FillAppointmentType();

            // Format time picker
            tpAppTime.Format = DateTimePickerFormat.Custom;
            tpAppTime.CustomFormat = "hh:mm tt";

        }

        public void FillAppointmentType()
        {

            cbAppType.Items.Insert(0, "Select One");
            cbAppType.Items.Add("Initial Visit");
            cbAppType.Items.Add("Follow-Up");
            cbAppType.Items.Add("Re-assessment");
            cbAppType.SelectedIndex = 0;

        }

        private void btnScheduleAppointment_Click(object sender, EventArgs e)
        {
            lblFeedback.Text = "";
            int success = 0;
           
            if (cbAppType.Text.Equals("Select One"))
            {
                lblFeedback.Text += "Please select appointment type\n";
            }
            else
            {
                lblFeedback.Text = "";

                using (OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
                {
                    string appointmentSQL = "INSERT INTO Appointments ([patient_id], [appointment_date], [appointment_time], [appointment_type]) VALUES (@patientID, @app_date, @app_time, @app_type);";


                    OleDbCommand comm = new OleDbCommand();
                    comm.CommandText = appointmentSQL; // Commander knows what to say
                    comm.Connection = connection; // Heres the connection

                    // Get Appointment Short Date for DB
                    string shortDateStr = dtpAppDate.Value.ToString();
                    DateTime shortDate = Convert.ToDateTime(shortDateStr);
                    string timeStr = dtpAppDate.Value.ToString("hh:mm tt");
             
                    comm.Parameters.AddWithValue("@patientID", patientID);
                    comm.Parameters.AddWithValue("@app_date", shortDate);
                    comm.Parameters.AddWithValue("@app_time", timeStr);
                    comm.Parameters.AddWithValue("@app_type", cbAppType.Text);

                    try
                    {
                        // open a connection to the database
                        connection.Open();

                        // Giving strFeedback the number of records added
                        //strFeedback = comm.ExecuteNonQuery().ToString() + " Patient Info Added";
                        success = comm.ExecuteNonQuery();

                        if (success == 1)
                        {
                            lblDBFeedback.Text = "Appointment Saved";
                        }
                        else
                        {
                            lblDBFeedback.Text = "Appointment Was NOT Saved";
                        }
                    }
                    catch (Exception err)
                    {
                        lblFeedback.Text = "ERROR: " + err.Message;
                    }
                    finally
                    {
                        connection.Close();
                    }


                }

            }

           


        }



        private void btnPrintAppCopy_Click(object sender, EventArgs e)
        {

        }
    }
}
