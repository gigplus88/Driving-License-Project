﻿using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };

        public clsDriver DriverInfo;
        public int LicenseID { set; get; }
        public int ApplicationID { set; get; }
        public int DriverID { set; get; }
        public int LicenseClass { set; get; }
        public clsLicenseClass LicenseClassInfo;
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public string Notes { set; get; }
        public float PaidFees { set; get; }
        public bool IsActive { set; get; }
        public enIssueReason IssueReason { set; get; }
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }
        public clsDetainedLicense DetainedInfo 
        {
            set { }
            
            get { return clsDetainedLicense.FindByLicenseID(this.LicenseID); }
        }
        public int CreatedByUserID { set; get; }
        public bool IsDetained
        {
            get { return clsDetainedLicense.IsLicenseDetained(this.LicenseID); }
        }

        public clsLicense()

        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = true;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;

        }

        public clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes,
            float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)

        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            this.DriverInfo = clsDriver.FindByDriverID(this.DriverID);
            this.LicenseClassInfo = clsLicenseClass.Find(this.LicenseClass);
            this.DetainedInfo = clsDetainedLicense.Find(this.LicenseID);

            Mode = enMode.Update;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    _UpdateLicense();
                    return true;
            }
            return false;
        }
        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass,
               this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);


            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicense(this.ApplicationID, this.LicenseID, this.DriverID, this.LicenseClass,
               this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
        }
       
        public static clsLicense Find(int LicenseID)
        {
            int ApplicationID = 0, DriverID = 0 , CreatedByID=0 ,LicenseClassID=0 ;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            bool IsActive = false;
            float PaidFees = 0;
            byte IssueReason = 0;

            bool IsFound = clsLicenseData.GetLicenseInfoByID( LicenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate,
            ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByID);


            if (IsFound)
            {
                return new clsLicense( LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes,  PaidFees, 
                    IsActive, (enIssueReason)IssueReason,  CreatedByID);
            }

            else
            {
                return null;
            }
        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {

            return clsLicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);

        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicenseData.GetDriverLicenses(DriverID);
        }

        public Boolean IsLicenseExpired()
        {

            return (this.ExpirationDate < DateTime.Now);

        }

        public bool DeactivateCurrentLicense()
        {
            return (clsLicenseData.DeactivateLicense(this.LicenseID));
        }
        public static string GetIssueReasonText(enIssueReason IssueReason)
        {

            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }

        public int Detain(float FineFees, int CreatedByUserID)
        {
            clsDetainedLicense detainedLicense = new clsDetainedLicense();
            detainedLicense.LicenseID = this.LicenseID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.FineFees = Convert.ToSingle(FineFees);
            detainedLicense.CreatedByUserID = CreatedByUserID;

            if (!detainedLicense.Save())
            {
                return -1;
            }

            return detainedLicense.DetainID;
        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, ref int ApplicationID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).ApplicationFees;
            Application.CreatedByUserID = ReleasedByUserID;

            if (!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }

            ApplicationID = Application.ApplicationID;

            return this.DetainedInfo.ReleaseDetainedLicense(ReleasedByUserID, Application.ApplicationID);  // Very Perfect Coding

        }

        public clsLicense RenewLicense(string Notes, int CreatedByUserID)
        {
            clsLicense clsLicense = clsLicense.Find(this.LicenseID);
            if (!clsLicense.IsLicenseExpired())
            {
                return null;
            }

          
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).ApplicationFees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;

            int DefaultValidityLength = this.LicenseClassInfo.DefaultValidityLength;

            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClassInfo.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsLicense.enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;


            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;
        }

        public clsLicense Replace(enIssueReason IssueReason, int CreatedByUserID)
        {
            clsLicense clsLicense = clsLicense.Find(this.LicenseID);
            if (clsLicense.IsLicenseExpired())
            {
                return null;
            }

            //First Create Applicaiton 
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;

            Application.ApplicationTypeID = (IssueReason == enIssueReason.DamagedReplacement) ?
                (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense :
                (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;

            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find(Application.ApplicationTypeID).ApplicationFees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = this.ExpirationDate; // Because it s just a replace to other License
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = 0;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = IssueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;



            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;
        }

















        public static DataTable GetLocalDriverLicensesInfo(int AppID)
        {
            return clsLicenseData.GetLocalDriverLicensesInfo(AppID);
        }
        public static int CountDriverLicenses(int AppID)
        {
            return clsLicenseData.CountDriverLicenses( AppID);
        }
        public static string GetNotesByOldLicenseID(int LicenseID)
        {
            return clsLicenseData.GetNotesByOldLicenseID(LicenseID);
        }
        public static int GetLicenseIDByApplicationID(int ApplicationID)
        {
            return (clsLicenseData.GetLicenseIDByApplicationID(ApplicationID));

        }
        public static int GetApplicationIDByLicenseID(int LicenseID)
        {
            return (clsLicenseData.GetApplicationIDByLicenseID(LicenseID));

        }

        public static bool IfHasLicenseActive(int ApplicationID , byte IsActive)
        {
            return (clsLicenseData.IfHasLicenseActive(ApplicationID , IsActive));
        }
        public static bool IfDontHasLicense(int ApplicationID)
        {
            return (clsLicenseData.IfDontHasLicense( ApplicationID));
        }
        public static bool IfLicenseActive(int LicenseID , byte IsActive)
        {
            return (clsLicenseData.IfLicenseActive(LicenseID, IsActive));
        }
        public static bool IsExpireDate(int LicenseID)
        {
            return (clsLicenseData.IsExpireDate(LicenseID));
        }

        public static int GetDriverIDByLicenseID(int LicenseID)
        {
            return (clsLicenseData.GetDriverIDByLicenseID( LicenseID));
        }
        public static int GetLicenseClassIDByLicenseID(int LicenseID)
        {
            return (clsLicenseData.GetLicenseClassIDByLicenseID(LicenseID));
        }
        public static int GetPersonIDByLicenseID(int LicenseID)
        {
            return (clsLicenseData.GetPersonIDByLicenseID( LicenseID));
        }
        public static DateTime GetExpirationDate(int LicenseID)
        {
            return (clsLicenseData.GetExpirationDate( LicenseID));
        }
        public static float GetPaidFees(int LicenseID)
        {
            return (clsLicenseData.GetPaidFees( LicenseID));
        }
        public static bool DisableOldLicense(int LicenseID)
        {
            return clsLicenseData.DisableOldLicense(LicenseID);
        }




    }
}
