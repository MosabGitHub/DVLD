using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DTOs.LicenseDTO.Detained_ReleaseLicenses
{
    public class clsReleaseSpec
    {
        private int _licenseID;
        private bool _isReleased;
        private DateTime _releaseDate;
        private int _releasedByUserId;
        private int _releaseApplicationId;
        
        public clsReleaseSpec(int LicenseID, bool IsReleased,DateTime ReleaseDate, int ReleaseByUserId, int ReleaseApplicationId)
        {
            _licenseID = LicenseID;
            _isReleased = IsReleased;
            _releaseDate = ReleaseDate;
            _releasedByUserId= ReleaseByUserId;
            _releaseApplicationId = ReleaseApplicationId;
        }

        public  int LicenseID {  get { return _licenseID; } }

        public bool IsReleased {  get { return _isReleased; } }
        public DateTime ReleaseDate { get { return _releaseDate; } }

        public int ReleasedByUserID {  get { return _releasedByUserId; } }

        public int ReleaseApplicationID {  get { return _releaseApplicationId; } }


    }
}
