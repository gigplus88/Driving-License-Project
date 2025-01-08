namespace DVLD
{
    public class GlobalSettings
    {
        public static string filePath = "CurrentUser.txt";

        public struct stCurrentUserInfo
        {
            public string UserName;
            public string Password;
        }
        public static stCurrentUserInfo CurrentUserInfo;

    }
}
