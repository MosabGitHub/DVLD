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

namespace DVLD
{
    public partial class addEditNewUserFrm : Form
    {
        public delegate void UpdateUserInfoDelegate(object sender, EventArgs e);

        public  event UpdateUserInfoDelegate evUserUpdated;

        public enum enMode
        {
            AddNew,
            Update,
            changePassword
        }
        private enMode _Mode;

        private int _personID = -1;
        private int _userID = -1;
        private string _validUserName = null;
        private bool UserWantChangePassword = false;

        clsUserService userService = new clsUserService();
        private void _uploadData()
        {
            _loadUserInfoAndDerivePersonID();
            _loadPersonInfo();//PersonID will derive through user obj. 
        }
        private void _SettingsBasedOnMode()
        {
            if (_Mode == enMode.AddNew)
            {
                filterCtrl1.evPersonIsFounded += FilterCtrl_PersonIsFounded;
                tabControl1.Selecting += _MyTabControl_Selecting;
                btnNext.Enabled = false;
            }


            else if (_Mode == enMode.Update)//Update user
            {
                lbMain.Text = "Update user";
                filterCtrl1.Enabled = false;
                btnNext.Enabled = true;
                btnChangePassword.Visible = true;
                tbPassword.Enabled = true;
                tbConfirmPassowrd.Enabled = false;
                if (_userID != -1)
                    lbID.Text = _userID.ToString();
            }
            else if (_Mode == enMode.changePassword)
            {
                lbMain.Text = "Update user";
                filterCtrl1.Enabled = false;
                btnNext.Enabled = true;
                btnChangePassword.Visible = true;
                if (_userID != -1)
                    lbID.Text = _userID.ToString();

                pbOldPassword.Visible = true;
                lbOldPassword.Visible = true;
                tbOldPassword.Visible = true; 
                lbPassword.Enabled = false;
                tbConfirmPassowrd.Enabled = false;
                tbUserName.Enabled = false;
                UserWantChangePassword = true;
                lbPassword.Text = "New Password";
            }

        }
        private void _MyTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            // Check if the user is trying to select the restricted tab

            if (e.TabPage == tpLoginInfo) // 'tpLoginInfo' is the TabPage you want to restrict
            {
                // Check your specific condition

                if (!userService.isThisPersonIDconnectedToUser(_personID))
                {

                    tabControl1.SelectedTab = tpLoginInfo;

                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("You cannot access this tab , Person information is connected already to a user in the system", "Access Denied",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void _EnableNextButton()
        {
            btnNext.Enabled = true;

        }
        private void resetPersonInfoCtrl()
        {
            personInfoCtrl1.reset();
            btnNext.Enabled = false;
        }
        public addEditNewUserFrm()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
            _uploadData();
            _SettingsBasedOnMode();
        }
        public addEditNewUserFrm(int userID)
        {
            InitializeComponent();
            this._Mode = enMode.Update;
            this._userID = userID;
            _uploadData();
            _SettingsBasedOnMode();
        }
        private void FilterCtrl_PersonIsFounded(object sender, clsCustomEventArgs e)
        {
            //Load person info in ctrl.
            if (e.PersonID != -1)
            {
                personInfoCtrl1.loadPersonInfo(e.PersonID);
                btnNext.Enabled = true;
                _personID = e.PersonID;
            }
            else
            {
                resetPersonInfoCtrl();
                MessageBox.Show("person is not exists in the system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _loadPersonInfo()
        {
            if (_personID != -1)
            {
                personInfoCtrl1.loadPersonInfo(_personID);
            }
        }
        private void _loadUserInfoAndDerivePersonID()
        {
            clsUser user = userService.Find(_userID);
            if (user != null)
            {

                _personID = user.personID;
                //Upload user DATA.
                lbID.Text = user.UserID.ToString();
                tbUserName.Text = user.userName;
                tbPassword.Text = "";
                tbConfirmPassowrd.Text = "";
                cbIsActive.Checked = user.isActive;
                _validUserName = user.userName;
            }
            
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                try
                {
                    if (!userService.isThisPersonIDconnectedToUser(_personID))
                    {
                        tabControl1.SelectedTab = tpLoginInfo;
                    }
                    else
                    {
                        MessageBox.Show("Person already connected with a user in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        resetPersonInfoCtrl();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    resetPersonInfoCtrl();
                }
            }
            else if (_Mode == enMode.Update)
            {
                tabControl1.SelectedTab = tpLoginInfo;

            }
        }
        private bool _isUserNameValid()
        {
            if (tbUserName.Text != _validUserName)
            {
                if (userService.isUserNameUnique(tbUserName.Text.Trim()))
                {
                    _validUserName = tbUserName.Text.Trim();//input username
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return true;


        }
        private bool _checkUserName()
        {
            if (!string.IsNullOrEmpty(tbUserName.Text) && _isUserNameValid())
                return true;
            else
                return false;
        }
        private bool _ArePasswordsMatch()
        {
            return (tbPassword.Text == tbConfirmPassowrd.Text);
        }
        private bool _checkPassword()
        {
            //Are both password match
            
                return _ArePasswordsMatch();
       
          
        }
        private bool _areFormInputsValid()
        {
            return btnSave.Enabled = _checkUserName() && _checkPassword();

        }
        private void tbUserName_TextChanged(object sender, EventArgs e)
        {

            _areFormInputsValid();
        }
        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            _areFormInputsValid();

        }
        private void cbIsActive_TextChanged(object sender, EventArgs e)
        {
            _areFormInputsValid();

        }
        private void tbUserName_Validating(object sender, CancelEventArgs e)
        {
            if (tbUserName.Text.Length > 15)
            {
                // Show error icon and tooltip
                errorProvider.SetError(tbUserName, "Maximum length is 15 charater.");
                tbUserName.Focus();
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(tbUserName, "");
            }
        }
        private void tbUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!ValidationUtility.IsValidNameCharacter(e.KeyChar, out string errorMessage))
            {
                // Cancel the key press
                e.Handled = true;

                // Show error icon and tooltip
                errorProvider.SetError(tbUserName, errorMessage);
            }
            else
            {
                e.Handled = false;
                errorProvider.SetError(tbUserName, "");
            }
            //errorProvider.SetError(tbUserName, "");

        }
        private void flipMode(enMode mode)
        {
            if (mode == enMode.AddNew)
            {
                _Mode = enMode.Update;
            }
            else
            {
                _Mode = enMode.AddNew;
            }
        }

        private clsUser _userWantToUpdate()
        {
            if(_userID!=-1)
            return new clsUser(Convert.ToInt32(_userID),tbUserName.Text, tbPassword.Text, cbIsActive.Checked);

            return null;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (_Mode == enMode.AddNew)
                {
                    clsPersonService clsPersonService = new clsPersonService(clsPersonService.Mode.AddNew);

                    if (_areFormInputsValid() && clsPersonService.IsExist(_personID))
                    {
                        clsUser newUser = userService.createUser(tbUserName.Text, tbPassword.Text, cbIsActive.Checked, _personID);
                        //Change Mode.
                        if (newUser != null)
                        {
                            _userID = newUser.UserID;
                            flipMode(enMode.AddNew);
                            _SettingsBasedOnMode();           
                            MessageBox.Show("user Added successfully.", "failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }


                    }
                    
                    else
                    {
                        MessageBox.Show("Person Couldn't be found.", "failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return; 
                    }

                }
                

                else if (_Mode == enMode.Update)
                {
                    clsUser updateUser = _userWantToUpdate();

                    if (updateUser != null && _areFormInputsValid() && userService.verifyPasswordInput(_userID, tbPassword.Text) &&
                       userService.updateUserInfo(updateUser))
                    {

                        MessageBox.Show("User Updated successfully", "succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        evUserUpdated?.Invoke(this, EventArgs.Empty);
                        btnSave.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Failed to update user successfully, due to wrong password or something else.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }

                else if (_Mode == enMode.changePassword)
                {

                    clsUser updateUser = _userWantToUpdate();

                    if (updateUser != null && _areFormInputsValid() && userService.verifyPasswordInput(_userID, tbOldPassword.Text) &&
                        userService.updateUserInfo(updateUser))

                    {

                        MessageBox.Show("User Updated successfully", "succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        evUserUpdated?.Invoke(this, EventArgs.Empty);

                    }
                    else
                    {
                        MessageBox.Show("Failed to update user successfully, due to wrong password or something else.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }


            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Error:\t" + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void addEditNewUserFrm_Load(object sender, EventArgs e)
        {

        }
        private void tbOldPassword_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbOldPassword.Text))
            {
                errorProvider.SetError(tbOldPassword, "You can't left it blank.");
            }
            else if (!userService.verifyPasswordInput(_userID, tbOldPassword.Text))
            {
                errorProvider.SetError(tbOldPassword, "Password isn't valid.");

            }
            else
            {//Valid.
                errorProvider.SetError(tbOldPassword, "");
                tbPassword.Enabled = true;
            }
        }
        private void tbPassword_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                errorProvider.SetError(tbPassword, "You can't left it blank.");
            }

            else if (_Mode==enMode.Update)
            {//Valid.
                if (!userService.verifyPasswordInput(_userID, tbPassword.Text))
                    errorProvider.SetError(tbPassword, "Password isn't valid.");

                else
                {
                    errorProvider.SetError(tbPassword, "");
                    tbConfirmPassowrd.Enabled = true;
                }
            }
            else
            {
                errorProvider.SetError(tbPassword, "");
                tbConfirmPassowrd.Enabled = true;
            }


        }
        private void changePassword_Click_1(object sender, EventArgs e)
        {
            _Mode = enMode.changePassword;
            _SettingsBasedOnMode();

        }
        private void tbConfirmPassowrd_Validated(object sender, EventArgs e)
        {
            if (!_areFormInputsValid())
            {
                errorProvider.SetError(tbConfirmPassowrd, "Not match");
            }
            else
            {
                errorProvider.SetError(tbConfirmPassowrd, "");
            }
        }

        private void personInfoCtrl1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

    

