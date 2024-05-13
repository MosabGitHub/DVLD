using GlobalSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.LicesnseDTO
{
    public class clsLicenseSpec
    {
        private DateTime _issueDate;
        private DateTime _expireDate;
        private string _notes;
        private bool _isActive;
        private decimal _paidFees;
        private enIssueReason _issueReason;
        public clsLicenseSpec(DateTime issueDate,DateTime expireDate,string notes,
            bool isActive, decimal paidFees, enIssueReason issueReason) {
        
            _issueDate = issueDate;
            _expireDate = expireDate;
            _notes = notes;
            _isActive= isActive;
            _paidFees= paidFees;
            _issueReason = issueReason;

        }
        public DateTime IssueDate
        {
            get { return _issueDate; }
        }
        public DateTime ExpireDate { get { return _expireDate; } }
        public string Notes { get { return _notes; } }
        public bool IsActive { get { return _isActive; } }
        public decimal PaidFees { get {  return _paidFees; } }
    
        public enIssueReason IssueReason { get { return _issueReason; } }
    }

}
