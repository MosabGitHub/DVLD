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
    public partial class loginInfoCtrl : UserControl
    {
        private int _userID = -1;
        private string _userName = "";
        bool _isActive=false;
        public loginInfoCtrl()
        {
            InitializeComponent();
        }

        public void loadLoginInfo(int userID,string userName , bool isActive)
        {
            this._userID = userID;
            this._userName = userName;
            this._isActive = isActive;
            lbUserID.Text= userID.ToString();
            lbUserName.Text= userName.ToString();
            if (isActive == true)
                lbIsActive.Text = "Yes";
            else
                lbIsActive.Text = "No";

        }

        public int userID
        {
            get
            {
                return _userID;
            }
        }
        public string userName
        { get { return _userName; } }

        public bool isActive
        {
            get { return _isActive ;}
        }
    }
}
