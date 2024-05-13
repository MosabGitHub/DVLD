using PersonClass;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UserDataAccess;
using SecurityLib;
using System.Data;
using PersonServiceLibrary;
using System.ComponentModel;
namespace clsUsers
{
    public class clsUserService
    {
        public class clsHashPasswordAndSalt
        {
            public string hashPassword { get; }
            public string salt { get; }
           public clsHashPasswordAndSalt(string password, string salt)
            {
                hashPassword = password;
                this.salt = salt;
            }
        }
        public enum Mode
        {
            AddNew,
            Update
        }
        public enum enIsActive
        {
            None,
            No,
            Yes
        }
        private string _salt { get; set; }

        private Mode _mode;  
        private  int _AddNewUserToDataBaseAndReturnID(int PersonID,  string userName ,
             clsHashPasswordAndSalt hashPassAndsalt, bool isActive)
        {
            try
            {
               return clsUserDataAccess.AddNewUser(PersonID, userName, hashPassAndsalt.hashPassword, hashPassAndsalt.salt, isActive);
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                throw new Exception(ex.Message,ex);
            }
        }
        private clsHashPasswordAndSalt _hashInputPasswordReturnHashAndSalt(string inputPassword )
        {

            var hashPassAndSaltTuple = clsAuthenticationService.HashPassowrdGenertorAndSalt(inputPassword);

                  return new clsHashPasswordAndSalt(hashPassAndSaltTuple.Item1, hashPassAndSaltTuple.Item2);

        }
        private clsPerson _findPerson(int personID)
        {
            clsPersonService personService = new clsPersonService(clsPersonService.Mode.AddNew);
           return  personService.Find(personID);
        }
        public clsUser createUser(string userName,string inputPassword,bool isActive,int personID)
        {
            try
            {
                clsHashPasswordAndSalt hashAndSalt= _hashInputPasswordReturnHashAndSalt(inputPassword);
               
                int newUserID = _AddNewUserToDataBaseAndReturnID(personID,userName, hashAndSalt, isActive);
                
                if (newUserID != -1)
                {         
                    if (clsPersonService.IsExist(personID)) {

                        return clsUser.createUser(newUserID, userName, hashAndSalt, isActive, _findPerson(personID));
                        
                    } 
                }        
                      
                
            }
            catch (Exception ex) {
                   throw new Exception($"User creation failed: {ex.Message}", ex);

            }
            return null; 
        }
        public bool isThisPersonIDconnectedToUser(int personID)
        {
            return clsUserDataAccess.isThisPersonHasUser(personID);
        }
        public bool isUserNameUnique(string inputUserName)
        {
            return clsUserDataAccess.isUserNameUnique(inputUserName);
        }
       
        public  clsUser Find(int ID)
        {
            string userName = "", password = "",salt="";
            int personID = -1;
            bool isActive = false;                           

            if (clsUserDataAccess.AccessUserById(ID, ref personID,ref userName,ref password,
                ref salt ,ref isActive))
            {
                clsPersonService clsPersonService = new clsPersonService(clsPersonService.Mode.AddNew);
                clsPerson person=clsPersonService.Find(personID);//Duplicated created I already created on in the previous layer. 

                clsHashPasswordAndSalt passwordAndSalt=new clsHashPasswordAndSalt(password, salt);
                return clsUser.createUser(ID, userName, passwordAndSalt, isActive, person);

            }
            return null;

        }

        public static clsUser Find(string userName)
        {
            int personID = -1,userId=-1;
            string password = "", salt = "";
            bool isActive = false;  
            if(clsUserDataAccess.AccessUserByUserName( userName,ref userId,ref personID,ref password,ref salt,ref isActive))
            {
                clsPersonService clsPersonService = new clsPersonService(clsPersonService.Mode.AddNew);
                clsPerson person = clsPersonService.Find(personID);//Duplicated created I already created on in the previous layer. 

                clsHashPasswordAndSalt passwordAndSalt = new clsHashPasswordAndSalt(password, salt);
                return clsUser.createUser(userId, userName, passwordAndSalt, isActive, person);

            }
            return null;
        }
        private clsHashPasswordAndSalt _getUserHashAndSaltByUserID(int userID)
        {
            string salt = "",currentHashPassword="";
            clsUserDataAccess.AccessUserHashAndSaltById(userID,ref currentHashPassword ,ref salt);
            return new clsHashPasswordAndSalt(currentHashPassword, salt);
            
        }
        private static clsHashPasswordAndSalt _getUserHashAndSaltByUserName(string userName)
        {
            string salt = "", currentHashPassword = "";
            clsUserDataAccess.AccessUserHashAndSaltByUserName(userName, ref currentHashPassword, ref salt);
            return new clsHashPasswordAndSalt(currentHashPassword, salt);

        }
        public  bool verifyPasswordInput(int userId, string inputPassword) 
        {
            clsHashPasswordAndSalt currentHashPasswordAndSalt = _getUserHashAndSaltByUserID(userId);

            return SecurityLib.clsAuthenticationService.VerifyPassword(inputPassword, 
                currentHashPasswordAndSalt.hashPassword, currentHashPasswordAndSalt.salt);

        }
        public bool updateUserInfo(clsUser updateUser)
        {
            try
            {                         
                    clsHashPasswordAndSalt hashPasswordAndSalt=_hashInputPasswordReturnHashAndSalt(updateUser.inputPassword);
                    return clsUserDataAccess.UpdateUserInfo(updateUser.UserID, updateUser.userName, hashPasswordAndSalt.hashPassword,
                        hashPasswordAndSalt.salt,updateUser.isActive);

                    throw new Exception("Password ain't verified");

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }

       

        }
        public static bool IsExist(int ID)
        {
            return clsUserDataAccess.IsExist(ID);
        }
        public static bool IsExist(string userName)
        {
            return clsUserDataAccess.IsExist(userName);
        }
        public static bool verifyPasswordInput(string userName, string inputPassword)
        {
            clsHashPasswordAndSalt currentHashPasswordAndSalt = _getUserHashAndSaltByUserName(userName);

            return SecurityLib.clsAuthenticationService.VerifyPassword(inputPassword,
                currentHashPasswordAndSalt.hashPassword, currentHashPasswordAndSalt.salt);

        }
        public static int  getPersonIDByUserID(int userID)
        {
          return  clsUserDataAccess.returnPersonIDByUserID(userID);
        }
        public static (string useName,bool isActive)getUserNameAndIsActiveById(int userID)
        {
            return clsUserDataAccess.returnUserNameAndIsActiveByUserID(userID);
        }
        public static bool DeleteUser( List<int> IDs)
        {
            return clsUserDataAccess.DeleteUserInfo( IDs);
        }

        public async static Task<DataTable> GetAllUsers()
        {
           return await clsUserDataAccess.GetAllUsersInfo();
        }
        private async static Task<DataTable> _GetAllUsersByColumn(string columnName, string columnValue)
        {
            return await clsUserDataAccess.GetAllUsersByColumnAsync(columnName, columnValue);
        }
        public async static Task<DataTable> GetAllUsersByUsersID(int userID)
        {
            return await clsUserDataAccess.GetAllUsersInfoByUserID(userID);
        }
        public async static Task<DataTable> GetAllUsersByUserName(string columnValue)
        {
            return await _GetAllUsersByColumn("UserName", columnValue);
        }
        public async static Task<DataTable> GetAllUsersByPersonID(int personID)
        {
            return await clsUserDataAccess.GetAllUsersInfoByPersonID(personID);
        }
        public async static Task<DataTable> GetAllUserByFullName(string columnValue)
        {
            return await _GetAllUsersByColumn("FullName", columnValue);
        }
        public async static Task<DataTable> GetAllUserByIsActive(enIsActive enActive)
        {
            if (enActive == enIsActive.None)
                return await GetAllUsers(); 
            else if (enActive==enIsActive.No)
            return await clsUserDataAccess.GetAllUsersInfoByIsActive(0);//0 --> False 

            else
                return await clsUserDataAccess.GetAllUsersInfoByIsActive(1);//1 --> True

        }
    }
}
