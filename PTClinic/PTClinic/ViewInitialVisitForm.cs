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
    public partial class ViewInitialVisitForm : Form
    {
        private int patientId;
        private string pName;
        private Form Admin;
        private Form PP;
        private Form Login;
        private bool editModeOn = false;
        private string printString;
        private System.Drawing.Printing.PrintDocument docToPrint =
    new System.Drawing.Printing.PrintDocument();
        PrintPreviewDialog ugh = new PrintPreviewDialog();
        PrintDialog pd = new PrintDialog();
        public ViewInitialVisitForm(int patientId, string pName, Form Admin, Form Login, Form PP)
        {
            InitializeComponent();
            setButtonIcon();
            this.PP = PP;
            this.patientId = patientId;
            this.pName = pName;
            this.Admin = Admin;
            this.Login = Login;
            FillConstantAttendance();
            FillEvaluation();
            FillTherapeuticProcedures();
            lblPID.Text = patientId.ToString();
            patientLbl.Text = pName;
            DBCall();
            viewMode();
            successLbl.Visible = false;
        }


        private void setButtonIcon()
        {
            btnLogOut.Image = Image.FromFile("..\\..\\Resources\\ic_power_settings_new_white_24dp_1x.png");
            btnBackHome.Image = Image.FromFile("..\\..\\Resources\\ic_home_white_24dp_1x.png");
            btnBackToProfile.Image = Image.FromFile("..\\..\\Resources\\ic_arrow_back_white_24dp_1x.png");
        }

        private void DBCall()
        {
            VisitInfo tempInfo = new VisitInfo();
            using (var connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
            {
                using (var dataReaderPatientVisit = tempInfo.FindOnePatientVisit(connection, patientId))
                {
                    while (dataReaderPatientVisit.Read())
                    {
                        // Take the appropriate fields from the datareader
                        // and put them in proper labels
                        tbProviderID.Text = dataReaderPatientVisit["provider_id"].ToString();

                        string fuhhh = dataReaderPatientVisit["visit_date"].ToString();
                        DateTime mehhh = Convert.ToDateTime(fuhhh);
                        visit_date_txt.Text = mehhh.ToShortDateString();
                        tbChiefComplaint.Text = dataReaderPatientVisit["chief_complaint"].ToString();
                        tbDME.Text = dataReaderPatientVisit["durable_medical_equipment"].ToString();
                        tbSubjective.Text = dataReaderPatientVisit["subjective"].ToString();
                        tbObjective.Text = dataReaderPatientVisit["objective"].ToString();
                        tbPTGoals.Text = dataReaderPatientVisit["pt_goals"].ToString();
                        tbTreatmentPlan.Text = dataReaderPatientVisit["treatment_plan"].ToString();
                        tbDMENeeds.Text = dataReaderPatientVisit["dme_needs"].ToString();
                        tbEvaluation.Text = dataReaderPatientVisit["evaluation"].ToString();
                        tbConstant.Text = dataReaderPatientVisit["constant_attendance"].ToString();
                        tbTherapeutic1.Text = dataReaderPatientVisit["therapeutic_procedures"].ToString();
                        tbTherapeutic2.Text = dataReaderPatientVisit["therapeutic_procedures2"].ToString();
                        tbFunctionalLimitations.Text = dataReaderPatientVisit["functional_limitations"].ToString();
                        tbAssessment.Text = dataReaderPatientVisit["assessment"].ToString();
                        cbEvaluation.SelectedItem = dataReaderPatientVisit["evaluation"].ToString();
                        cbConstantAttendance.SelectedItem = dataReaderPatientVisit["constant_attendance"].ToString();
                        cbTherapeuticProcedures.SelectedItem = dataReaderPatientVisit["therapeutic_procedures"].ToString();
                        cbTherapeutic2.SelectedItem = dataReaderPatientVisit["therapeutic_procedures2"].ToString();
                        var ptDiagnosis = dataReaderPatientVisit["pt_diagnosis"].ToString();
                        tbPTDiagnosis.Text = ptDiagnosis;
                        char[] splitChar = { '+' };
                        string[] diagnosisArray = null;
                        StringBuilder sb = new StringBuilder();

                        diagnosisArray = ptDiagnosis.Split(splitChar);

                        for (int i = 0; i < diagnosisArray.Length; i++)
                        {
                            
                            for (int j = 0; j < clbPTDiagnosis.Items.Count; j++)
                            {
                                if (diagnosisArray[i].Equals((string)clbPTDiagnosis.Items[j]))
                                {
                                    clbPTDiagnosis.SetItemChecked(j, true);

                                }
                            }
                        }

                    }
                }

                connection.Close();
            }
            

        }
        private void btnBackToProfile_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBackHome_Click(object sender, EventArgs e)
        {
           
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
           
        }

        public void FillEvaluation()
        {
            // Fills Evaluation list drop down list
            cbEvaluation.Items.Insert(0, "Select One"); // Index 0
            cbEvaluation.Items.Add("97161 20min Low");
            cbEvaluation.Items.Add("97162 30min Moderate");
            cbEvaluation.Items.Add("97163 40min High");
            cbEvaluation.Items.Add("97164 20-30min");
            cbEvaluation.SelectedIndex = 0;
        }

        // FillConstantAttendance Function
        public void FillConstantAttendance()
        {
            // Fills Constat Attendance list drop down list
            cbConstantAttendance.Items.Insert(0, "Select One"); // Index 0
            cbConstantAttendance.Items.Add("97032 E-stim manual - one or many areas");
            cbConstantAttendance.Items.Add("97033 Iontophroesis");
            cbConstantAttendance.Items.Add("97034 Contrastbath");
            cbConstantAttendance.Items.Add("97035 Ultrasound");
            cbConstantAttendance.Items.Add("97039 Low Level Laser");
            cbConstantAttendance.SelectedIndex = 0;
        }

        // FillTheraputicProcedures Function
        public void FillTherapeuticProcedures()
        {
            // Fills Theraputic Procedures list drop down list
            cbTherapeuticProcedures.Items.Insert(0, "Select One"); // Index 0
            cbTherapeuticProcedures.Items.Add("97110 Theraputic Ex Units - 1");
            cbTherapeuticProcedures.Items.Add("97110 Theraputic Ex Units - 2");
            cbTherapeuticProcedures.Items.Add("97110 Theraputic Ex Units - 3");
            cbTherapeuticProcedures.Items.Add("97110 Theraputic Ex Units - 4");
            cbTherapeuticProcedures.Items.Add("97112 Neuromuscular Re-ed Units - 1");
            cbTherapeuticProcedures.Items.Add("97112 Neuromuscular Re-ed Units - 2");
            cbTherapeuticProcedures.Items.Add("97112 Neuromuscular Re-ed Units - 3");
            cbTherapeuticProcedures.Items.Add("97112 Neuromuscular Re-ed Units - 4");
            cbTherapeuticProcedures.Items.Add("97113 Aquatic Therapy w ther ex Units - 1");
            cbTherapeuticProcedures.Items.Add("97113 Aquatic Therapy w ther ex Units - 2");
            cbTherapeuticProcedures.Items.Add("97113 Aquatic Therapy w ther ex Units - 3");
            cbTherapeuticProcedures.Items.Add("97113 Aquatic Therapy w ther ex Units - 4");
            cbTherapeuticProcedures.Items.Add("97116 Gait Training (includes stairs) Units - 1");
            cbTherapeuticProcedures.Items.Add("97116 Gait Training (includes stairs) Units - 2");
            cbTherapeuticProcedures.Items.Add("97116 Gait Training (includes stairs) Units - 3");
            cbTherapeuticProcedures.Items.Add("97116 Gait Training (includes stairs) Units - 4");
            cbTherapeuticProcedures.Items.Add("97124 Massage Units - 1");
            cbTherapeuticProcedures.Items.Add("97124 Massage Units - 2");
            cbTherapeuticProcedures.Items.Add("97124 Massage Units - 3");
            cbTherapeuticProcedures.Items.Add("97124 Massage Units - 4");
            cbTherapeuticProcedures.Items.Add("97140 Manual Therapy one+regions Units - 1");
            cbTherapeuticProcedures.Items.Add("97140 Manual Therapy one+regions Units - 2");
            cbTherapeuticProcedures.Items.Add("97140 Manual Therapy one+regions Units - 3");
            cbTherapeuticProcedures.Items.Add("97140 Manual Therapy one+regions Units - 4");
            cbTherapeuticProcedures.Items.Add("97530 Theraputic Activities 1-1 Units - 1");
            cbTherapeuticProcedures.Items.Add("97530 Theraputic Activities 1-1 Units - 2");
            cbTherapeuticProcedures.Items.Add("97530 Theraputic Activities 1-1 Units - 3");
            cbTherapeuticProcedures.Items.Add("97530 Theraputic Activities 1-1 Units - 4");
            cbTherapeuticProcedures.SelectedIndex = 0;

            cbTherapeutic2.Items.Insert(0, ""); // Index 0
            cbTherapeutic2.Items.Add("97110 Theraputic Ex Units - 1");
            cbTherapeutic2.Items.Add("97110 Theraputic Ex Units - 2");
            cbTherapeutic2.Items.Add("97110 Theraputic Ex Units - 3");
            cbTherapeutic2.Items.Add("97110 Theraputic Ex Units - 4");
            cbTherapeutic2.Items.Add("97112 Neuromuscular Re-ed Units - 1");
            cbTherapeutic2.Items.Add("97112 Neuromuscular Re-ed Units - 2");
            cbTherapeutic2.Items.Add("97112 Neuromuscular Re-ed Units - 3");
            cbTherapeutic2.Items.Add("97112 Neuromuscular Re-ed Units - 4");
            cbTherapeutic2.Items.Add("97113 Aquatic Therapy w ther ex Units - 1");
            cbTherapeutic2.Items.Add("97113 Aquatic Therapy w ther ex Units - 2");
            cbTherapeutic2.Items.Add("97113 Aquatic Therapy w ther ex Units - 3");
            cbTherapeutic2.Items.Add("97113 Aquatic Therapy w ther ex Units - 4");
            cbTherapeutic2.Items.Add("97116 Gait Training (includes stairs) Units - 1");
            cbTherapeutic2.Items.Add("97116 Gait Training (includes stairs) Units - 2");
            cbTherapeutic2.Items.Add("97116 Gait Training (includes stairs) Units - 3");
            cbTherapeutic2.Items.Add("97116 Gait Training (includes stairs) Units - 4");
            cbTherapeutic2.Items.Add("97124 Massage Units - 1");
            cbTherapeutic2.Items.Add("97124 Massage Units - 2");
            cbTherapeutic2.Items.Add("97124 Massage Units - 3");
            cbTherapeutic2.Items.Add("97124 Massage Units - 4");
            cbTherapeutic2.Items.Add("97140 Manual Therapy one+regions Units - 1");
            cbTherapeutic2.Items.Add("97140 Manual Therapy one+regions Units - 2");
            cbTherapeutic2.Items.Add("97140 Manual Therapy one+regions Units - 3");
            cbTherapeutic2.Items.Add("97140 Manual Therapy one+regions Units - 4");
            cbTherapeutic2.Items.Add("97530 Theraputic Activities 1-1 Units - 1");
            cbTherapeutic2.Items.Add("97530 Theraputic Activities 1-1 Units - 2");
            cbTherapeutic2.Items.Add("97530 Theraputic Activities 1-1 Units - 3");
            cbTherapeutic2.Items.Add("97530 Theraputic Activities 1-1 Units - 4");
            cbTherapeutic2.SelectedIndex = 0;
        }

        private void btnBackToProfile_Click_1(object sender, EventArgs e)//yeah whoops im dumb i figured out what you meant i think
        {
           
            this.Hide();
            PP.Show();
        }

        private void btnBackHome_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Admin.Show();
        }

        private void btnLogOut_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void viewMode()
        {
            button1.Text = "Edit Mode";
            clbPTDiagnosis.Visible = false;
            changeWrn.Visible = false;
            save_btn.Visible = false;
            editModeOn = false;
            tbProviderID.ReadOnly = true;
            visit_date_txt.ReadOnly = true;
            tbChiefComplaint.ReadOnly = true;
            tbDME.ReadOnly = true;
            tbSubjective.ReadOnly = true;
            tbObjective.ReadOnly = true;
            tbPTGoals.ReadOnly = true;
            tbTreatmentPlan.ReadOnly = true;
            tbDMENeeds.ReadOnly = true;
            tbEvaluation.Visible = true;
            tbConstant.Visible = true;
            tbTherapeutic1.Visible = true;
            tbTherapeutic2.Visible = true;
            tbEvaluation.ReadOnly = true;
            tbConstant.ReadOnly = true;
            tbTherapeutic1.ReadOnly = true;
            tbTherapeutic2.ReadOnly = true;
            tbFunctionalLimitations.ReadOnly = true;
            tbAssessment.ReadOnly = true;
            tbPTDiagnosis.ReadOnly = true;
            cbEvaluation.Visible = false;
            cbConstantAttendance.Visible = false;
            cbTherapeuticProcedures.Visible = false;
            cbTherapeutic2.Visible = false;
        }

        private void editMode()
        {
            button1.Text = "Turn off Edit Mode";
            clbPTDiagnosis.Visible = true; 
            print_btn.Visible = false;
            changeWrn.Visible = true;
            save_btn.Visible = true;
            editModeOn = true;
            tbProviderID.ReadOnly = false;
            //visit_date_txt.ReadOnly = false; lets not give them this
            tbChiefComplaint.ReadOnly = false;
            tbDME.ReadOnly = false;
            tbSubjective.ReadOnly = false;
            tbObjective.ReadOnly = false;
            tbPTGoals.ReadOnly = false;
            tbTreatmentPlan.ReadOnly = false;
            tbDMENeeds.ReadOnly = false;
            tbEvaluation.Visible = false;
            tbConstant.Visible = false;
            tbTherapeutic1.Visible = false;
            tbTherapeutic2.Visible = false;
            tbEvaluation.ReadOnly = false;
            tbConstant.ReadOnly = false;
            tbTherapeutic1.ReadOnly = false;
            tbTherapeutic2.ReadOnly = false;
            tbFunctionalLimitations.ReadOnly = false;
            tbAssessment.ReadOnly = false;
            tbPTDiagnosis.ReadOnly = false;

            cbEvaluation.Visible = true;
            cbConstantAttendance.Visible = true;
            cbTherapeuticProcedures.Visible = true;
            cbTherapeutic2.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(editModeOn == false)
            {
                editMode();
               
               
            }
            else
            {
                viewMode();

                print_btn.Visible = true;
            }

        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            printString = "Patient ID#: " + lblPID.Text + "\n";
            printString += "Patient Name: " + patientLbl.Text + "\n";
            printString += "PT of Record: " + tbProviderID.Text + "\n";
            
            printString += "Visit Date: " + visit_date_txt.Text + "\n";
            printString += "Chief Complaint: " + tbChiefComplaint.Text + "\n";
            printString += "Durable Medical Equipment: " + tbDME.Text + "\n";
            printString += "Sujective: " + tbSubjective.Text + "\n";
            printString += "Objective: " + tbObjective.Text + "\n";
            printString += "PT Goals: " + tbPTGoals.Text + "\n";
            printString += "Treatment Plan: " + tbTreatmentPlan.Text + "\n";
            printString += "DME Needs: " + tbDMENeeds.Text + "\n";
            printString += "Evaluation: " + tbEvaluation.Text + "\n";
            printString += "Constant Attendance: " + tbConstant.Text + "\n";
            printString += "Therapeutic Procedures: "+ tbTherapeutic1.Text + "\n";
            printString += "Therapeutic Procedures: " + tbTherapeutic2.Text + "\n";
            printString += "Functional Limitations: " + tbFunctionalLimitations.Text + "\n";
            printString += "Assessment: " + tbAssessment.Text + "\n";
            
            string[] stringSeparators = new string[] { "-" };
            string[] ptdShatter = tbPTDiagnosis.Text.Split(stringSeparators, StringSplitOptions.None);
            
            printString += "Physical Therapy Diagnosis: \n";
            foreach (string thing in ptdShatter)
            {
                
                string[] stringSeparators2 = new string[] { "," };
                string[] ptdShatterMore =  thing.Split(stringSeparators2, StringSplitOptions.None);
                foreach(string sausage in ptdShatterMore)
                {
                    printString += sausage + "\n";
                }
               
            }

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
                e.Graphics.DrawString("Initial Visit Information", font1, Brushes.Black, rect1, SF);
                e.Graphics.DrawRectangle(Pens.Black, rect1);
       
            }

            e.Graphics.DrawString(printString, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new PointF(10, 150));
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void save_btn_Click(object sender, EventArgs e)
        {
            DateTime temp = Convert.ToDateTime(visit_date_txt.Text);
            int tempId;

            StringBuilder sb = new StringBuilder();

            List<string> str = new List<string>();

            foreach (var itemChecked in clbPTDiagnosis.CheckedItems)
            {
                str.Add(itemChecked.ToString());
            }

            Int32.TryParse(lblPID.Text, out tempId);
            var ptDiagnosisResult = string.Join("+", str.ToArray());
            VisitInfo tempInfo = new VisitInfo(tempId, tbProviderID.Text, temp, tbChiefComplaint.Text, tbDME.Text, tbSubjective.Text, tbObjective.Text, tbPTGoals.Text, tbTreatmentPlan.Text, tbDMENeeds.Text, tbEvaluation.Text, cbConstantAttendance.Text, cbTherapeuticProcedures.Text, cbTherapeutic2.Text, tbFunctionalLimitations.Text, tbAssessment.Text, ptDiagnosisResult);
            int success = tempInfo.UpdateVisit();
            DBCall();
            successLbl.Visible = true;
            if (success == 1)
            {
               
                successLbl.Text = "Form Saved Successfully!";
                viewMode();
            }
            else
            {
                successLbl.Text = "There was a problem with your entry.";
            }


        }


    }
}
