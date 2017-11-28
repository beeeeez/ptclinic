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
    public partial class PatientInformation : Form
    {
        private Form Admin;
        private Form Login;
        private Form Search;
        public int patientID;


        public PatientInformation(Form adminForm, Form Login)
        {
            InitializeComponent();

            setButtonIcon();

            patientID = 0;

            this.Login = Login;
            this.Admin = adminForm;
            Admin.Hide();

            // Todays Date
            DateTime date = DateTime.Now;
            string shortDateStr = date.ToLongDateString();
            lblTodaysDate.Text = shortDateStr;

            // Fill Drop Downs
            FillStateList();
            FillMedicalInsurance();
            FillPhoneType();
            FillGender();

        }

        private void setButtonIcon()
        {
            btnLogOut.Image = Image.FromFile("..\\..\\Resources\\ic_power_settings_new_white_24dp_1x.png");
            btnBackHome.Image = Image.FromFile("..\\..\\Resources\\ic_home_white_24dp_1x.png");
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

        public void FillStateList()
        {
            // Fills state list drop down list
            cbState.Items.Insert(0, "Select One"); // Index 0
            cbState.Items.Add("Connecticut");
            cbState.Items.Add("Maine");
            cbState.Items.Add("Massachusetts");
            cbState.Items.Add("New Hampshire");
            cbState.Items.Add("New York");
            cbState.Items.Add("Rhode Island");
            cbState.Items.Add("Vermont");
            cbState.SelectedIndex = 0;

            cbCGState.Items.Insert(0, "Select One"); // Index 0
            cbCGState.Items.Add("Connecticut");
            cbCGState.Items.Add("Maine");
            cbCGState.Items.Add("Massachusetts");
            cbCGState.Items.Add("New Hampshire");
            cbCGState.Items.Add("New York");
            cbCGState.Items.Add("Rhode Island");
            cbCGState.Items.Add("Vermont");
            cbCGState.SelectedIndex = 0;
        }

        public void FillMedicalInsurance()
        {
            cbInsurer.Items.Insert(0, "Select One");
            cbInsurer.Items.Add("Medicare");
            cbInsurer.Items.Add("Medicaid");
            cbInsurer.Items.Add("United Healthcare STATE");
            cbInsurer.Items.Add("NHPRI STATE");
            cbInsurer.Items.Add("United Healthcare Commercial");
            cbInsurer.Items.Add("NHPRI Commercial");
            cbInsurer.Items.Add("Tufts");
            cbInsurer.Items.Add("Other");
            cbInsurer.SelectedIndex = 0;
        }

        public void FillPhoneType()
        {
            cbPhone1Type.Items.Insert(0, "Select One");
            cbPhone1Type.Items.Add("Home");
            cbPhone1Type.Items.Add("Cell");
            cbPhone1Type.Items.Add("Work");
            cbPhone1Type.SelectedIndex = 0;

            cbPhone2Type.Items.Insert(0, "Select One");
            cbPhone2Type.Items.Add("Home");
            cbPhone2Type.Items.Add("Cell");
            cbPhone2Type.Items.Add("Work");
            cbPhone2Type.SelectedIndex = 0;

            cbCGPhone1Type.Items.Insert(0, "Select One");
            cbCGPhone1Type.Items.Add("Home");
            cbCGPhone1Type.Items.Add("Cell");
            cbCGPhone1Type.Items.Add("Work");
            cbCGPhone1Type.SelectedIndex = 0;

            cbCGPhone2Type.Items.Insert(0, "Select One");
            cbCGPhone2Type.Items.Add("Home");
            cbCGPhone2Type.Items.Add("Cell");
            cbCGPhone2Type.Items.Add("Work");
            cbCGPhone2Type.SelectedIndex = 0;

            cbECPhoneType.Items.Insert(0, "Select One");
            cbECPhoneType.Items.Add("Home");
            cbECPhoneType.Items.Add("Cell");
            cbECPhoneType.Items.Add("Work");
            cbECPhoneType.SelectedIndex = 0;

        }

        public void FillGender()
        {
            cbGender.Items.Insert(0, "Select One");
            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");
            cbGender.Items.Add("Other");
            cbGender.Items.Add("Prefer not to say");
            cbGender.SelectedIndex = 0;
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear all fields
        }

        private void btnContinueToCaregiver_Click(object sender, EventArgs e)
        {


            PatientInfo newPatient = new PatientInfo();

            newPatient.Fname = tbFirstName.Text;
            newPatient.MInitial = tbMiddleInitial.Text;
            newPatient.Lname = tbLastName.Text;
            newPatient.Gender = cbGender.Text;

            // Get Current SHORT dATE
            //DateTime birthDate = new DateTime(dtpDOB.Value);
            string shortDateStr = dtpDOB.Value.ToShortDateString();
            DateTime shortDateBirthday = Convert.ToDateTime(shortDateStr);


            newPatient.Birthdate = shortDateBirthday;
            newPatient.Address = tbAddress.Text;
            newPatient.Address2 = tbAddress2.Text;
            newPatient.City = tbCity.Text;
            newPatient.State = cbState.Text;
            newPatient.Zip = tbZip.Text;

            Nullable<bool> hasInsurance = null;
            if (rdbInsuranceYes.Checked == true)
            {
                hasInsurance = true;
            }
            else if (rdbInsuranceNo.Checked == true)
            {
                hasInsurance = false;
            }
            newPatient.HasInsurance = hasInsurance;
            newPatient.Insurer = cbInsurer.Text;
            newPatient.OtherInsurer = tbOtherInsurance.Text;

            newPatient.Phone = tbPhone1.Text;
            newPatient.PhoneExtension = tbPhoneExt1.Text;
            newPatient.PhoneType = cbPhone1Type.Text;

            newPatient.Phone2 = tbPhone2.Text;
            newPatient.Phone2Extension = tbPhoneExt2.Text;
            newPatient.Phone2Type = cbPhone2Type.Text;

            Nullable<bool> canContact = null;
            if (rdbMessageYes.Checked == true)
            {
                canContact = true;
            }
            else if (rdbMessageNo.Checked == true)
            {

                canContact = false;
            }

            newPatient.LeaveMessage = canContact;

            newPatient.Email = tbEmail.Text;


            // If statement to check if there are field erros

            // If an error in the information occurs
            if (newPatient.Feedback.Contains("Error:"))
            {
                // Display the error message inside the form feedback label
                lblFeedback.Text = newPatient.Feedback;
            }
            else // If there are no errors, continue to Caregiver Form
            {
                lblFeedback.Text = "";

                try
                {
                    //lblFeedback.Text = newPatient.AddRecord();
                    int dbSuccess = newPatient.AddRecord();

                    // If patient record was added successfully get patient id from that insert
                    if (dbSuccess == 1)
                    {
                        lblFeedback.Text = "Patient Info has been saved";

                        using (OleDbConnection connection = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\\..\\PTClinic.accdb; Persist Security Info = False;"))
                        {

                            string getUserSQL = "SELECT [patient_id] FROM Patients WHERE ([patient_id] = (SELECT MAX(patient_id) FROM Patients))";
                            OleDbCommand comm = new OleDbCommand();
                            comm.CommandText = getUserSQL; // Commander knows what to say
                            comm.Connection = connection; // Heres the connection

                            try
                            {
                                connection.Open();
                                OleDbDataReader dr = comm.ExecuteReader();

                                if (dr.Read())
                                {
                                    lblFeedback.Text = "Patient ID is " + dr.GetInt32(0).ToString();
                                    patientID = dr.GetInt32(0);
                                }
                                else
                                {
                                    lblFeedback.Text = "NO PATIENT ID !";
                                }


                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            finally
                            {
                                connection.Close();
                            }

                        }

                    }
                    else
                    {
                        lblFeedback.Text = "Patient Info was not saved";
                    }
                }
                catch (Exception ex)
                {
                    lblFeedback.Text = ex.ToString();
                }

                panelPatientInfo.Visible = false;
                panelCaregiverInfo.Visible = true;

                // Clear all fields
                ClearPatientForm();


            }

        }

        private void btnAddCaregiver_Click(object sender, EventArgs e)
        {

            EmergencyContact newEmergencyContact = new EmergencyContact();
            newEmergencyContact.Fullname = tbECName.Text;
            newEmergencyContact.Phone = tbECPhone.Text;
            newEmergencyContact.PhoneExtension = tbECPhoneExt.Text;
            newEmergencyContact.PhoneType = cbECPhoneType.Text;
            newEmergencyContact.Relationship = tbECRelationship.Text;
            newEmergencyContact.PatientID = patientID;


            CaregiverInfo newCaregiver = new CaregiverInfo();

            newCaregiver.PatientID = patientID;
            newCaregiver.Name = tbCGName.Text;
            newCaregiver.Address = tbCGAddress.Text;
            newCaregiver.City = tbCGCity.Text;
            newCaregiver.State = cbCGState.Text;
            newCaregiver.Zip = tbCGZip.Text;
            newCaregiver.Phone = tbCGPhone1.Text;
            newCaregiver.PhoneExtension = tbCGPhone1Ext.Text;
            newCaregiver.PhoneType = cbCGPhone1Type.Text;

            newCaregiver.Phone2 = tbCGPhone2.Text;
            newCaregiver.Phone2Extension = tbCGPhone2Ext.Text;
            newCaregiver.Phone2Type = cbCGPhone2Type.Text;


            if (newEmergencyContact.Feedback.Contains("Error:") || newCaregiver.Feedback.Contains("Error:"))
            {
                lblCareFeedback.Text = "";
                lblCareFeedback.Text += newEmergencyContact.Feedback;
                lblCareFeedback.Text += newCaregiver.Feedback;
            }
            else
            {
                lblCareFeedback.Text = "";

                try
                {

                    int ECSuccess = newEmergencyContact.AddRecord();

                    if (ECSuccess == 1)
                    {
                       
                        lblCareFeedback.Text = "";

                        try
                        {
                            lblCareFeedback.Text = newCaregiver.AddRecord();

                            // If caregiver is successful go to patient profile page
                            bool isNewRecord = true;

                            PatientProfile temp = new PatientProfile(patientID, Admin, Login, Search, this, isNewRecord);
                            temp.Show();



                        }
                        catch (Exception exc)
                        {
                            lblCareFeedback.Text = exc.ToString();
                        }

                        // Clear all fields
                        ClearCaregiverForm();
                        // Clear all fields
                        ClearEmergencyContactForm();


                    }
                    else
                    {
                        lblFeedback.Text += "Emergency Contact Info was not saved";
                    }


                    // lblCareFeedback.Text = newEmergencyContact.AddRecord();
                }
                catch (Exception exc) 
                {
                    lblCareFeedback.Text = exc.ToString();
                }

         
            }




            //CaregiverInfo newCaregiver = new CaregiverInfo();

            //newCaregiver.PatientID = patientID;
            //newCaregiver.Name = tbCGName.Text;
            //newCaregiver.Address = tbCGAddress.Text;
            //newCaregiver.City = tbCGCity.Text;
            //newCaregiver.State = cbCGState.Text;
            //newCaregiver.Zip = tbCGZip.Text;
            //newCaregiver.Phone = tbCGPhone1.Text;
            //newCaregiver.PhoneExtension = tbCGPhone1Ext.Text;
            //newCaregiver.PhoneType = cbCGPhone1Type.Text;

            //newCaregiver.Phone2 = tbCGPhone2.Text;
            //newCaregiver.Phone2Extension = tbCGPhone2Ext.Text;
            //newCaregiver.Phone2Type = cbCGPhone2Type.Text;


            //// If an error in the information occurs
            //if (newCaregiver.Feedback.Contains("Error:"))
            //{
            //    // Display the error message inside the form feedback label
            //    lblCareFeedback.Text += newCaregiver.Feedback;
            //}
            //else // If there are no errors, continue to Caregiver Form
            //{
            //    lblCareFeedback.Text = "";

            //    try
            //    {
            //        lblCareFeedback.Text = newCaregiver.AddRecord();
            //    }
            //    catch (Exception exc)
            //    {
            //        lblCareFeedback.Text = exc.ToString();
            //    }

                // Clear all fields
                //ClearCaregiverForm();
                //// Clear all fields
                //ClearEmergencyContactForm();
            //}


        }

        public void ClearPatientForm()
        {
            tbFirstName.Clear();
            tbLastName.Clear();
            cbGender.SelectedIndex = 0;
            dtpDOB.Value = DateTime.Now;
            tbAddress.Clear();
            tbAddress2.Clear();
            tbCity.Clear();
            cbState.SelectedIndex = 0;
            tbZip.Clear();
            rdbInsuranceYes.Checked = false;
            rdbInsuranceNo.Checked = false;
            cbInsurer.SelectedIndex = 0;
            tbOtherInsurance.Clear();
            tbPhone1.Clear();
            tbPhoneExt1.Clear();
            cbPhone1Type.SelectedIndex = 0;
            tbPhone2.Clear();
            tbPhoneExt2.Clear();
            cbPhone2Type.SelectedIndex = 0;
            rdbMessageYes.Checked = false;
            rdbMessageNo.Checked = false;
            tbEmail.Clear();
        }

        public void ClearEmergencyContactForm()
        {
            tbECName.Clear();
            tbECPhoneExt.Clear();
            tbECPhoneExt.Clear();
            cbECPhoneType.SelectedIndex = 0;
            tbECRelationship.Clear();

        }

        public void ClearCaregiverForm()
        {
            tbCGName.Clear();
            tbCGAddress.Clear();
            tbCGCity.Clear();
            cbCGState.SelectedIndex = 0;
            tbCGZip.Clear();
            tbCGPhone1.Clear();
            tbCGPhone1Ext.Clear();
            cbCGPhone1Type.SelectedIndex = 0;
            tbCGPhone2.Clear();
            tbCGPhone2Ext.Clear();
            cbCGPhone2Type.SelectedIndex = 0;
        }
    }
}
