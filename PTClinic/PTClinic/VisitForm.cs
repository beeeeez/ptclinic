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
    public partial class VisitForm : Form
    {

        private Form Admin;
        private Form Login;
        public int patientID;

        public VisitForm()
        {
            InitializeComponent();
        }

        // Add Visit Button Click
        // Add Visit Information to DB
        private void btnAddVisit_Click(object sender, EventArgs e)
        {
            // TODO -- functionality
        }

        // Back Home Button Click
        // Send to Homepage
        private void btnBackHome_Click(object sender, EventArgs e)
        {
            // TODO -- functionality
        }

    }
}
