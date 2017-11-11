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
        public Search()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Creating a DataSet to hold the DataSet we'll get from PatientInfo
            DataSet myDataSet;

            //Perform a search using the input(s)
            PatientInfo temp = new PatientInfo();
        }
    }
}
