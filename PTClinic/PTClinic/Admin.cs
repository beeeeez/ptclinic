using System;
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
    public partial class Admin : Form
    {
        private Form Login;

        public Admin(Form Login)
        {
            InitializeComponent();

            this.Login = Login;
            Login.Hide();

            setButtonIcon();

            // Mouse Enter events for cards
            this.pbBtnNewPatient.MouseEnter += new EventHandler(pbBtnNewPatient_MouseEnter);
            this.pbBtnVisit.MouseEnter += new EventHandler(pbBtnVisit_MouseEnter);
            this.pbBtnNewPatient.MouseLeave += new EventHandler(pbBtnNewPatient_MouseLeave);
            this.pbBtnVisit.MouseLeave += new EventHandler(pbBtnVisit_MouseLeave);
        }

        private void setButtonIcon()
        {
            btnLogOut.Image = Image.FromFile("..\\..\\Resources\\ic_power_settings_new_white_18dp_1x.png");
     

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {

        }

        private void  pbBtnNewPatient_Click(object sender, EventArgs e)
        {
            // ON CLICK GO TO NEW PATIENT FORM

        }

        private void pbBtnVisit_Click(object sender, EventArgs e)
        {
            // ON CLICK GO TO PATIENT VISIT FORM
        }


        private void pbBtnNewPatient_MouseEnter(object sender, EventArgs e)
        {
            // ADD BORDER
            pbBtnNewPatient.BorderStyle = BorderStyle.FixedSingle;

        }

        private void pbBtnVisit_MouseEnter(object sender, EventArgs e)
        {
            // ADD BORDER
            pbBtnVisit.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pbBtnNewPatient_MouseLeave(object sender, EventArgs e)
        {
            // REMOVE BORDER
            pbBtnNewPatient.BorderStyle = BorderStyle.None;

        }

        private void pbBtnVisit_MouseLeave(object sender, EventArgs e)
        {
            // REMOVE BORDER
            pbBtnVisit.BorderStyle = BorderStyle.None;
        }
    }
}
