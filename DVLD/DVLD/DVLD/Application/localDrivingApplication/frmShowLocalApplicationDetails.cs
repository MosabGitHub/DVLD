using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Application.localDrivingApplication
{
    public partial class frmShowLocalApplicationDetails : Form
    {
        public frmShowLocalApplicationDetails(int LocalapplicationID)
        {
            InitializeComponent();
            applicationInfoCtrl1.loadApplicationInfo(LocalapplicationID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
