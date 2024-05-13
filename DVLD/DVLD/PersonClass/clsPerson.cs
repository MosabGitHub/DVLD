using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using _PersonDataAccess;

namespace PersonClass
{
    public class clsPerson
    {
        private int _ID;
        private string _NationalNumber;
        private string _FirstName;
        private string _SecondName;
        private string _ThirdName;
        private string _LastName;
        private char _Gender;
        private DateTime _Birth;
        private string _PhoneNumber;
        private string _Email;
        private string _Nationality;
        private string _PersonImagePath;
        private string _Address;
        private clsPerson(int ID, string nationalNumber, string firstName, string SecondName, string ThirdName, string lastName, char gender,
            DateTime birth, string phoneNumber, string email, string Address, string nationality, string PersonImagePath)
        {
            _ID = ID;
            _NationalNumber = nationalNumber;
            _FirstName = firstName;
            _SecondName = SecondName;
            _ThirdName = ThirdName;
            _LastName = lastName;
            _Gender = gender;
            _Birth = birth;
            _PhoneNumber = phoneNumber;
            _Email = email;
            _Address = Address;
            _Nationality = nationality;
            _PersonImagePath = PersonImagePath;
        }
        private bool _IsValidEmail(string Email)
        {

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(emailPattern);

            return regex.IsMatch(Email);
        }
        public int ID
        {
            get { return _ID; }

        }
        internal int setID
        {
            
            set { _ID = value; }

        }
        public string NationalNumber
        {
            get
            {
                return _NationalNumber;
            }
            set
            {
                if (value == null || string.IsNullOrEmpty(value))
                {
                    return;
                }
                else
                {
                    _NationalNumber = value;
                }
            }
        }
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _FirstName = value;
                }
            }
        }
        public string SecondName
        {
            get { return _SecondName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _SecondName = value;
                }
            }
        }
        public string ThirdName
        {
            get { return _ThirdName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _ThirdName = value;
                }
            }
        }
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _LastName = value;
                }
            }
        }
        public char Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    return;
                }
                else
                {
                    _Gender = value;
                }
            }
        }
        public DateTime Birth
        {
            get
            {
                return _Birth;
            }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    return;
                }
                else
                {
                    _Birth = value;
                }
            }
        }
        public string PhoneNumber
        {
            get
            {
                return _PhoneNumber;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.ToString().Length > 10)
                {
                    return;
                }
                else
                {
                    _PhoneNumber = value;
                }
            }
        }
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                string trimmedEmail = value?.Trim();
                if (string.IsNullOrEmpty(trimmedEmail))
                {
                    _Email = value; // Assign directly to the backing field
                }
                else if (_IsValidEmail(trimmedEmail))
                {
                    _Email = trimmedEmail;
                }
                else
                {
                    // Handle invalid email format (throw an exception, log an error, etc.)
                    throw new ArgumentException("Invalid email format");
                }
            }

        }
        public string Nationality
        {
            get
            {
                return _Nationality;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }
                else
                {
                    _Nationality = value;
                }
            }
        }
        public string PersonImagePath
        {
            get
            {
                return _PersonImagePath;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _PersonImagePath = null;
                }
                else
                {
                    _PersonImagePath = value;
                }
            }
        }
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    return;
                }
                else
                {
                    _Address = value;
                }
            }
        }
        public clsPerson(string nationalNumber, string firstName, string SecondName, string ThirdName, string lastName,
            char Gender, DateTime birth, string phoneNumber, string email, string Address, string nationality, string PersonImagePath)
        {
            _ID = -1;
            _NationalNumber = nationalNumber;
            _FirstName = firstName;
            _SecondName = SecondName;
            _ThirdName = ThirdName;
            _LastName = lastName;
            _Gender = Gender;
            _Birth = birth;
            _PhoneNumber = phoneNumber;
            _Email = email;
            _Address = Address;
            _Nationality = nationality;
            _PersonImagePath = PersonImagePath;

        }
        public void SetName(string first, string second, string third, string last)
        {
            FirstName = first;
            SecondName = second;
            ThirdName = third;
            LastName = last;
        }
        public string FullName
        {

            set
            {

                // Assuming the name is always in the format: "FirstName SecondName ThirdName LastName"
                //var parts = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //if (parts.Length >= 4)
                //{
                //    FirstName = parts[0];
                //    SecondName = parts[1];
                //    ThirdName = parts[2];
                //    LastName = parts[3];
                //}
                // Handle other cases as needed, like if parts.Length is less than 4

            }
            get
            {
                return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            }
        }

        public static clsPerson CreateInstance(int ID, string nationalNumber, string firstName, string SecondName, string ThirdName, string lastName, char gender,
            DateTime birth, string phoneNumber, string email, string Address, string nationality, string PersonImagePath)
        {
            return new clsPerson(ID, nationalNumber, firstName, SecondName, ThirdName, lastName,
                      gender, birth, phoneNumber, email, Address, nationality, PersonImagePath);
        }
    }

}
