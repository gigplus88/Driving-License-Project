using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public class clsUser
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { set; get; }
        public clsPerson PersonInfo;
        public enum enMode
        {
            AddNew = 0,
            Update = 1
        };
        public static enMode Mode = enMode.AddNew;

        public clsUser()
        {
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = true;

            Mode = enMode.AddNew;
        }


        public clsUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

      


        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.PersonID, this.UserName, this.Password, this.IsActive);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    _UpdateUser();
                    return true;
            }
            return false;
        }
        private bool _AddNewUser()
        {
            this.UserID =clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return this.UserID != -1;
        }

        public static bool DeleteUser(int UserID)
        {
            return (clsUserData.DeleteUser(UserID));
        }
        public static int GetUserIDByUserName(string UserName)
        {
            return (clsUserData.GetUserIDByUserName(UserName));
        }
        public static string GetUserNameByUserID(int UserID)
        {
            return (clsUserData.GetUserNameByUserID(UserID));
        }
        
        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static clsUser Find(int UserID)
        {
            int PersonID = 0;
            string UserName = "", Password = "";
            bool IsActive = false;
            bool IsFound = clsUserData.GetUserInfoByID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive);


            if (IsFound)
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }

            else
            {
                return null;
            }
        }
        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1;
            int PersonID = -1;

            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUsernameAndPassword
                                (UserName, Password, ref UserID, ref PersonID, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }
        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = 0;
            string UserName = "", Password = "";
            bool IsActive = false;
            bool IsFound = clsUserData.GetUserInfoByPersonID(ref UserID,  PersonID, ref UserName, ref Password, ref IsActive);


            if (IsFound)
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }

            else
            {
                return null;
            }
        }
        public static clsUser Find(string UserName)
        {
            int UserID = 0, PersonID = 0;
            string Password = "";
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUserName(ref UserID, ref PersonID,  UserName, ref Password, ref IsActive);

            if (IsFound)
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }

            else
            {
                return null;
            }
        }

        public static bool IsUserExist(string UserName, string Password)
        {
            return (clsUserData.IsUserExist(UserName, Password));

        }
        public static bool IsUserExist(string UserName)
        {
            return (clsUserData.IsUserExist(UserName));

        }
        public static bool IsUserExist(int UserID)
        {
            return (clsUserData.IsUserExist( UserID));

        }
        public static bool IsUserExistForPersonID(int PersonID)
        {
            return (clsUserData.IsUserExistForPersonID(PersonID));

        }
        public static bool IsUserActive(string UserName)
        {
            return (clsUserData.IsUserActive(UserName));
        }





        // For Old Solution

        public static int CountUsers()
        {
            return clsUserData.CountUsers();
        }

        public static DataView FindUsersByUserID(int UserID)
        {
            return clsUserData.FindUsersByUserID(UserID);
        }
        public static DataView FindUsersByPersonID(int PersonID)
        {
            return clsUserData.FindUsersByPersonID(PersonID);
        }
        public static DataView FindUsersByUserName(string UserName)
        {
            return clsUserData.FindUsersByUserName(UserName);
        }
        public static DataView FindUsersByFullName(string FullName)
        {
            return clsUserData.FindUsersByFullName(FullName);
        }
        public static DataView FindUsersByPassword(string Password)
        {
            return clsUserData.FindUsersByPassword(Password);
        }
        public static DataView FindUsersActive(byte isActive)
        {
            return clsUserData.FindUsersActive(isActive);
        }
        public static DataView FindUsersNoActive(byte isActive)
        {
            return clsUserData.FindUsersNoActive(isActive);
        }

        //
    }
}
