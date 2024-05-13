using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.LicesnseDTO
{
    public class clsDetainedLicenseSpec
    {

        private DateTime _detainDate;
        private decimal _fineFees;
        private int _createdByUserID;
        private bool _isReleased;
        private DateTime? _releaseDate;
        private int? _releaseByUserID;
        private string _detainReason;

      
        public clsDetainedLicenseSpec(DateTime detainDate, decimal fineFees, int createdByUserID,
             bool isReleased,string detainReason, DateTime? releaseDate=null, int? releaseByUserID=null)
        {
            _detainDate = detainDate;
            _fineFees = fineFees;
            _createdByUserID = createdByUserID;
            _isReleased = isReleased;
            _releaseDate = releaseDate;
            _releaseByUserID = releaseByUserID;
            _detainReason = detainReason;
        }
         public DateTime DetainDate
        {
            get { return _detainDate; }
        }

         public decimal FineFees
        {
            get { return _fineFees; }
        }

         public int CreateByUserID
        {
            get { return _createdByUserID; }
        }

         public bool IsReleased
        {
            get { return _isReleased; }
        }
       
        /// <summary>
        /// The date on which the license was released. Can be null if the license is not yet released.
        /// </summary>
        public DateTime? ReleaseDate
        {
            get { return _releaseDate; }
        }


        /// <summary>
        /// The ID of the user who released the license. Can be null if the license is not yet released.
        /// </summary>
        public int? ReleaseByUserID
        {
            get { return _releaseByUserID; }
        }

         public string DetainReason
        {
            get { return _detainReason; }
        }

    }
}
