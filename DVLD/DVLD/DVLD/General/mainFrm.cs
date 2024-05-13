using clsUsers;
using DVLD.Application;
using DVLD.Application.DetainAndReleaseApplication;
using DVLD.Application.DetainAndReleaseApplication.DetainApplications;
using DVLD.Application.DetainAndReleaseApplication.ReleaseApplication;
using DVLD.Application.InternationalDrivingApplication;
using DVLD.Application.localDrivingApplication;
using DVLD.Application.RenewApplication;
using DVLD.Application.Replacement_application;
using DVLD.Drivers;
using DVLD.Licenses;
using DVLD.test;
using DVLD.users;
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

namespace DVLD
{
    public partial class mainFrm : Form
    {
        public mainFrm()
        {
            InitializeComponent();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserDetails form = new frmShowUserDetails(ClsAdmin.userName);
            form.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MangeUsersFrm   form= new MangeUsersFrm();
            form.ShowDialog();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MangePeopleForm form= new MangePeopleForm();
            form.ShowDialog();
        }

        private void drivingLicenseServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplications form=new frmListLocalDrivingLicenseApplications();
            form.ShowDialog();
        }

        private void replacementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacementApplication replacementApplication = new frmReplacementApplication();
            replacementApplication.ShowDialog();
        }

        private void relaesToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void manageAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMangeApplicationTypes form= new frmMangeApplicationTypes();
            form.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplications frm = new frmListLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriversList form = new frmDriversList();
            form.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueInternationalDrivingLicense frmIssueInternationalDrivingLicense = new frmIssueInternationalDrivingLicense();
            frmIssueInternationalDrivingLicense.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmInternationalApplicationsList frmInternationalApplicationsList = new frmInternationalApplicationsList();
            frmInternationalApplicationsList.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewApplication frmRenewApplication = new frmRenewApplication();
            frmRenewApplication.ShowDialog();
        }

        private void relaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleasedApplication frmReleasedApplication = new frmReleasedApplication();
            frmReleasedApplication.ShowDialog();

        }

        private void detainLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDetainApplication frmDetainApplication = new frmDetainApplication();
            frmDetainApplication.ShowDialog();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestTypes form=new frmListTestTypes();
            form.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageDetainLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainLicenses form=new frmListDetainLicenses();
            form.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangeUserPassword form=new frmChangeUserPassword (clsUserService.Find(ClsAdmin.userName).personID);
            form.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
         
        }
    }
}
