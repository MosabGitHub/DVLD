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

namespace customCtrlsLib
{
    public partial class FilterCtrl : UserControl
    {
        public FilterCtrl()
        {
            InitializeComponent();
        }

        private  void PersonNationalnumberBoxFilter(object sender, KeyPressEventArgs e)
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

        private bool btnSearch_Click(object sender, EventArgs e)
        {
            bool isFound = false;

            if (int.TryParse(tbFilter.Text, out int ID))
            {
                 isFound = clsPersonService.IsExist(ID);
            }

            return isFound;
            
        }
    }

}
