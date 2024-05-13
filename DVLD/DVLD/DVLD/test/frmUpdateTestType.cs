using ApplicationServiceLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testLibrary;
using DVLD.DTOs;
namespace DVLD.test
{
    public partial class frmUpdateTestType : Form
    {
        public delegate void evTestUpdated(object sender, EventArgs e);
        public event evTestUpdated OnAction;
        public frmUpdateTestType(int applicationId)
        {
            InitializeComponent();
            try
            {
                _loadTestType(applicationId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private clsTestTypeDTO _getTesTypetById(int TestId)
        {

            return clsTestTypeService.GetTestTypeByID(TestId);
        }
        private void _fillTestTypeData(clsTestTypeDTO testType)
        {

            if (testType != null)
            {
                lbID.Text = testType.ID.ToString();
                tbTitle.Text = testType.Title;
                tbDescription.Text = testType.Description.ToString();
                tbFees.Text = testType.Fees.ToString();
            }
            else
            {
                lbID.Text = "??";
                tbTitle.Text = "";
                tbDescription.Text = "";
                tbFees.Text = "";
            }
        }
        private void _loadTestType(int applicationId)
        {
            clsTestTypeDTO testType = _getTesTypetById(applicationId);

            if (testType != null)
            {
                _fillTestTypeData(testType);
            }

            else
            {
                this.Close();
            }

        }
        public void _freeze()
        {
            tbFees.Enabled = false;
            tbTitle.Enabled = false;
            btnSave.Enabled = false;
            tbDescription.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                clsTestTypeService.UpdateTestInfo(new clsTestTypeDTO(Convert.ToInt16(lbID.Text), tbTitle.Text,
                    tbDescription.Text,Convert.ToDouble(tbFees.Text)));

                MessageBox.Show("Test type was updated successfully", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _freeze();
                OnAction?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
