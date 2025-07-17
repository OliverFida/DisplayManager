using System.IO;

namespace OF.DisplayManager.Application
{
    public static class CurrentApplication
    {
        public static readonly string APPDATA_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Oliver Fida", "DisplayManager");

        public static readonly string CONFIGS_PATH = Path.Combine(APPDATA_PATH, "configs");

        private static readonly ConfigStorage _configStorage = new ConfigStorage();
        public static ConfigStorage ConfigStorage
        {
            get => _configStorage;
        }
    }
}
