using clsUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.users
{
    public partial class frmShowUserDetails : Form
    {
        
        private int _derivedPersonIdbyUserID(int userID)
        {
            return  clsUserService.getPersonIDByUserID(userID);
        }
        private int _derivedPersonIdbyUserName(string userName)
        {
            return clsUserService.Find(userName).personID;
        }
        private (string userName,bool isActive) _derivedUserNameAndIsActiveByUserId(int userID)
        {
            return clsUserService.getUserNameAndIsActiveById(userID);
        }
        private void _loadPerson(int userID)
        {
            personInfoCtrl1.loadPersonInfo(_derivedPersonIdbyUserID(userID));

        }
        private void _loadPerson(string userName)
        {
            personInfoCtrl1.loadPersonInfo(_derivedPersonIdbyUserName(userName));

        }
        private void _loadUser(int userID)
        {
            var TupleUserNameAndIsActive=_derivedUserNameAndIsActiveByUserId(userID);
            loginInfoCtrl1.loadLoginInfo(userID, TupleUserNameAndIsActive.userName, TupleUserNameAndIsActive.isActive);

        }
        private void _loadUser(string userName)
        {

            clsUser user = clsUserService.Find(userName);
            loginInfoCtrl1.loadLoginInfo(user.UserID, user.userName, user.isActive);

        }
        public frmShowUserDetails(int userID)
        {
          
            InitializeComponent();
            _loadPerson(userID);
            _loadUser(userID);
        
        }
        public frmShowUserDetails(string userName)
        {

            InitializeComponent();
            _loadPerson(userName);
            _loadUser(userName);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
