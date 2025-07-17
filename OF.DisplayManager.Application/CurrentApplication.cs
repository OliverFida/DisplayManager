using System.IO;

namespace OF.DisplayManager.Application
{
    public static class CurrentApplication
    {
        public static readonly string APPDATA_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Oliver Fida", "DisplayManager");

        public static readonly string PROFILES_PATH = Path.Combine(APPDATA_PATH, "profiles");

        private static readonly ProfileStorage _profileStorage = new ProfileStorage();
        public static ProfileStorage ProfileStorage
        {
            get => _profileStorage;
        }
    }
}
