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
        private Form Admin;
        private Form Login;
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        public AppointmentForm()
        {
            InitializeComponent();
        }

        public AppointmentForm(Form patientProfile, Form adminForm, Form Login, int patientID, PatientInfo patientDetails)
        {

            InitializeComponent();

            myTimer.Tick += new System.EventHandler(myTimer_Tick);
            dtpAppDate.ValueChanged += new EventHandler(dtp_ValueChanged);
            tpAppTime.ValueChanged += new EventHandler(tp_ValueChanged);
            cbAppType.SelectedValueChanged += new EventHandler(cb_ValueChanged);

            this.PatientProfile = patientProfile;
            PatientProfile.Hide();
            this.Login = Login;
            this.Admin = adminForm;

            this.patientID = patientID;

            lblPatientID.Text = patientID.ToString();
            lblPatientName.Text = patientDetails.Fname + " " + patientDetails.Lname;

            FillAppointmentType();

            // Format time picker
            tpAppTime.Format = DateTimePickerFormat.Custom;
            tpAppTime.CustomFormat = "hh:mm tt";

            setButtonIcon();

        }

        // Setting the Icons for Logout and Home Buttons
        private void setButtonIcon()
        {
            btnLogOut.Image = Image.FromFile("..\\..\\Resources\\ic_power_settings_new_white_24dp_1x.png");
            btnBackHome.Image = Image.FromFile("..\\..\\Resources\\ic_home_white_24dp_1x.png");
            btnPrintAppCopy.Image = Image.FromFile("..\\..\\Resources\\ic_print_white_24dp_1x.png");
            btnBackToProfile.Image = Image.FromFile("..\\..\\Resources\\ic_arrow_back_white_24dp_1x.png");
        }

        public void FillAppointmentType()
        {

            cbAppType.Items.Insert(0, "Select One");
            cbAppType.Items.Add("Initial Visit");
            cbAppType.Items.Add("Follow-Up");
            cbAppType.Items.Add("Re-assessment");
            cbAppType.SelectedIndex = 0;

        }

        private void dtp_ValueChanged(object sender, System.EventArgs e)
        {
            DateTime checkDate;

            bool valid = DateTime.TryParse(dtpAppDate.Text, out checkDate);
            if (valid && checkDate == DateTime.Today || checkDate < DateTime.Now)
            {
                lblAppDate.ForeColor = Color.Red;
                lblAppDate.Text = "Pick A Date";
                lblAppDate.Refresh();
            }
            else
            {
                lblAppDate.ForeColor = Color.Black;
                lblAppDate.Text = dtpAppDate.Value.ToString("ddd MMMM d, yyyy");
                lblAppDate.Refresh();
            }

        }

        private void tp_ValueChanged(object sender, System.EventArgs e)
        {
            lblAppTime.ForeColor = Color.Black;
            lblAppTime.Text = tpAppTime.Value.ToString("hh:mm tt");
            lblAppTime.Refresh();
        }

        private void cb_ValueChanged(object sender, System.EventArgs e)
        {
            if (cbAppType.Text.Equals("Select One"))
            {
                lblAppType.ForeColor = Color.Red;
                lblAppType.Text = "Pick A Type ";
                lblAppType.Refresh();
            }
            else
            {
                lblAppType.ForeColor = Color.Black;
                lblAppType.Text = cbAppType.Text;
                lblAppType.Refresh();
            }

        }

        private void myTimer_Tick(object sender, System.EventArgs e)
        {
            panelAppMessage.Visible = false;
            myTimer.Stop();
        }



        private void btnScheduleAppointment_Click(object sender, EventArgs e)
        {
            lblFeedback.Text = "";
            int success = 0;

            DateTime checkDate;

            bool valid = DateTime.TryParse(dtpAppDate.Text, out checkDate);
            if (valid && checkDate == DateTime.Today || checkDate < DateTime.Now)
            {
                lblFeedback.Text += "Appointment dates cannot be before today\n";
            }
            else if (DateTime.Now.ToString("hh:mm tt").Equals(tpAppTime.Text))
            {
                lblFeedback.Text += "Appointment time must be selected\n";
            }
            else if (cbAppType.Text.Equals("Select One"))
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
                    string timeStr = tpAppTime.Text;

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
                            myTimer.Interval = 3000;
                            myTimer.Start();
                            panelAppMessage.BackColor = Color.FromArgb(0, 192, 0);
                            panelAppMessage.Visible = true;
                            lblDBFeedback.Text = "Appointment Saved";
                            btnPrintAppCopy.Visible = true;

                        }
                        else
                        {
                            myTimer.Interval = 3000;
                            myTimer.Start();
                            panelAppMessage.BackColor = Color.Red;
                            panelAppMessage.Visible = true;
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
            // TODO Print Copy of Appointment Scheduled

        }

        private void btnBackHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.Show();
        }

        private void btnBackToProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientProfile.Show();
        }
    }
}
