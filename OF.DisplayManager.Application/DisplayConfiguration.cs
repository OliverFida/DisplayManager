using OF.Base.Objects;

namespace OF.DisplayManager.Application
{
    public class DisplayConfiguration : BindingObject
    {
        private string? _configName;
        public string ConfigName {
            get
            {
                return _configName ?? DisplayName ?? "Unknown Display Configuration";
            }
            set => SetProperty(ref _configName, value);
        }

        public string? DisplayName { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Orientation { get; set; }
        public bool IsPrimary { get; set; }
        public uint DisplayFlags { get; set; }

        public override string ToString()
        {
            return ConfigName;
        }
    }
}
