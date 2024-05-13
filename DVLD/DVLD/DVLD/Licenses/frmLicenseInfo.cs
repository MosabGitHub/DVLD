using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmLicenseInfo : Form
    {
        public frmLicenseInfo(int licenseID)
        {

            InitializeComponent();
            driverLicenseInfoCtrl1.LoadDriverLicenseInfoCtrl(licenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void driverLicenseInfoCtrl1_Load(object sender, EventArgs e)
        {

        }
    }
}
