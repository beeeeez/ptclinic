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
        StringBuilder appointmentString;
        string patientName;

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
            patientName = patientDetails.Fname + " " + patientDetails.Lname;

            FillAppointmentType();
            FillAppointmentAddress();

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

        public void FillAppointmentAddress()
        {

            cbAppAddress.Items.Insert(0, "Select One");
            cbAppAddress.Items.Add("60 Stamp Farm Rd Cranston, RI 02921");
            cbAppAddress.Items.Add("665 Dyer Ave Cranston, RI 02920");
            cbAppAddress.Items.Add("1240 Park Avenue Cranston RI 02910");
            cbAppAddress.SelectedIndex = 0;

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

            Appointment newAppointment = new Appointment();

            newAppointment.PatientID = patientID;
            newAppointment.AppointmentDate = dtpAppDate.Value;
            newAppointment.AppointmentTime = tpAppTime.Text;
            newAppointment.AppointmentType = cbAppType.Text;
            newAppointment.AppointmentAddress = cbAppAddress.Text;

            if (newAppointment.Feedback.Contains("Error:"))
            {
                lblFeedback.Text = newAppointment.Feedback;
            }
            else
            {
                lblFeedback.Text = "";

                using (OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
                {

                    int dbSuccess = 0;

                    dbSuccess = newAppointment.AddRecord(connection);

                    if (dbSuccess == 1)
                    {
                        myTimer.Interval = 5000;
                        myTimer.Start();
                        panelAppMessage.BackColor = Color.FromArgb(0, 192, 0);
                        panelAppMessage.Visible = true;
                        lblDBFeedback.Text = "Appointment Saved";
                        btnPrintAppCopy.Visible = true;

                        // On Success build print string for appointments
                        appointmentString = new StringBuilder();

                  
                        if (cbAppAddress.Text.Equals("60 Stamp Farm Rd, Cranston, RI 02921"))
                        {
                            appointmentString.AppendLine("Access Point RI");
                            appointmentString.AppendLine("60 Stamp Farm Rd");
                            appointmentString.AppendLine(" Cranston, RI 02921");
                            appointmentString.AppendLine("Phone: (401) 942 - 3445");
                        }
                        else if (cbAppAddress.Text.Equals("1240 Park Avenue Cranston RI 02910"))
                        {
                            appointmentString.AppendLine("Access Point RI");
                            appointmentString.AppendLine("1240 Park Avenue");
                            appointmentString.AppendLine(" Cranston, RI 02910");
                            appointmentString.AppendLine("Phone: (401) 228 - 3940");
                        }
                        else
                        {
                            appointmentString.AppendLine("Cornerstone School");
                            appointmentString.AppendLine("665 Dyer Ave");
                            appointmentString.AppendLine("Cranston, RI 02920");
                            appointmentString.AppendLine("Phone: (401) 942-2388");                      
                        }
                        
                        appointmentString.AppendLine("\n\n\n");
                        appointmentString.AppendLine();
                        appointmentString.AppendLine("Patient ID: " + patientID);
                        appointmentString.AppendLine(patientName);
                        appointmentString.AppendLine();
                        appointmentString.AppendLine("Date: " + newAppointment.AppointmentDate.ToLongDateString());
                        appointmentString.AppendLine("Time: " + newAppointment.AppointmentTime);
                        appointmentString.AppendLine("Visit Type: " + newAppointment.AppointmentType);


                    }
                    else
                    {
                        myTimer.Interval = 5000;
                        myTimer.Start();
                        panelAppMessage.BackColor = Color.Red;
                        panelAppMessage.Visible = true;
                        lblDBFeedback.Text = "Appointment Was NOT Saved";
                    }

                }

            }

        }


        private void printAppointment_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            using (Font font1 = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Point))
            {

                Rectangle rect1 = new Rectangle(100, 100, 650, 25);
                StringFormat SF = new StringFormat();
                SF.Alignment = StringAlignment.Center;
                SF.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString("Physical Therapy Appointment", font1, Brushes.Black, rect1, SF);
                e.Graphics.DrawRectangle(Pens.Black, rect1);


                Rectangle rect2 = new Rectangle(100, 320, 650, 25);
                StringFormat SF2 = new StringFormat();
                SF2.Alignment = StringAlignment.Center;
                SF2.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString("Appointment Details", font1, Brushes.Black, rect2, SF2);
                e.Graphics.DrawRectangle(Pens.Black, rect2);

            }

            e.Graphics.DrawString(appointmentString.ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new PointF(100, 160));

        }


        private void btnPrintAppCopy_Click(object sender, EventArgs e)
        {
            printDialog.Document = printAppointment;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printAppointment.Print();
            }

            // !!! To view print layout uncomment this

            //if (printPreviewDialog.ShowDialog() == DialogResult.OK)
            //{
            //    printAppointment.Print();
            //}

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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dtpAppDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tpAppTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cbAppType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void cbAppAddress_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void appointmentSearchbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
