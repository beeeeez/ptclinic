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
using System.Drawing.Printing;

namespace PTClinic
{
    public partial class ViewPastVisitForm : Form
    {
        private int patientId;
        private string visitDate;
        private Form Admin;
        private Form Login;
        private string printString;
        private System.Drawing.Printing.PrintDocument docToPrint =
  new System.Drawing.Printing.PrintDocument();
        PrintPreviewDialog ugh = new PrintPreviewDialog();
        PrintDialog pd = new PrintDialog();

        public ViewPastVisitForm(int patientID, string visitDate, Form Admin, Form Login)
        {
            InitializeComponent();
            setButtonIcon();
   

            this.patientId = patientID;
            this.visitDate = visitDate;
            this.Admin = Admin;
            this.Login = Login;
            btnPrint1.Visible = true;
            lblPID.Text = patientId.ToString();
            DBCall();
            //MessageBox.Show("Patiend ID = " + patientID + "\n Visit Date: " + visitDate);
        }

        // Setting the Icons for Logout and Home Buttons
        private void setButtonIcon()
        {
            btnLogOut.Image = Image.FromFile("..\\..\\Resources\\ic_power_settings_new_white_24dp_1x.png");
            btnBackHome.Image = Image.FromFile("..\\..\\Resources\\ic_home_white_24dp_1x.png");
            btnBackToProfile.Image = Image.FromFile("..\\..\\Resources\\ic_arrow_back_white_24dp_1x.png");
            btnBackToSearch.Image = Image.FromFile("..\\..\\Resources\\ic_arrow_back_white_24dp_1x.png");
        }

        private void DBCall()
        {

            PatientInfo tempPatient = new PatientInfo();
            using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
            {
                // Gather info about this patient via the patient ID (intPID) passed from the search and store it in a data reader
                using (var dataReaderPatient = tempPatient.FindOnePatient(connection, patientId))
                {
                    while (dataReaderPatient.Read())
                    {
                        // Take the appropriate fields from the datareader
                        // and put them in proper labels

                        tbDiagnosis.Text = dataReaderPatient["medicalhistory_diagnosis"].ToString();

                    }
                }
            }


            // Create variable for a Patients initial Visit Information
            VisitInfo tempPatientVisit = new VisitInfo();

            using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
            {
                // Gather info about this patient via the patient ID (intPID) passed from the search and store it in a data reader
                using (var dataReaderPatientVisit = tempPatientVisit.FindOnePatientVisit(connection, patientId))
                {
                    while (dataReaderPatientVisit.Read())
                    {
                        // Take the appropriate fields from the datareader
                        // and put them in proper labels
                        tbProviderID.Text = dataReaderPatientVisit["provider_id"].ToString();

                        tbPTGoals.Text = dataReaderPatientVisit["pt_goals"].ToString();
                        var ptDiagnosis = dataReaderPatientVisit["pt_diagnosis"].ToString();

                        char[] splitChar = { '+' };
                        string[] diagnosisArray = null;
                        StringBuilder sb = new StringBuilder();

                        diagnosisArray = ptDiagnosis.Split(splitChar);

                        for (int i = 0; i < diagnosisArray.Length; i++)
                        {
                            sb.AppendLine("- " + diagnosisArray[i]);

                        }

                        tbPTDiagnosis.Text = sb.ToString();

                    }
                }
            } 

            using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
            {
                try
                {

                    string strSQL = "SELECT * FROM Patient_FollowUp_Visit WHERE patient_id = @PID AND visit_date = @VisitDate;";

                    connection.Open(); // open connection

                    OleDbCommand comm = new OleDbCommand();
                    comm.CommandText = strSQL; // Commander knows what to say
                    comm.Connection = connection; // Heres the connection
                    comm.Parameters.AddWithValue(@"PID", patientId);
                    comm.Parameters.AddWithValue(@"VisitDate", visitDate);

                    OleDbDataReader reader = comm.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // SET TEXT FIELDS TO reader["table_field"].toString()
                            lblPatientName.Text = reader["patient_name"].ToString();

                            // Take the appropriate fields from the datareader
                            // and put them in proper text boxes / selections
                            tbProviderID.Text = reader["provider_id"].ToString();
                            DateTime dos = Convert.ToDateTime(reader["visit_date"].ToString());
                            dtpDateOfService.Value = dos;

                            tbSubjective.Text = reader["subjective"].ToString();
                            tbObjective.Text = reader["objective"].ToString();
                            tbAssessment.Text = reader["assessment"].ToString();
                            tbPlan.Text = reader["plan"].ToString();
                            tbStudentProvider.Text = reader["student_name"].ToString();
                            tbProviderName.Text = reader["provider_name"].ToString();


                            //Drop downs
                            tbTherapeuticProcedures.Text = reader["therapeutic_procedures"].ToString();
                            tbTherapeuticProcedures2.Text = reader["therapeutic_procedures2"].ToString();
                            tbTherapeuticProcedures3.Text = reader["therapeutic_procedures3"].ToString();
                            // tbSupervisedModalities.Text = reader["supervised_modalities"].ToString();
                            //  tbConstantAttendance.Text = reader["constant_attendance"].ToString();
                        }
                    }
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.ToString());
                }
                finally
                {
                    connection.Close();
                }

            }

        }


        private void btnBackToSearch_Click(object sender, EventArgs e)
        {
            PastVisitSearchForm visitSearchForm = new PastVisitSearchForm(patientId, Admin, Login);
            this.Hide();
            visitSearchForm.Show();
        }

        private void btnBackToProfile_Click(object sender, EventArgs e)
        {
            Search newSearchForm = new Search(Admin, Login);
            PatientInformation newPatientForm = new PatientInformation(0, Admin, Login);
            PatientProfile newProfile = new PatientProfile(patientId, Admin, Login, newSearchForm, newPatientForm, false);
            this.Hide();
            newProfile.Show();
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

        private void btnPrint1_Click(object sender, EventArgs e)
        {
           printString += "Date of Service : " + dtpDateOfService.Text + "\n";
            printString += "Patient Name : " + lblPatientName.Text + "\n";
            printString += "Patient ID# : " + lblPID.Text + "\n\n";
            printString += "Provider ID# : " + tbProviderID.Text + "\n";
            printString += "Diagnosis : " + tbDiagnosis.Text + "\n";
            printString += "PT Goals : " + tbPTGoals.Text + "\n\n";

            string[] stringSeparators = new string[] { "-" };
            string[] ptdShatter = tbPTDiagnosis.Text.Split(stringSeparators, StringSplitOptions.None);

            printString += "PT Diagnosis: \n";
            foreach (string thing in ptdShatter)
            {

                string[] stringSeparators2 = new string[] { "," };
                string[] ptdShatterMore = thing.Split(stringSeparators2, StringSplitOptions.None);
                foreach (string sausage in ptdShatterMore)
                {
                    printString += sausage + "\n";
                }

            }

            printString += "Subjective : " + tbSubjective.Text + "\n";
            printString += "Objective : " + tbObjective.Text + "\n";
            printString += "Therapeutic Procedures 1 : " + tbTherapeuticProcedures.Text + "\n";
            printString += "Therapeutic Procedures 2 : " + tbTherapeuticProcedures2.Text + "\n";
            printString += "Therapeutic Procedures 3 : " + tbTherapeuticProcedures3.Text + "\n\n";


            
            printString += "\nAssessment : " + tbAssessment.Text + "\n";
            printString += "Plan for Next Visit : " + tbPlan.Text + "\n\n";
            printString += "Student Provider : " + tbStudentProvider.Text + "\n";
            printString += "Provider Name : " + tbProviderName.Text + "\n";

            docToPrint.PrintPage += new PrintPageEventHandler(docToPrint_PrintPage);
            pd.Document = docToPrint;
            ugh.Document = docToPrint;

            if (pd.ShowDialog() == DialogResult.OK)
            {

            }
            if (ugh.ShowDialog() == DialogResult.OK)
            {

                docToPrint.Print();

            }
        }


        private void docToPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)//why didnt anybody teach this to me
        {
            using (Font font1 = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Point))
            {

                Rectangle rect1 = new Rectangle(100, 100, 650, 25);
                StringFormat SF = new StringFormat();
                SF.Alignment = StringAlignment.Center;
                SF.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString("Follow-Up Visit Information", font1, Brushes.Black, rect1, SF);
                e.Graphics.DrawRectangle(Pens.Black, rect1);

            }

            e.Graphics.DrawString(printString, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new PointF(10, 150));

        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {

        }
    }
}
