using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonClass;
using System.Security.Cryptography;
using System.Deployment.Internal;
using static clsUsers.clsUserService;

namespace clsUsers
{
    public class clsUser
    {
        // private clsPerson person = new clsPerson();// You need to approach to the personDetails
        private clsPerson _person; // Composition, not inheritance      
        private enum Mode
        {
            AddNew,
            Update
        }
        private Mode _mode;
        private int _ID {  get; set; }
        private string _UserName { get; set; }
        private bool _IsActived { get; set; }

        private string _salt; // Store salt for password hashing
        
        private string _hashedPassword; // Store only hashed passwords

        private string _inputPassword=null;
        internal clsUser(int ID, string userName, clsHashPasswordAndSalt passwordAndSalt, bool isActived, clsPerson person)
        {
            _ID = ID;
            _UserName = userName;
            _hashedPassword = passwordAndSalt.hashPassword;
            _salt = passwordAndSalt.salt;
            _IsActived = isActived;
            _person = person;
            _mode = Mode.Update;
        } 
        public clsUser( string userName , string inputPassowrd,bool isActive)
        {
            this._UserName = userName;
            this._inputPassword= inputPassowrd;
            this._IsActived = isActive;
            
            _mode=Mode.AddNew;
        }
        public clsUser(int ID,string userName, string inputPassowrd, bool isActive)
        {
            _ID= ID;
            this._UserName = userName;
            this._inputPassword = inputPassowrd;
            this._IsActived = isActive;
            _mode = Mode.Update;
        }
        public string userName
        {
            set { _UserName = value; }
         get { return _UserName; }

        }
        public string inputPassword
        {
            set { _inputPassword = value; }

            get { return _inputPassword; }

        }
        public int personID
        {

            get { return _person.ID; }
        }    
        public int UserID
        {
            get { return _ID; }

        }
        internal string hashPassword
        {
            get { return _hashedPassword; }
        }
        internal string salt
        {
            get { return _salt; }
        }
        public bool isActive
        {
            set { _IsActived = value; }
            get { return _IsActived; }  }
        internal static  clsUser createUser(int ID, string userName, clsHashPasswordAndSalt passwordAndSalt, bool isActived, clsPerson person)
        {
            return new clsUser(ID,userName, passwordAndSalt, isActived,person);
        }
    }
}
