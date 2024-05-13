using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.LicesnseDTO
{
    public class clsInternationalLicenseSpec
    {
        private int _createdByUserID;

        private DateTime _issueDate;
        private DateTime _expirationDate;
        private bool _isActive;

        public clsInternationalLicenseSpec(int createdByUserId,DateTime issueDate,DateTime expirationDate,bool isActive) {
        
            this._createdByUserID = createdByUserId;
            this._issueDate = issueDate;
            this._expirationDate = expirationDate;
            this._isActive = isActive;
        }


        public int CreatedByUserID {  get { return _createdByUserID; } }

        public DateTime IssueDate { get { return _issueDate; } }

        public DateTime ExpirationDate { get { return _expirationDate; } }  

        public bool IsActive { get { return _isActive; } }

    }

}
