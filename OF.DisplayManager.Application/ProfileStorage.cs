using OF.Base.Objects;
using System.IO;
using System.Xml.Serialization;

namespace OF.DisplayManager.Application
{
    public class ProfileStorage : BindingObject
    {
        #region Properties
        private List<DisplayConfiguration> _storedProfiles = new List<DisplayConfiguration>();
        public List<DisplayConfiguration> StoredProfiles
        {
            get => _storedProfiles;
            private set => SetProperty(ref _storedProfiles, value);
        }
        #endregion

        #region Constructor
        public ProfileStorage()
        {
            EnsureProfilesDirectoryExists();
            ReadStoredProfiles();
        }
        #endregion

        #region Methods PUBLIC
        public void StoreProfile(string profileName, List<DisplayConfiguration> configurations)
        {
            Profile profile = new Profile(profileName, configurations);
            ProfileData data = new ProfileData();
            data.ToData(profile);

            string filePath = Path.Combine(CurrentApplication.PROFILES_PATH, profile.FileName);
            FileStream fileStream = File.Create(filePath);

            XmlSerializer serializer = new XmlSerializer(typeof(ProfileData));
            serializer.Serialize(fileStream, data);

            fileStream.Close();

            ReadStoredProfiles();
        }

        public void DeleteProfile(DisplayConfiguration configuration)
        {
            throw new NotImplementedException();
            // TODO: Delete from disk
            ReadStoredProfiles();
        }
        #endregion

        #region Methods PRIVATE
        private void EnsureProfilesDirectoryExists()
        {
            if (!Directory.Exists(CurrentApplication.PROFILES_PATH)) Directory.CreateDirectory(CurrentApplication.PROFILES_PATH);
        }

        private void ReadStoredProfiles()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(CurrentApplication.PROFILES_PATH);
            List<FileInfo> fileInfos = directoryInfo.GetFiles().ToList();

            // TODO
        }
        #endregion
    }
}
