using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.ctrls
{
    public partial class addEditFilterCtrl : UserControl
    {
        public delegate void eventHandlerFoundPerson(object sender, clsCustomEventArgs e);
        
        public eventHandlerFoundPerson evPersonIsFounded;
        public addEditFilterCtrl()
        {
            InitializeComponent();
            filterCtrl1.evPersonIsFounded += _foundPerson;
            filterCtrl1.evPersonIsFounded += _fillPersonData;
        }
       public void loadPersonInfo(int personID)
        {
            
            personInfoCtrl1.loadPersonInfo(personID);
        }
       
        private void _foundPerson(object sender, clsCustomEventArgs e)
        {
            this.evPersonIsFounded?.Invoke(this, e);//Inform the form that person is founded.
        }
        private void _fillPersonData(object sender, clsCustomEventArgs e)
        {
            if (e.PersonID != -1)
            {
                personInfoCtrl1.loadPersonInfo(e.PersonID);
            }
        }

    }
}
