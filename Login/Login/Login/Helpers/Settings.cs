using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Login.Helpers
{
    public static class Settings
    {
        #region AppSettings
        private static ISettings AppSettings
        {
            get { return CrossSettings.Current; }
        }
        #endregion

        #region User
        private const string UserKey = "user_key";
        private static readonly string UserDefault = string.Empty;

        public static string User
        {
            get { return AppSettings.GetValueOrDefault(UserKey, UserDefault); }
            set { AppSettings.AddOrUpdateValue(UserKey, value); }
        }
        #endregion

        #region isLogged
        private const string IsLoggedKey = "is_logged_key";
        private static readonly bool IsLoggedDefault = false;

        public static bool IsLogged
        {
            get { return AppSettings.GetValueOrDefault(IsLoggedKey, IsLoggedDefault); }
            set { AppSettings.AddOrUpdateValue(IsLoggedKey, value); }
        }
        #endregion
    }
}
