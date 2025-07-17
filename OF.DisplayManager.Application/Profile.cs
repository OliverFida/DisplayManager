namespace OF.DisplayManager.Application
{
    public class Profile
    {
        #region Properties
        private string _profileName;
        public string ProfileName => _profileName;
        public string FileName
        {
            get => ProfileName.Trim().ToLower().Replace(" ", "_") + ".xml";
        }

        private List<DisplayConfiguration> _configurations = new List<DisplayConfiguration>();
        public List<DisplayConfiguration> Configurations => _configurations;
        #endregion

        #region Constructor
        public Profile(string profileName, List<DisplayConfiguration> configurations)
        {
            _profileName = profileName;
            _configurations = configurations;
        }
        #endregion
    }
}
