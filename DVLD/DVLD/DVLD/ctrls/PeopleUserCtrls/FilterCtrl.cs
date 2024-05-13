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

namespace DVLD.ctrls
{
    public partial class FilterCtrl : UserControl
    {

        public delegate void customEventHandler(object sender, clsCustomEventArgs e);

        public event customEventHandler evPersonIsFounded;

        public event customEventHandler evPersonIsAdded;
        private void NewPersonWasAddedByCustomCtrl(object sender , clsCustomEventArgs e)
        {
            personIsFound(e.PersonID);
        }
        public FilterCtrl()
        {
            InitializeComponent();
        }
    
        protected void personIsFound(int ID)
        {
            evPersonIsFounded.Invoke(this, new clsCustomEventArgs(ID));    
        }      
        private void PersonNationalnumberBoxFilter(object sender, KeyPressEventArgs e)
        {
            // Check if the entered key is a symbol
            if (!ValidationUtility.IsValidNationalNoCharater(e.KeyChar, out string errorMessage))
            {
                // Cancel the key press
                e.Handled = true;

                // Show error icon and tooltip
                epFilter.SetError(tbFilter, errorMessage);
            }

            else
            {
                // Clear error when a valid key is pressed
                epFilter.SetError(tbFilter, "");

            }
        }
        private int _searchByPersonID()
        {
            try
            {
                if (int.TryParse(tbFilter.Text, out int ID))
                {
                    if (clsPersonService.IsExist(ID))
                    {
                        
                        return ID;
                    }
                    else 
                        return -1;

                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error:"+ex.Message,ex);
            }
            return -1;
        }
        private int _searchByPersonNationalNumberAndReturnPersonID()
        {
            try {
               
                int personID = clsPersonService.IsExistAndReturnID(tbFilter.Text.Trim().ToLower());
                return personID;
           
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
            
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {

             switch(cbFilter.SelectedItem)
            {
                case "National No":
                    {
                        personIsFound(_searchByPersonNationalNumberAndReturnPersonID());
                        break;
                    }
                case "Person ID":
                    {
                        personIsFound(_searchByPersonID());        
                        break;
                    }
            }
         
            return; 
           
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson form = new frmAddEditPerson();
            form.evAddPerson += NewPersonWasAddedByCustomCtrl;
            form.ShowDialog();
        }
        private void FilterCtrl_Load(object sender, EventArgs e)
        {

        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}

