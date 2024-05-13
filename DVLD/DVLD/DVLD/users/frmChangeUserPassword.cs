using clsUsers;
using DVLD.ctrls;
using PersonClass;
using PersonServiceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD.addEditNewUserFrm;

namespace DVLD.users
{
    public partial class frmChangeUserPassword : Form
    {
        private clsUser _user;
      
        private clsUserService _clsUserService=new clsUserService();    
        private bool _verifyPersonByID(int personID)
        {
            return clsPersonService.IsExist(personID);
            
        }
        private void _loadPersonInfo(int personID)
        {
            if (_verifyPersonByID(personID))
            {
                personInfoCtrl1.loadPersonInfo(personID);
            }
        }
        private void _getUser(int userID)
       {
            _user = _clsUserService.Find(userID);
       }
        private void _loadLoginInfo()
        {
            loginInfoCtrl1.loadLoginInfo(_user.UserID, _user.userName, _user.isActive);
        }
        public frmChangeUserPassword(int userID)
        {

            InitializeComponent();
            _getUser(userID);
            _loadLoginInfo();
            _loadPersonInfo(_user.personID);

        }
        private void currentPassword_Validated(object sender, EventArgs e)
        {
            //Verify password
            if (string.IsNullOrEmpty(tbCurrentPassword.Text))
            {
                epPassword.SetError(tbCurrentPassword, "You can't left it blank.");
            }

            else if (!_clsUserService.verifyPasswordInput(_user.UserID,tbCurrentPassword.Text))
            {
                epPassword.SetError(tbCurrentPassword, "Password is not right,try something else.");
            }
            else
            {
                epPassword.SetError(tbCurrentPassword, "");
                tbNewPassword.Enabled = true;

            }

        }
        private void tbNewPassword_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNewPassword.Text))
            {
                epPassword.SetError(tbNewPassword, "You can't left it blank.");
            }   
            else if (!_ArePasswordsMatch())
            {
                epPassword.SetError(tbNewPassword, "Not match");

            }
            else
            {
                epPassword.SetError(tbNewPassword, "");

            }
        }
        private void tbConfirmPassword_Validated(object sender, EventArgs e)
        {
            if (!_ArePasswordsMatch())
            {
                epPassword.SetError(tbConfirmPassword, "Not match");
            }
            else
            {
                epPassword.SetError(tbNewPassword, "");

                epPassword.SetError(tbConfirmPassword, "");
            }
        }
        private bool _ArePasswordsMatch()
        {

            if (tbNewPassword.Text != tbConfirmPassword.Text)
                return false;
            return true;

        }
        private bool _areAllBoxesFilled()
        {
            if (!string.IsNullOrEmpty(tbNewPassword.Text) && !string.IsNullOrEmpty(tbCurrentPassword.Text) &&! string.IsNullOrEmpty(tbConfirmPassword.Text))
                return true;

            return false;
        }
      
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private clsUser _userWantToUpdate()
        {
            if (loginInfoCtrl1.userID != -1)
                return new clsUser(loginInfoCtrl1.userID, loginInfoCtrl1.userName, tbNewPassword.Text, loginInfoCtrl1.isActive);

            return null;

        }
        private void _freeze()
        {
            tbCurrentPassword.Enabled = false;
            tbNewPassword.Enabled = false;
            tbConfirmPassword.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            clsUser updateUserPassword = _userWantToUpdate();
            try
            {
                if (_ArePasswordsMatch() && _clsUserService.verifyPasswordInput(loginInfoCtrl1.userID, tbCurrentPassword.Text) //Check current password if it's right
                    && _clsUserService.updateUserInfo(updateUserPassword))
                {

                    MessageBox.Show("User Updated successfully", "succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _freeze();
                }
                else
                {
                    MessageBox.Show("Failed to update user successfully, due to wrong password or something else.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:"+ex.Message,"Failed",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
             btnSave.Enabled = _areAllBoxesFilled() && _ArePasswordsMatch();


        }
    }
}
