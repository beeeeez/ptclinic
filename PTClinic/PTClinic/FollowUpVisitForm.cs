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
    public partial class FollowUpVisitForm : Form
    {
        private Form Admin;
        private Form Login;
        public int patientID;

        public FollowUpVisitForm()
        {
            InitializeComponent();
            // Set Button Icons
            setButtonIcon();
        }

        // Setting the Icons for Logout and Home Buttons
        private void setButtonIcon()
        {
            btnLogOut.Image = Image.FromFile("..\\..\\Resources\\ic_power_settings_new_white_24dp_1x.png");
            btnBackHome.Image = Image.FromFile("..\\..\\Resources\\ic_home_white_24dp_1x.png");
        }

        // Home Button Click
        // Send back to Admin Page
        private void btnBackHome_Click(object sender, EventArgs e)
        {
            // TODO -- functionality
        }

        // Logout Button Click
        // Send back to Login Page
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // TODO -- functionality
        }

        // Add Follow Up Information to DB
        private void btnAddFollowUp_Click(object sender, EventArgs e)
        {
            // TODO -- functionality
        }

        // Reset form back
        private void btnClear_Click(object sender, EventArgs e)
        {
            // TODO -- functionality
        }
    }
}
