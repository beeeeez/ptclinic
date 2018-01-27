using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;

namespace PTClinic
{
    public partial class TestDisplayForm : Form
    {
        public TestDisplayForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            StringCollection myCol = new StringCollection();

            List<string> str = new List<string>();

            foreach (var itemChecked in clbDiagnosis.CheckedItems)
            {
                str.Add(itemChecked.ToString());
            }


            var result = string.Join(" + ", str.ToArray());

            MessageBox.Show(result);
        }
    }
}
