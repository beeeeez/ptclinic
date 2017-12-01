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
    public partial class AppointmentForm : Form
    {
        private Form PatientProfile;

        public AppointmentForm()
        {
            InitializeComponent();
        }

        public AppointmentForm(Form patientProfile, int patientID, PatientInfo patientDetails)
        {

            InitializeComponent();

            this.PatientProfile = patientProfile;
            PatientProfile.Hide();

            lblPatientID.Text = patientID.ToString();
            lblPatientName.Text = patientDetails.Fname;
        }
    }
}
