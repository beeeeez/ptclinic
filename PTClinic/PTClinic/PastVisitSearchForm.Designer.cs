namespace PTClinic
{
    partial class PastVisitSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PastVisitSearchForm));
            this.btnViewFollowUp = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbPastFollowupVisits = new System.Windows.Forms.ComboBox();
            this.lblPatientId = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBackToProfile = new System.Windows.Forms.Button();
            this.btnBackHome = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnViewFollowUp
            // 
            this.btnViewFollowUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnViewFollowUp.BackColor = System.Drawing.Color.Navy;
            this.btnViewFollowUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewFollowUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewFollowUp.ForeColor = System.Drawing.Color.White;
            this.btnViewFollowUp.Location = new System.Drawing.Point(817, 175);
            this.btnViewFollowUp.Name = "btnViewFollowUp";
            this.btnViewFollowUp.Size = new System.Drawing.Size(175, 68);
            this.btnViewFollowUp.TabIndex = 11;
            this.btnViewFollowUp.Text = "View Follow Up ";
            this.btnViewFollowUp.UseVisualStyleBackColor = false;
            this.btnViewFollowUp.Click += new System.EventHandler(this.btnViewFollowUp_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(159, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(235, 25);
            this.label8.TabIndex = 182;
            this.label8.Text = "Past Follow Up Visits";
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.cbPastFollowupVisits);
            this.panel4.Controls.Add(this.lblPatientId);
            this.panel4.Controls.Add(this.btnViewFollowUp);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(65, 145);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1216, 386);
            this.panel4.TabIndex = 194;
            // 
            // cbPastFollowupVisits
            // 
            this.cbPastFollowupVisits.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbPastFollowupVisits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPastFollowupVisits.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbPastFollowupVisits.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPastFollowupVisits.FormattingEnabled = true;
            this.cbPastFollowupVisits.Location = new System.Drawing.Point(423, 194);
            this.cbPastFollowupVisits.Name = "cbPastFollowupVisits";
            this.cbPastFollowupVisits.Size = new System.Drawing.Size(347, 33);
            this.cbPastFollowupVisits.TabIndex = 184;
            // 
            // lblPatientId
            // 
            this.lblPatientId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPatientId.AutoSize = true;
            this.lblPatientId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientId.Location = new System.Drawing.Point(159, 99);
            this.lblPatientId.Name = "lblPatientId";
            this.lblPatientId.Size = new System.Drawing.Size(129, 25);
            this.lblPatientId.TabIndex = 183;
            this.lblPatientId.Text = "Patient ID: ";
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
            this.panel1.Size = new System.Drawing.Size(1318, 73);
            this.panel1.TabIndex = 185;
            // 
            // btnBackToProfile
            // 
            this.btnBackToProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackToProfile.BackColor = System.Drawing.Color.Navy;
            this.btnBackToProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToProfile.ForeColor = System.Drawing.Color.White;
            this.btnBackToProfile.Location = new System.Drawing.Point(846, 20);
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
            this.btnBackHome.Location = new System.Drawing.Point(1056, 20);
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
            this.btnLogOut.Location = new System.Drawing.Point(1192, 20);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(107, 34);
            this.btnLogOut.TabIndex = 75;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(79, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(312, 29);
            this.label7.TabIndex = 13;
            this.label7.Text = "View Past Follow-Up Visists";
            // 
            // PastVisitSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 749);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Name = "PastVisitSearchForm";
            this.Text = "PastVisitSearchForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnViewFollowUp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBackToProfile;
        private System.Windows.Forms.Button btnBackHome;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPatientId;
        private System.Windows.Forms.ComboBox cbPastFollowupVisits;
    }
}