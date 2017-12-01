using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTClinic
{
    public partial class Search : Form
    {
        // Variables for the admin and login forms
        private Form Admin;
        private Form Login;
        private Form PatientInfo;


        public Search(Form adminForm, Form Login)
        {
            InitializeComponent();
            setButtonIcon();

            this.Admin = adminForm;
            this.Login = Login;
            Admin.Hide();
        }

        // Setting the Icons for Logout and Home Buttons
        private void setButtonIcon()
        {
            btnLogOut.Image = Image.FromFile("..\\..\\Resources\\ic_power_settings_new_white_24dp_1x.png");
            btnBackHome.Image = Image.FromFile("..\\..\\Resources\\ic_home_white_24dp_1x.png");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Creating a DataSet to hold the DataSet we'll get from PatientInfo
            DataSet myDataSet = new DataSet();

            // Perform a search using the input(s)
            PatientInfo temp = new PatientInfo();

            myDataSet = temp.SearchPatients(txtFName.Text, txtLName.Text);

            // Display search results in gridview
            gvResults.DataSource = myDataSet;
            gvResults.DataMember = "patientInfo";

            // Setting the text for the headers
            // Since we know we're only showing id/fname/middleinit/lastname/dob
            gvResults.Columns[0].HeaderText = "Patient ID";
            gvResults.Columns[1].HeaderText = "First Name";
            gvResults.Columns[2].HeaderText = "Middle Initial";
            gvResults.Columns[3].HeaderText = "Last Name";
            gvResults.Columns[4].HeaderText = "Date of Birth";
        }

        private void gvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string strPID = gvResults.Rows[e.RowIndex].Cells[0].Value.ToString();

            //MessageBox.Show(strPID);

            int intPID = Convert.ToInt32(strPID);
            bool isNewRecord = false;

            PatientProfile temp = new PatientProfile(intPID, Admin, Login, this, PatientInfo, isNewRecord);
            temp.Show();
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
