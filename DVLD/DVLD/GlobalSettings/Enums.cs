using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalSettings
{
    public enum enStatus
    {
        hold = 0,
        completed = 1,
        cancelled = 2,
        New = 3,
    }
    public enum enTestType
    {
        Vision=1,
        Written=6,
        Practical=7
    }

    public enum enTestResult 
    {
        failure,
        success,
    }

    public enum enApplicationType
    {
        NewInternationalLicense = 1,
        NewLocalDrivingLicenseService = 3,
        ReleaseDetainedDrivingLicense = 6,
        RenewDrivingLicenseService = 7,
        ReplacementForDamagedDrivingLicense = 8,
        ReplacementLostDrivingLicense = 9,
        RetakeTest = 10
    }
    public enum enFormMode
    {
        newOne = 0,
        reTake = 1,
        locked = 2,
        edit = 3,
        editRetake=4
    }
    public enum enFilterMode
    {
        ID,
        DrivingClass,
        NationalNo,
        FullName,
        ApplicationDate,
        PassedTest,
        Status
    }
    public enum enIssueReason
    {
        newLicense=1,
        renewLicense=2,
        ReplaceForDamage=3,
        ReplaceForLost=4
    }

    public enum enLicenseClass
    {
        SmallMotorcycleLicense=1,
        HeavyMotorcycleLicense=6,
        StandardDrivingLicense=7,
        CommercialDrivingLicense=8,
        AgriculturalDrivingLicense=9,
        SmallAndMediumBus=10,
        TruckAndHeavyVehicle=11
    }
    public enum enMode
    {
        AddNew,
        update
    }

    public enum enFilterLicenseMode
    {
        LocalLicenses,
        LocalAndInternationalLicenses,
        General
    }

    public enum enDetainMode
    {        
         NotDetained,
         Detained,
         Release


    }
    public enum enDetainLicenseListFilters
    {
        None,
        DetainID,
        IsReleased,
        NationalNo,
        FullName,
        ReleaseApplicationID
    }
}
