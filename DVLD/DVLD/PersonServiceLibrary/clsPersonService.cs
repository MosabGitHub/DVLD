using System;
using System.Collections.Generic;
using System.Data;
using System.Deployment.Internal;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using _PersonDataAccess;
using PersonClass;
namespace PersonServiceLibrary
{
    public class clsPersonService
    {
        private   int _ID=-1;
        public enum Mode
        {
            AddNew,
            Update
        }
        private  Mode _Mode;
        public clsPersonService(Mode mode)
        {
            _Mode= mode;
        }
        private bool _AddNewPerson(clsPerson person)
        {
            try
            {
             
                person.setID= clsPersonDataAccess.AddNewPerson(person.NationalNumber, person.FirstName, person.SecondName, person.ThirdName, person.LastName,
                    person.Gender, person.Birth, person.PhoneNumber, person.Email.Trim(), person.Address, person.Nationality, person.PersonImagePath);

                return person.ID != -1;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        private  bool _UpdatePerson(clsPerson person)
        {
            return clsPersonDataAccess.UpdatePersonInfo(person.ID, person.NationalNumber, person.FirstName, person.SecondName, person.ThirdName, person.LastName,
                    person.Gender, person.Birth, person.PhoneNumber, person.Email.Trim(), person.Address, person.Nationality, person.PersonImagePath);
        }
        private async static Task<DataTable> _GetAllPeopleByColumn<T>(string columnName, T columnValue)
        {
            return  await clsPersonDataAccess.GetAllPeopleByColumnAsync(columnName, columnValue);
        } 
        public  bool save(clsPerson person)
        {

            switch (_Mode)
            {
                case Mode.AddNew:
                    {
                        if (_AddNewPerson(person))
                        {
                            _Mode = Mode.Update;
                            return true;
                        }

                        break;
                    }
                case Mode.Update:
                    {
                        return _UpdatePerson(person);

                    }
            }

            return false;

        }
        public static Task<DataTable> GetAllPeopleByID(int columnValue)
        {
            return _GetAllPeopleByColumn("ID", columnValue);
        }
        public static Task<DataTable> GetAllPeopleByNationalNumber(string columnValue)
        {
            return _GetAllPeopleByColumn("NationalNumber", columnValue);
        }
        public static Task<DataTable> GetAllPeopleByFirstName(string columnValue)
        {
            return _GetAllPeopleByColumn("FirstName", columnValue);
        }
        public static Task<DataTable> GetAllPeopleBySecondName(string columnValue)
        {
            return _GetAllPeopleByColumn("SecondName", columnValue);
        }
        public static Task<DataTable> GetAllPeopleByThirdName(string columnValue)
        {
            return _GetAllPeopleByColumn("ThirdName", columnValue);
        }
        public static Task<DataTable> GetAllPeopleByLastName(string columnValue)
        {
            return _GetAllPeopleByColumn("LastName", columnValue);
        }
        public static Task<DataTable> GetAllPeopleByGender(char columnValue)
        {
            return _GetAllPeopleByColumn("Gender", columnValue);
        }
        public static Task<DataTable> GetAllPeopleByBirth(DateTime columnValue)
        {
            return _GetAllPeopleByColumn("Birth", columnValue);
        }
        public static Task<DataTable> GetAllPeopleByPhoneNumber(string columnValue)
        {
            return _GetAllPeopleByColumn("PhoneNumber", columnValue);
        }
        public static Task<DataTable> GetAllPeopleByEmail(string columnValue)
        {
            return _GetAllPeopleByColumn("Email", columnValue);
        }
        public static Task<DataTable> GetAllPeopleByNationality(string columnValue)
        {
            return _GetAllPeopleByColumn("Nationality", columnValue);
        }
        public static  bool IsExist(int ID)
        {
            return clsPersonDataAccess.IsExist(ID);
        }
        public static bool IsExist(string NationalNo)
        {
            return clsPersonDataAccess.IsExist(NationalNo);
        }
        public static bool IsExist(int ID,string NationalNo)
        {
            return clsPersonDataAccess.IsExist(ID, NationalNo);
        }
        public static int IsExistAndReturnID(string NationalNo)
        {
            return clsPersonDataAccess.IsExistAndReturnID(NationalNo);
        }      
        public  static bool DeletePerson(ref List<int> IDs)
        {
            return clsPersonDataAccess.DeletePersonInfo(ref IDs);
        }
        public  clsPerson Find(int ID)
        {
            string nationalNumber = "", firstName = "", SecondName = "", ThirdName = "", lastName = ""
                 , phoneNumber = "", email = "", Address = "", nationality = "", personImagePath = "";
            DateTime birth = DateTime.Now;
            char gender = '!';
            

            if (clsPersonDataAccess.AccessPersonInfoByID(ID, ref nationalNumber, ref firstName, ref SecondName
                , ref ThirdName, ref lastName, ref gender, ref birth,
                ref phoneNumber, ref email, ref Address, ref nationality, ref personImagePath))
            {
                return clsPerson.CreateInstance(ID, nationalNumber, firstName, SecondName, ThirdName, lastName,
                      gender, birth, phoneNumber, email, Address, nationality, personImagePath);
                
            }
            return null;

        }
        public static clsPerson Find2(int ID)
        {
            string nationalNumber = "", firstName = "", SecondName = "", ThirdName = "", lastName = ""
                 , phoneNumber = "", email = "", Address = "", nationality = "", personImagePath = "";
            DateTime birth = DateTime.Now;
            char gender = '!';


            if (clsPersonDataAccess.AccessPersonInfoByID(ID, ref nationalNumber, ref firstName, ref SecondName
                , ref ThirdName, ref lastName, ref gender, ref birth,
                ref phoneNumber, ref email, ref Address, ref nationality, ref personImagePath))
            {
                return clsPerson.CreateInstance(ID, nationalNumber, firstName, SecondName, ThirdName, lastName,
                      gender, birth, phoneNumber, email, Address, nationality, personImagePath);

            }
            return null;

        }
        public static clsPerson Find(string NationalNumber)
        {
            int ID = -1;
                string firstName = "", SecondName = "", ThirdName = "", lastName = ""
                 , phoneNumber = "", email = "", Address = "", nationality = "", personImagePath = "";
            DateTime birth = DateTime.Now;
            char gender = '!';


            if (clsPersonDataAccess.AccessPersonInfoByNationalNumber(ref ID,NationalNumber, ref firstName, ref SecondName
                , ref ThirdName, ref lastName, ref gender, ref birth,
                ref phoneNumber, ref email, ref Address, ref nationality, ref personImagePath))
            {
                return clsPerson.CreateInstance(ID, NationalNumber, firstName, SecondName, ThirdName, lastName,
                      gender, birth, phoneNumber, email, Address, nationality, personImagePath);

            }
            return null;

        }
        public  static Task<DataTable> GetAllPeopleInfo()
        {
            return clsPersonDataAccess.GetAllPeopleInfo();
        }
    }
}
