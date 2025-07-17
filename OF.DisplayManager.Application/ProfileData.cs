using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OF.DisplayManager.Application
{
    public class ProfileData : Base.Objects.DataObject<Profile>
    {
        #region Properties
        [Required]
        [XmlElement(IsNullable = false)]
        public string ProfileName { get; set; } = string.Empty;

        [Required]
        [XmlArray(nameof(Configurations), IsNullable = true)]
        public List<DisplayConfigurationData> Configurations { get; set; } = new List<DisplayConfigurationData>();
        #endregion

        #region Methods PUBLIC
        public override Profile FromData()
        {
            List<DisplayConfiguration> configurations = new List<DisplayConfiguration>();
            foreach (DisplayConfigurationData configData in Configurations)
            {
                configurations.Add(configData.FromData());
            }

            return new Profile(ProfileName, configurations);
        }

        public override void ToData(Profile value)
        {
            ProfileName = value.ProfileName;

            Configurations.Clear();
            foreach(DisplayConfiguration config in value.Configurations)
            {
                DisplayConfigurationData configData = new DisplayConfigurationData();
                configData.ToData(config);
                Configurations.Add(configData);
            }
        }
        #endregion
    }
}
