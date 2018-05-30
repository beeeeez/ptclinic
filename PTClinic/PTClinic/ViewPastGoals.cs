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
    public partial class ViewPastGoals : Form
    {
        private Form Login;
        private Form Admin;
        private Form PatientProfile;
        private Form PatientGoalsForm;
        private int patientID;
        private string pname;
        private string printString;
        private System.Drawing.Printing.PrintDocument docToPrint =
    new System.Drawing.Printing.PrintDocument();
        PrintPreviewDialog ugh = new PrintPreviewDialog();
        PrintDialog pd = new PrintDialog();


        public ViewPastGoals(int patientID, string pname, Form Admin, Form Login, Form PatientProfile, Form PatientGoalsForm)
        {
            InitializeComponent();
            this.patientID = patientID;
            this.Admin = Admin;
            this.Login = Login;
            this.PatientProfile = PatientProfile;
            this.PatientGoalsForm = PatientGoalsForm;
            this.pname = pname;
            
            


        }


        private void fillDateCombo()
        {


            using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
            {
                try
                {

                    string strSQL = "SELECT goal_date FROM patient_goals WHERE patient_id = @PID ORDER BY goal_date DESC;";

                    connection.Open(); // open connection

                    OleDbCommand comm = new OleDbCommand();
                    comm.CommandText = strSQL; // Commander knows what to say
                    comm.Connection = connection; // Heres the connection
                    comm.Parameters.AddWithValue("@PID", patientID);

                    OleDbDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        cbDatePick.Items.Insert(0, "Select Goal Form Date");
                        cbDatePick.SelectedIndex = 0;
                        while (reader.Read())
                        {
                            if (reader["goal_date"] != DBNull.Value)
                            {
                                cbDatePick.Items.Add(reader["goal_date"]);
                            }


                        }
                    }
                    else
                    {
                        cbDatePick.Items.Add("No Past Goals");
                        cbDatePick.SelectedIndex = 0;

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




        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void ViewPastGoals_Load(object sender, EventArgs e)
        {
            fillDateCombo();
            lbpatientID.Text = patientID.ToString();
            lbpatientName.Text = pname.ToString();
        }

        private void cbDatePick_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDatePick.SelectedIndex != 0)
            {
                using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
                {
                    try
                    {

                        string strSQL = "SELECT * FROM patient_goals WHERE patient_id = @PID and goal_date = @goalDate ORDER BY goal_date DESC;";

                        connection.Open(); // open connection

                        OleDbCommand comm = new OleDbCommand();
                        comm.CommandText = strSQL; // Commander knows what to say
                        comm.Connection = connection; // Heres the connection
                        comm.Parameters.AddWithValue("@PID", patientID);

                        //Convert.ToDateTime(cbAppointmentDates.SelectedValue.ToString());
                        string fuhhh = cbDatePick.Text;
                        DateTime mehhh = Convert.ToDateTime(fuhhh);
                        comm.Parameters.AddWithValue("@goalDate", mehhh);
                        OleDbDataReader reader = comm.ExecuteReader();
                        if (reader.HasRows)
                        {
                        //    cbDatePick.SelectedIndex = 0;
                            while (reader.Read())
                            {
                                if (reader["goal_date"] != DBNull.Value)
                                {
                                    mehhh = Convert.ToDateTime(reader["goal_date"].ToString());

                                    tbActivityOne.Text = reader["activity1"].ToString();
                                    tbActivityTwo.Text = reader["activity2"].ToString();
                                    tbActivityThree.Text = reader["activity3"].ToString();

                                    tbScore1.Text = reader["activity1_score"].ToString();
                                    tbScore2.Text = reader["activity2_score"].ToString();
                                    tbScore3.Text = reader["activity3_score"].ToString();

                                    tbInterpret1.Text = reader["activity1_interpretedby"].ToString();
                                    tbInterpret2.Text = reader["activity2_interpretedby"].ToString();
                                    tbInterpret3.Text = reader["activity3_interpretedby"].ToString();

                                    tbNotesObservations.Text = reader["patient_notes_observations"].ToString();
                                }

                            }
                        }
                        else
                        {
                            cbDatePick.Items.Add("No Past Visits");
                            cbDatePick.SelectedIndex = 0;

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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login.Show();
        }

        private void btnBackHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin.Show();
        }

        private void btnBackToProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientProfile.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientGoalsForm.Show();
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            printString += "Patient ID: " + lbpatientID.Text + "\n";
            printString += "Patient Name: " + lbpatientName.Text + "\n";
            printString += "Goal Assigned Date: " + cbDatePick.Text + "\n\n";
            printString += "Activity 1: " + tbActivityOne.Text + "\n";
            printString += "Score: " + tbScore1.Text + "\n";
            printString += "Interpreted By : " + tbInterpret1.Text + "\n\n";
            printString += "Activity 2: " + tbActivityTwo.Text + "\n";
            printString += "Score: " + tbScore2.Text + "\n";
            printString += "Interpreted By : " + tbInterpret2.Text + "\n\n";
            printString += "Activity 3: " + tbActivityThree.Text + "\n";
            printString += "Score: " + tbScore3.Text + "\n";
            printString += "Interpreted By : " + tbInterpret3.Text+ "\n\n";
            printString += "Notes : " + tbNotesObservations.Text;

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
                e.Graphics.DrawString("Physical Therapy Goals Sheet", font1, Brushes.Black, rect1, SF);
                e.Graphics.DrawRectangle(Pens.Black, rect1);


            }

            e.Graphics.DrawString(printString.ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new PointF(100, 160));

        }
    }
}
