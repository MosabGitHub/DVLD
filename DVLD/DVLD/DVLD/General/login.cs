using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clsUsers;
using DVLD.Application;
using DVLD.Application.localDrivingApplication;
using GlobalSettings;
using PersonClass;
using PersonServiceLibrary;
namespace DVLD
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        } 
    
        private void button1_Click(object sender, EventArgs e)
        {
         

        }

        private void btnLogin_Click(object sender, EventArgs e)
       {
           //     ClsAdmin admin = new ClsAdmin(tbUserName.Text, tbPassowrd.Text);
           // frmListLocalDrivingLicenseApplications form = new frmListLocalDrivingLicenseApplications();
           //       form.ShowDialog();

            if (clsUserService.IsExist(tbUserName.Text))
            {
                if (clsUserService.verifyPasswordInput(tbUserName.Text, tbPassowrd.Text))
                {
                    ClsAdmin admin = new ClsAdmin(tbUserName.Text, tbPassowrd.Text);
                    mainFrm form = new mainFrm();

                    form.ShowDialog();
                }
   
                else
                {
                    MessageBox.Show("userName or password is wrong ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            
            }
        
            else
            {
                MessageBox.Show("there is no such a userName in the system", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
