using DVLD.ctrls;
using PersonClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddEditPerson : Form
    {
        public delegate void UpdatePersonInfoDelegate(object sender, bool isUpdated);

        public event UpdatePersonInfoDelegate evPersonUpdated;

        public delegate void AddPersonDelegate(object sender, clsCustomEventArgs e);

        public event AddPersonDelegate evAddPerson;//Return ID to custom?filter ctrl in manger users.

        enum FrmMode
        {
            AddNew,
            Update
        }
        private FrmMode _mode { set; get; }
        
        private int _ID = -1;
        private void settingsBasedOnMode()
        {
            // Assuming your custom control instance is named 'myCustomControl'
            // Subscribe to the event
            addEditPersonInfo2.RequestFormClose += AddEditPersonInfo_RequestFormClose;

            switch (_mode)
            {
                case FrmMode.AddNew:
                    {
                        addEditPersonInfo2.ID = _ID;
                        addEditPersonInfo2.Mode = AddEditPersonInfo.ControlMode.AddNew;
                        addEditPersonInfo2.evAddPersonCtrl += _AddEditPersonCtrl_AddNewPerson;
                        break;
                    }
                
                case FrmMode.Update:
                    {                            
                        addEditPersonInfo2.ID = _ID;
                        addEditPersonInfo2.Mode = AddEditPersonInfo.ControlMode.Update;
                        lbHeader.Text = "Edit Person";
                        lbPersonID.Text = _ID.ToString();
                        addEditPersonInfo2.UpdatePerson += FrmAddEditPerson_PersonUpdated;
                        break;
                    }
            
            }
        }
        protected virtual void _AddEditPersonCtrl_AddNewPerson(object sender, clsCustomEventArgs e)
        {
            _ID = e.PersonID;
            _mode = FrmMode.Update;
            settingsBasedOnMode();
            evAddPerson?.Invoke(this, e);
        }
        private void FrmAddEditPerson_PersonUpdated(object sender, EventArgs e)
        {
           
            OnMethodPersonUpdatedExecuted();
        }
        protected virtual void OnMethodPersonUpdatedExecuted()
        {
            evPersonUpdated?.Invoke(this, true);
        }
        private void loadPersonInfo()
        {
          addEditPersonInfo2.loadPersonInfo(_ID);
        }
        private void loadBasedOnMode()
        {
            switch (_mode)
            {
                case FrmMode.AddNew:
                    {
                        break;
                    }
                case FrmMode.Update:
                    {
                        loadPersonInfo();
                        break;
                    }
            }
        }
        private void AddEditPersonInfo_RequestFormClose(object sender, EventArgs e)
        {
            this.Close(); // This will close the form
        }
        public frmAddEditPerson()
        {
            InitializeComponent();
            _mode = FrmMode.AddNew;//Add
            loadBasedOnMode();
            settingsBasedOnMode();
           
        }   
        public frmAddEditPerson(int ID)
        {
            InitializeComponent();
            _mode = FrmMode.Update;//Update\
            this._ID = ID;
            loadBasedOnMode();
            settingsBasedOnMode();
        }

        private void addEditPersonInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
