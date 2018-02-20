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
    public partial class PastVisitSearchForm : Form
    {

        private int patientId;
        private Form Admin;
        private Form Login;

        public PastVisitSearchForm(int patientId, Form Admin, Form Login)
        {

            InitializeComponent();

            setButtonIcon();
            btnViewFollowUp.Visible = true;

            this.patientId = patientId;
            this.Admin = Admin;
            this.Login = Login;

            string id = patientId.ToString();
            lblPatientId.Text = "Patient ID: " + id;

            LoadComboBox(); // Loads from Access DB

        }

        private void LoadComboBox()
        {
            using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
            {
                try
                {

                    string strSQL = "SELECT * FROM Patient_FollowUp_Visit WHERE patient_id = @PID ORDER BY visit_date DESC;";

                    connection.Open(); // open connection

                    OleDbCommand comm = new OleDbCommand();
                    comm.CommandText = strSQL; // Commander knows what to say
                    comm.Connection = connection; // Heres the connection
                    comm.Parameters.AddWithValue("@PID", patientId);

                    OleDbDataReader reader = comm.ExecuteReader();

                    if (reader.HasRows)
                    {
                        cbPastFollowupVisits.Items.Insert(0, "Select Visit Date");
                        cbPastFollowupVisits.SelectedIndex = 0;
                        while (reader.Read())
                        {
                            if (reader["visit_date"] != DBNull.Value)
                            {
                                cbPastFollowupVisits.Items.Add(reader["visit_date"]);
                            }
                        
                        }
                    }
                    else
                    {
                        cbPastFollowupVisits.Items.Add("No Past Visits");
                        cbPastFollowupVisits.SelectedIndex = 0;
                        panelMessage.Visible = true;
                        btnViewFollowUp.Visible = false;
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                finally
                {
                    connection.Close();
                }

            }

        }


        // Setting the Icons for Logout and Home Buttons
        private void setButtonIcon()
        {
            btnLogOut.Image = Image.FromFile("..\\..\\Resources\\ic_power_settings_new_white_24dp_1x.png");
            btnBackHome.Image = Image.FromFile("..\\..\\Resources\\ic_home_white_24dp_1x.png");
            btnBackToProfile.Image = Image.FromFile("..\\..\\Resources\\ic_arrow_back_white_24dp_1x.png");
        }

        private void btnViewFollowUp_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;

            if (cbPastFollowupVisits.Text.Equals("Select Visit Date"))
            {
                //MessageBox.Show("Please select a date");
                lblErrorMessage.Visible = true;
            }
            else
            {
               // MessageBox.Show("go to form");
                ViewPastVisitForm viewForm = new ViewPastVisitForm(patientId, cbPastFollowupVisits.Text, Admin, Login);
                viewForm.Show();
                this.Hide();
            }
           
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
