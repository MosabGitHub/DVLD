using ApplicationDataAccess;
using DVLD.Application.localDrivingApplication;
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
using static ApplicationDataAccess.clsApplicationDataAccess;
using static DVLD.DTOs.clsApplicationDTO;

namespace DVLD.General
{
    public partial class TESTEMETHODSLAYERs : Form
    {
        public TESTEMETHODSLAYERs()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime ApplicationDate=DateTime.Now;
            DateTime lastStatusDate=DateTime.Now;
            enApplicationType ApplicationType =enApplicationType.NewLocalDrivingLicenseService;
            enStatus ApplicationStatus = enStatus.New;
            int PersonID = 3012;
            int UserCreatedByID = 3015;
            double fees = 15;
            int applicationID = 17;
            
            clsApplicationDTO clsApplicationDTO = new clsApplicationDTO(applicationID,ApplicationDate, 
                lastStatusDate, ApplicationType, ApplicationStatus,
                PersonID, UserCreatedByID,fees);

            clsLocalApplicationDTO localApplicationDTO = new clsLocalApplicationDTO(6, clsApplicationDTO, 5);

            try
            {
                clsLocalApplicationDataAccess.UpdateApplicationInfo(localApplicationDTO);
                MessageBox.Show("Success","succeed",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }catch(Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "FAlied");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplications form=new frmListLocalDrivingLicenseApplications();
            form.ShowDialog();
        }
    
    }

}
