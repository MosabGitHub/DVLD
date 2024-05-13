using DVLD.DTOs;
using GlobalSettings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.ctrls.LicenseCtrls
{
    public partial class filterInfoLicenseCtrl : UserControl
    {

        public delegate void eventHandlerFilterFoundLicense(object sender, clsCustomEventArgs e);

        public event eventHandlerFilterFoundLicense evLicenseWasFound;
        public filterInfoLicenseCtrl()
        {
            InitializeComponent();

            subscribeToEventControl();
        }

        private void subscribeToEventControl()
        {
            filterLicenseCtrl1.evSearchLicense += licenseInfo_wasFound;
        }
        private void licenseInfo_wasFound(object sender, clsCustomEventArgs e)
        {
            if(e!=null) 
            { 
            
                driverLicenseInfoCtrl1.LoadDriverLicenseInfoCtrl(e.LicenseDTO);
                evLicenseWasFound?.Invoke(this,e);
            }
            else
            {
                evLicenseWasFound?.Invoke(this, null);
            }
        }
        public void LicenseIsDetained()
        {
            driverLicenseInfoCtrl1.LicenseIsDetained();
        }
        public void Reset()
        {
            driverLicenseInfoCtrl1.Reset();
            filterLicenseCtrl1.reset();
        }
        public void IsLicenseDetained(bool isLicenseDetain)
        {
            driverLicenseInfoCtrl1.IsLicenseDetained(isLicenseDetain);
        }

        public void RefreshData(clsLicenseDTO licenseDTO)
        {
            driverLicenseInfoCtrl1.LoadDriverLicenseInfoCtrl(licenseDTO);

        }

    }
}
