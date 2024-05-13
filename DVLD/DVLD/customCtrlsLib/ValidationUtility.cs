using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace customCtrlsLib
{
    internal class ValidationUtility
    {
        public static bool IsValidIDCharachter(char character, out string errorMessage)
        {

            errorMessage = "";

            if (!char.IsDigit(character) && character != (char)Keys.Delete && character != (char)Keys.Back && character != (char)Keys.Enter)
            {
                errorMessage = "Please enter only a digit";

                return false;
            }
            return true;

        }

        public static bool IsValidNameCharacter(char character, out string errorMessage)
        {

            errorMessage = "";
            if (char.IsDigit(character) & character != (char)Keys.Delete && character != (char)Keys.Back)
            {
                errorMessage = "Please enter only a letter";

                return false;
            }
            return true;

        }
        public static bool IsValidCountry(string country, out string errorMessage)
        {
            errorMessage = "";
            if(string.IsNullOrEmpty(country)){
                errorMessage = "Please choose a country";

                return false;
            }
            return true;
        }

        public static bool IsValidPhoneNumberCharater(char character, out string errorMessage)
        {
            errorMessage = "";
            if (!char.IsDigit(character) && character != (char)Keys.Delete && character != (char)Keys.Back && character != (char)Keys.Enter)
            {
                errorMessage = "please enter digit only.";
                
                return false;
             }

            return true; 
        }
        public static bool IsValidNationalNoCharater(char character, out string errorMessage)
        {
            // Check if the entered key is a symbol
            errorMessage = "";

            if (char.IsWhiteSpace(character) && !char.IsLetterOrDigit(character)
               && character != (char)Keys.Delete && character != (char)Keys.Back && character != (char)Keys.Enter) {

                errorMessage = "Please avoid symbols.";
                return false;


            }
            return true;
                
               
        }

    }
}
