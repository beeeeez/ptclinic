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
    public partial class AppointmentSearch : Form
    {
        private Form Admin;
        private Form Login;
        private Form PP;
        private int patientId;
        private string pname;
        private string printString;
        private System.Drawing.Printing.PrintDocument docToPrint =
    new System.Drawing.Printing.PrintDocument();
        PrintPreviewDialog ugh = new PrintPreviewDialog();
        PrintDialog pd = new PrintDialog();
        public AppointmentSearch(int patientId, string pname, Form Admin, Form Login, Form PP)
        {
            InitializeComponent();
            
            this.patientId = patientId;
            this.Admin = Admin;
            this.Login = Login;
            this.PP = PP;
            this.pname = pname;
            lblPatientID.Text = patientId.ToString();
            lblPatientName.Text = pname;
            btnPrintAppCopy.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void AppointmentSearch_Load(object sender, EventArgs e)
        {
            populateComboDates();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbAppointmentDates.SelectedIndex != 0) {
                using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
                {
                    try
                    {

                        string strSQL = "SELECT * FROM appointments WHERE patient_id = @PID and appointment_date = @appointmentDate ORDER BY appointment_date DESC;";

                        connection.Open(); // open connection

                        OleDbCommand comm = new OleDbCommand();
                        comm.CommandText = strSQL; // Commander knows what to say
                        comm.Connection = connection; // Heres the connection
                        comm.Parameters.AddWithValue("@PID", patientId);

                        //Convert.ToDateTime(cbAppointmentDates.SelectedValue.ToString());
                        string fuhhh = cbAppointmentDates.Text;
                        DateTime mehhh = Convert.ToDateTime(fuhhh);
                        comm.Parameters.AddWithValue("@appointmentDate", mehhh);
                        OleDbDataReader reader = comm.ExecuteReader();
                        if (reader.HasRows)
                        {
                            cbAppointmentDates.SelectedIndex = 0;
                            while (reader.Read())
                            {
                                if (reader["appointment_date"] != DBNull.Value)
                                {
                                    mehhh = Convert.ToDateTime(reader["appointment_date"].ToString());

                                    lblAppDate.Text = mehhh.ToShortDateString();
                                    lblAppTime.Text = reader["appointment_time"].ToString();
                                    lblAppType.Text = reader["appointment_type"].ToString();
                                }

                            }
                        }
                        else
                        {
                            cbAppointmentDates.Items.Add("No Past Visits");
                            cbAppointmentDates.SelectedIndex = 0;

                        }
                    }
                    catch (Exception m)
                    {
                        MessageBox.Show(m.ToString());
                    }
                    finally
                    {
                        connection.Close();
                    }

                }
            }
        }

        private void populateComboDates()
        {

            using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
            {
                try
                {

                    string strSQL = "SELECT * FROM appointments WHERE patient_id = @PID ORDER BY appointment_date DESC;";

                    connection.Open(); // open connection

                    OleDbCommand comm = new OleDbCommand();
                    comm.CommandText = strSQL; // Commander knows what to say
                    comm.Connection = connection; // Heres the connection
                    comm.Parameters.AddWithValue("@PID", patientId);

                    OleDbDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        cbAppointmentDates.Items.Insert(0, "Select Appointment Date");
                        cbAppointmentDates.SelectedIndex = 0;
                        while (reader.Read())
                        {
                            if (reader["appointment_date"] != DBNull.Value)
                            {
                                cbAppointmentDates.Items.Add(reader["appointment_date"]);
                            }
                            

                        }
                    }
                    else
                    {
                        cbAppointmentDates.Items.Add("No Past Appointments");
                        cbAppointmentDates.SelectedIndex = 0;

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

        private void btnPrintAppCopy_Click(object sender, EventArgs e)
        {
            printString += lblPatientID.Text + "\n";
            printString += lblPatientName.Text + "\n";
            printString += lblAppDate.Text + "\n";
            printString += lblAppTime.Text + "\n";
            printString += lblAppType.Text + "\n";


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
            /*
            printDialog.Document = printAppointment;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printAppointment.Print();
            }
            */
            // !!! To view print layout uncomment this

            //if (printPreviewDialog.ShowDialog() == DialogResult.OK)
            //{
            //    printAppointment.Print();
            //}


        }


        private void docToPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            using (Font font1 = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Point))
            {

                Rectangle rect1 = new Rectangle(100, 100, 650, 25);
                StringFormat SF = new StringFormat();
                SF.Alignment = StringAlignment.Center;
                SF.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString("Physical Therapy Appointment", font1, Brushes.Black, rect1, SF);
                e.Graphics.DrawRectangle(Pens.Black, rect1);


            }

            e.Graphics.DrawString(printString.ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new PointF(100, 160));

        }

        private void btnBackToProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            PP.Show();
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
