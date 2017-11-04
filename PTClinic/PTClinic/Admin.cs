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
        }

        private void setButtonIcon()
        {
            btnLogOut.Image = Image.FromFile("..\\..\\Resources\\ic_power_settings_new_white_18dp_1x.png");
     

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {

        }
    }
}
