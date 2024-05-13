
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationServiceLib;
using DVLD.DTOs;
namespace MangeApplicationTypesForm
{
    public partial class frmUpdateApplicationType : Form
    {

        public delegate void evApplicationTypeUpdated(object sender , EventArgs e);
        public event evApplicationTypeUpdated onAction;
        private clsApplicationTypeDTO _getApplicationById(int applicationId)
        {
            
            return clsApplicationTypeService.GetApplicationTypeByID(applicationId);
        }
        private void _fillApplicationData(clsApplicationTypeDTO applicationType) {

            if (applicationType != null)
            {
                lbID.Text = applicationType.ID.ToString();
                tbTitle.Text = applicationType.Title;
                tbFees.Text = applicationType.Fees.ToString();
            }
            else
            {
                lbID.Text = "??";
                tbTitle.Text = "";
                tbFees.Text= "";
            }
        }
        private void _loadApplication(int applicationId)
        {
            clsApplicationTypeDTO applicationType = _getApplicationById(applicationId);
       
            if (applicationType != null)
            {
                _fillApplicationData(applicationType); 
            }
       
            else
            {
                this.Close();
            }
       
        }
        public frmUpdateApplicationType(int applicationId)
        {
            InitializeComponent();
            try
            {
                _loadApplication(applicationId);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:"+ex.Message,"Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void _freeze()
        {
            tbFees.Enabled = false;
            tbTitle.Enabled= false;
            btnSave.Enabled = false;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try {
                clsApplicationTypeService.UpdateApplicationInfo(new clsApplicationTypeDTO(Convert.ToInt16(lbID.Text), tbTitle.Text,
                    Convert.ToDouble(tbFees.Text)));

                MessageBox.Show("Application was updated successfully","Succeed",MessageBoxButtons.OK,MessageBoxIcon.Information);
                _freeze();
                onAction?.Invoke(this, EventArgs.Empty);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:"+ex.Message,"Failed",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
