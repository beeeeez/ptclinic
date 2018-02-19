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
    public partial class ViewPastVisitForm : Form
    {
        private int patientId;
        private string visitDate;
        private Form Admin;
        private Form Login;

        public ViewPastVisitForm(int patientID, string visitDate, Form Admin, Form Login)
        {
            InitializeComponent();
            setButtonIcon();

            this.patientId = patientID;
            this.visitDate = visitDate;
            this.Admin = Admin;
            this.Login = Login;

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
                            MessageBox.Show("Patient Name = " + reader["patient_name"].ToString());
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
    }
}
