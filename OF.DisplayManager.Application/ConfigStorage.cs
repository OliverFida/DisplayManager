using OF.Base.Objects;
using System.IO;

namespace OF.DisplayManager.Application
{
    public class ConfigStorage : BindingObject
    {
        private List<DisplayConfiguration> _storedConfigs = new List<DisplayConfiguration>();
        public List<DisplayConfiguration> StoredConfigs
        {
            get => _storedConfigs;
            private set => SetProperty(ref _storedConfigs, value);
        }

        public ConfigStorage()
        {
            EnsureConfigsDirectoryExists();
            ReadStoredConfigs();
        }

        public void StoreConfig(DisplayConfiguration configuration)
        {
            // TODO: Store to disk
            ReadStoredConfigs();
        }

        public void DeleteConfig(DisplayConfiguration configuration)
        {
            // TODO: Delete from disk
            ReadStoredConfigs();
        }

        private void EnsureConfigsDirectoryExists()
        {
            if (!Directory.Exists(CurrentApplication.CONFIGS_PATH)) Directory.CreateDirectory(CurrentApplication.CONFIGS_PATH);
        }

        private void ReadStoredConfigs()
        {
            // TODO: Read from disk
        }
    }
}
