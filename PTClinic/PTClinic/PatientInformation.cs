﻿using System;
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
    public partial class PatientInformation : Form
    {
        private Form Admin;
        private Form Login;

        public PatientInformation(Form adminForm, Form Login)
        {
            InitializeComponent();

            setButtonIcon();

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
            this.cbState.ValueMember = "Value";
            this.cbState.DisplayMember = "Text";
            this.cbState.Items.AddRange(new[]
            {
                new ComboBoxItem() { Selectable=false, Text="Select One", Value="None" },
                new ComboBoxItem() { Selectable=true, Text="Massachusetts", Value="MA" },
                new ComboBoxItem() { Selectable=true, Text="Rhode Island", Value="RI" },
            });

            cbState.SelectedIndex = 0;
            

            this.cbState.SelectedIndexChanged += (cbSender, cbe) =>
            {
                var cb = cbSender as ComboBox;

                if (cb.SelectedItem != null && cb.SelectedItem is ComboBoxItem && ((ComboBoxItem) cb.SelectedItem).Selectable == false)
                {
                    cbState.SelectedIndex = -1;
                }

            };
            // Fills state list drop down list
            //cbState.Items.Insert(0, "Select One"); // Index 0
            //cbState.Items.Add("MA");
            //cbState.Items.Add("RI");
            //cbState.Items.Add("CT");
            //cbState.SelectedIndex = 0;
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

        private void btnAddPatient_Click(object sender, EventArgs e)
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

            bool hasInsurance = false;
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

            bool canContact = false;
            if (rdbMessageYes.Checked == true)
            {
                canContact = true;
            }
            else if (rdbMessageNo.Checked == false)
            {

                canContact = false;
            }

            newPatient.LeaveMessage = canContact;

            newPatient.Email = tbEmail.Text;


            // If statement to check if there are field erros

            // Else display that new patient was added to DB

            try
            {
                lblFeedback.Text = newPatient.AddRecord();
            }
            catch (Exception ex)
            {
                lblFeedback.Text = ex.ToString();
            }

        }


    }

    internal class ComboBoxItem
    {
        public int Index { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public bool Selectable { get; set; }
        public ComboBoxItem()
        {
        }
    }
}
