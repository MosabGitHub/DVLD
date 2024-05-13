using DriverServiceLib;
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
    public partial class frmLicenseHistory : Form
    {


        private int _getDriverID(int personID)
        {
            return clsDriverService.FindByPersonID(personID).DriverID;  
        }
      
        public frmLicenseHistory()
        {
            InitializeComponent();
             
        }
        public void LoadDataInfo(int personID)
        {
            filterCtrl4.Enabled = false;
            personInfoCtrl4.loadPersonInfo(personID);
            driverLicenseHistoryCtrl1.LoadDriverLicensesHistory(_getDriverID(personID));
        }

        private void filterCtrl1_Load(object sender, EventArgs e)
        {
            
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
