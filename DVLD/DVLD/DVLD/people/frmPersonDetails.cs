using PersonClass;
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
    public partial class frmPersonDetails : Form
    {

        
        private int _ID = -1;

        public delegate void frmPersonDetailsDelgateUpdated(object sender, EventArgs e);

        public event frmPersonDetailsDelgateUpdated evUpdatedPerson;     
        private void _personUpdated(object sender, EventArgs e)
        {
            //Send to Mangepeople that user was updated  . 
            evUpdatedPerson?.Invoke(this, EventArgs.Empty);

        }
        public void subscribeUpdatePersonEventToControl()
        {
        
          personInfoCtrl.PersonUpdated += _personUpdated;

            
        }
        public frmPersonDetails(int ID)
        {
            InitializeComponent();
            subscribeUpdatePersonEventToControl();
            this._ID = ID;
           personInfoCtrl.loadPersonInfo(ID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
