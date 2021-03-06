﻿namespace PTClinic
{
    partial class AppointmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppointmentForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBackToProfile = new System.Windows.Forms.Button();
            this.btnBackHome = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpAppDate = new System.Windows.Forms.DateTimePicker();
            this.tpAppTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbAppType = new System.Windows.Forms.ComboBox();
            this.btnScheduleAppointment = new System.Windows.Forms.Button();
            this.lblAppType = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAppTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPatientID = new System.Windows.Forms.Label();
            this.btnPrintAppCopy = new System.Windows.Forms.Button();
            this.panelAppMessage = new System.Windows.Forms.Panel();
            this.lblDBFeedback = new System.Windows.Forms.Label();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.printAppointment = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.cbAppAddress = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panelAppMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.btnBackToProfile);
            this.panel1.Controls.Add(this.btnBackHome);
            this.panel1.Controls.Add(this.btnLogOut);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1275, 73);
            this.panel1.TabIndex = 119;
            // 
            // btnBackToProfile
            // 
            this.btnBackToProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackToProfile.BackColor = System.Drawing.Color.Navy;
            this.btnBackToProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToProfile.ForeColor = System.Drawing.Color.White;
            this.btnBackToProfile.Location = new System.Drawing.Point(798, 20);
            this.btnBackToProfile.Name = "btnBackToProfile";
            this.btnBackToProfile.Size = new System.Drawing.Size(164, 34);
            this.btnBackToProfile.TabIndex = 76;
            this.btnBackToProfile.Text = "Back To Profile";
            this.btnBackToProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBackToProfile.UseVisualStyleBackColor = false;
            this.btnBackToProfile.Click += new System.EventHandler(this.btnBackToProfile_Click);
            // 
            // btnBackHome
            // 
            this.btnBackHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackHome.BackColor = System.Drawing.Color.Navy;
            this.btnBackHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackHome.ForeColor = System.Drawing.Color.White;
            this.btnBackHome.Location = new System.Drawing.Point(1008, 20);
            this.btnBackHome.Name = "btnBackHome";
            this.btnBackHome.Size = new System.Drawing.Size(107, 34);
            this.btnBackHome.TabIndex = 75;
            this.btnBackHome.Text = "Home";
            this.btnBackHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBackHome.UseVisualStyleBackColor = false;
            this.btnBackHome.Click += new System.EventHandler(this.btnBackHome_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogOut.BackColor = System.Drawing.Color.Navy;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Location = new System.Drawing.Point(1144, 20);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(107, 34);
            this.btnLogOut.TabIndex = 75;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(79, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(264, 29);
            this.label7.TabIndex = 13;
            this.label7.Text = "Appointment Scheduler";
            // 
            // dtpAppDate
            // 
            this.dtpAppDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpAppDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAppDate.Location = new System.Drawing.Point(221, 296);
            this.dtpAppDate.Name = "dtpAppDate";
            this.dtpAppDate.Size = new System.Drawing.Size(344, 29);
            this.dtpAppDate.TabIndex = 130;
            this.dtpAppDate.ValueChanged += new System.EventHandler(this.dtpAppDate_ValueChanged);
            // 
            // tpAppTime
            // 
            this.tpAppTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tpAppTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpAppTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.tpAppTime.Location = new System.Drawing.Point(221, 369);
            this.tpAppTime.Name = "tpAppTime";
            this.tpAppTime.ShowUpDown = true;
            this.tpAppTime.Size = new System.Drawing.Size(344, 29);
            this.tpAppTime.TabIndex = 131;
            this.tpAppTime.ValueChanged += new System.EventHandler(this.tpAppTime_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(119, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 132;
            this.label3.Text = "Date:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(119, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 25);
            this.label6.TabIndex = 133;
            this.label6.Text = "Time:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(119, 444);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 25);
            this.label8.TabIndex = 134;
            this.label8.Text = "Type:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // cbAppType
            // 
            this.cbAppType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbAppType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAppType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbAppType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAppType.FormattingEnabled = true;
            this.cbAppType.Location = new System.Drawing.Point(221, 441);
            this.cbAppType.Name = "cbAppType";
            this.cbAppType.Size = new System.Drawing.Size(344, 33);
            this.cbAppType.TabIndex = 135;
            this.cbAppType.SelectedIndexChanged += new System.EventHandler(this.cbAppType_SelectedIndexChanged);
            // 
            // btnScheduleAppointment
            // 
            this.btnScheduleAppointment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnScheduleAppointment.BackColor = System.Drawing.Color.Navy;
            this.btnScheduleAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScheduleAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScheduleAppointment.ForeColor = System.Drawing.Color.White;
            this.btnScheduleAppointment.Location = new System.Drawing.Point(468, 587);
            this.btnScheduleAppointment.Name = "btnScheduleAppointment";
            this.btnScheduleAppointment.Size = new System.Drawing.Size(182, 62);
            this.btnScheduleAppointment.TabIndex = 136;
            this.btnScheduleAppointment.Text = "Schedule Appointment";
            this.btnScheduleAppointment.UseVisualStyleBackColor = false;
            this.btnScheduleAppointment.Click += new System.EventHandler(this.btnScheduleAppointment_Click);
            // 
            // lblAppType
            // 
            this.lblAppType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAppType.AutoSize = true;
            this.lblAppType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppType.ForeColor = System.Drawing.Color.Red;
            this.lblAppType.Location = new System.Drawing.Point(939, 480);
            this.lblAppType.Name = "lblAppType";
            this.lblAppType.Size = new System.Drawing.Size(91, 20);
            this.lblAppType.TabIndex = 147;
            this.lblAppType.Text = "Pick A Type";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(779, 480);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 20);
            this.label9.TabIndex = 146;
            this.label9.Text = "Appointment Type";
            // 
            // lblAppTime
            // 
            this.lblAppTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAppTime.AutoSize = true;
            this.lblAppTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppTime.ForeColor = System.Drawing.Color.Red;
            this.lblAppTime.Location = new System.Drawing.Point(938, 447);
            this.lblAppTime.Name = "lblAppTime";
            this.lblAppTime.Size = new System.Drawing.Size(91, 20);
            this.lblAppTime.TabIndex = 145;
            this.lblAppTime.Text = "Pick A Time";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(778, 447);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 20);
            this.label4.TabIndex = 144;
            this.label4.Text = "Appointment Time:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(778, 413);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 20);
            this.label5.TabIndex = 143;
            this.label5.Text = "Appointment Date:";
            // 
            // lblAppDate
            // 
            this.lblAppDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDate.ForeColor = System.Drawing.Color.Red;
            this.lblAppDate.Location = new System.Drawing.Point(938, 413);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(92, 20);
            this.lblAppDate.TabIndex = 142;
            this.lblAppDate.Text = "Pick A Date";
            // 
            // lblPatientName
            // 
            this.lblPatientName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName.Location = new System.Drawing.Point(904, 381);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(152, 20);
            this.lblPatientName.TabIndex = 141;
            this.lblPatientName.Text = "NO NAME PASSED";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(778, 381);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 140;
            this.label2.Text = "Patient Name:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(778, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 139;
            this.label1.Text = "Patient ID:";
            // 
            // lblPatientID
            // 
            this.lblPatientID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPatientID.AutoSize = true;
            this.lblPatientID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientID.Location = new System.Drawing.Point(879, 347);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(123, 20);
            this.lblPatientID.TabIndex = 138;
            this.lblPatientID.Text = "NO ID PASSED";
            // 
            // btnPrintAppCopy
            // 
            this.btnPrintAppCopy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrintAppCopy.BackColor = System.Drawing.Color.MediumBlue;
            this.btnPrintAppCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintAppCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintAppCopy.ForeColor = System.Drawing.Color.White;
            this.btnPrintAppCopy.Location = new System.Drawing.Point(942, 567);
            this.btnPrintAppCopy.Name = "btnPrintAppCopy";
            this.btnPrintAppCopy.Size = new System.Drawing.Size(184, 46);
            this.btnPrintAppCopy.TabIndex = 148;
            this.btnPrintAppCopy.Text = "Print A Copy";
            this.btnPrintAppCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintAppCopy.UseVisualStyleBackColor = false;
            this.btnPrintAppCopy.Visible = false;
            this.btnPrintAppCopy.Click += new System.EventHandler(this.btnPrintAppCopy_Click);
            // 
            // panelAppMessage
            // 
            this.panelAppMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelAppMessage.BackColor = System.Drawing.Color.Red;
            this.panelAppMessage.Controls.Add(this.lblDBFeedback);
            this.panelAppMessage.Location = new System.Drawing.Point(252, 218);
            this.panelAppMessage.Name = "panelAppMessage";
            this.panelAppMessage.Size = new System.Drawing.Size(269, 46);
            this.panelAppMessage.TabIndex = 150;
            this.panelAppMessage.Visible = false;
            // 
            // lblDBFeedback
            // 
            this.lblDBFeedback.AutoSize = true;
            this.lblDBFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDBFeedback.ForeColor = System.Drawing.Color.White;
            this.lblDBFeedback.Location = new System.Drawing.Point(18, 12);
            this.lblDBFeedback.Name = "lblDBFeedback";
            this.lblDBFeedback.Size = new System.Drawing.Size(197, 20);
            this.lblDBFeedback.TabIndex = 0;
            this.lblDBFeedback.Text = "Appointment Did Not Save";
            // 
            // lblFeedback
            // 
            this.lblFeedback.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeedback.ForeColor = System.Drawing.Color.Red;
            this.lblFeedback.Location = new System.Drawing.Point(30, 595);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(0, 18);
            this.lblFeedback.TabIndex = 151;
            // 
            // printAppointment
            // 
            this.printAppointment.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printAppointment_PrintPage);
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.printAppointment;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // printDialog
            // 
            this.printDialog.Document = this.printAppointment;
            this.printDialog.UseEXDialog = true;
            // 
            // cbAppAddress
            // 
            this.cbAppAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbAppAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAppAddress.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbAppAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAppAddress.FormattingEnabled = true;
            this.cbAppAddress.Location = new System.Drawing.Point(221, 502);
            this.cbAppAddress.Name = "cbAppAddress";
            this.cbAppAddress.Size = new System.Drawing.Size(344, 33);
            this.cbAppAddress.TabIndex = 153;
            this.cbAppAddress.SelectedIndexChanged += new System.EventHandler(this.cbAppAddress_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(81, 505);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 25);
            this.label10.TabIndex = 152;
            this.label10.Text = "Location:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(709, 93);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(451, 707);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 137;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(16, 93);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(591, 146);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 121;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(29, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1275, 656);
            this.Controls.Add(this.cbAppAddress);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.panelAppMessage);
            this.Controls.Add(this.btnPrintAppCopy);
            this.Controls.Add(this.lblAppType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblAppTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblAppDate);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPatientID);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnScheduleAppointment);
            this.Controls.Add(this.cbAppType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tpAppTime);
            this.Controls.Add(this.dtpAppDate);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Name = "AppointmentForm";
            this.Text = "AppointmentForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelAppMessage.ResumeLayout(false);
            this.panelAppMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBackHome;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DateTimePicker dtpAppDate;
        private System.Windows.Forms.DateTimePicker tpAppTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbAppType;
        private System.Windows.Forms.Button btnScheduleAppointment;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblAppType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblAppTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPatientID;
        private System.Windows.Forms.Button btnPrintAppCopy;
        private System.Windows.Forms.Panel panelAppMessage;
        private System.Windows.Forms.Label lblDBFeedback;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.Button btnBackToProfile;
        private System.Drawing.Printing.PrintDocument printAppointment;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.ComboBox cbAppAddress;
        private System.Windows.Forms.Label label10;
    }
}