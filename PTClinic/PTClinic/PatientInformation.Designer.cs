namespace PTClinic
{
    partial class PatientInformation
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
            this.lbPTCLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbPTCLabel
            // 
            this.lbPTCLabel.AutoSize = true;
            this.lbPTCLabel.Location = new System.Drawing.Point(250, 24);
            this.lbPTCLabel.Name = "lbPTCLabel";
            this.lbPTCLabel.Size = new System.Drawing.Size(150, 13);
            this.lbPTCLabel.TabIndex = 0;
            this.lbPTCLabel.Text = "PHYSICAL THERAPY CLINIC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "PATIENT INFORMATION";
            // 
            // PatientInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 629);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbPTCLabel);
            this.Name = "PatientInformation";
            this.Text = "Patient Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPTCLabel;
        private System.Windows.Forms.Label label2;
    }
}