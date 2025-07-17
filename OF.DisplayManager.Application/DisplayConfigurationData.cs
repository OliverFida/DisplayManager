using OF.Base.Objects;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace OF.DisplayManager.Application
{
    public class DisplayConfigurationData : DataObject<DisplayConfiguration>
    {
        #region Properties
        public string? DisplayName { get; set; }

        [Required]
        [XmlElement(IsNullable = false)]
        public int PosX { get; set; } = 0;

        [Required]
        [XmlElement(IsNullable = false)]
        public int PosY { get; set; } = 0;

        [Required]
        [XmlElement(IsNullable = false)]
        public int Width { get; set; } = 0;

        [Required]
        [XmlElement(IsNullable = false)]
        public int Height { get; set; } = 0;

        [Required]
        [XmlElement(IsNullable = false)]
        public int Orientation { get; set; } = 0;

        [Required]
        [XmlElement(IsNullable = false)]
        public bool IsPrimary { get; set; } = false;

        [Required]
        [XmlElement(IsNullable = false)]
        public uint DisplayFlags { get; set; } = 0;
        #endregion

        #region Methods PUBLIC
        public override DisplayConfiguration FromData()
        {
            return new DisplayConfiguration()
            {
                DisplayName = DisplayName,
                PosX = PosX,
                PosY = PosY,
                Width = Width,
                Height = Height,
                Orientation = Orientation,
                IsPrimary = IsPrimary,
                DisplayFlags = DisplayFlags
            };
        }

        public override void ToData(DisplayConfiguration value)
        {
            DisplayName = value.DisplayName;
            PosX = value.PosX;
            PosY = value.PosY;
            Width = value.Width;
            Height = value.Height;
            Orientation = value.Orientation;
            IsPrimary = value.IsPrimary;
            DisplayFlags = value.DisplayFlags;
        }
        #endregion
    }
}
