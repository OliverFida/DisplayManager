using OF.Base.Objects;

namespace OF.DisplayManager.Application
{
    public class DisplayConfiguration : BindingObject
    {
        public string? DisplayName { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Orientation { get; set; }
        public bool IsPrimary { get; set; }
        public uint DisplayFlags { get; set; }
    }
}
