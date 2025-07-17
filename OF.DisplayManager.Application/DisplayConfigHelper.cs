using System.Runtime.InteropServices;

namespace OF.DisplayManager.Application
{
    internal static class DisplayConfigHelper
    {
        [DllImport("user32.dll")]
        private static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);

        [DllImport("user32.dll")]
        private static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);

        [DllImport("user32.dll")]
        private static extern int ChangeDisplaySettingsEx(string lpszDeviceName, ref DEVMODE lpDevMode, IntPtr hwnd, ChangeDisplaySettingsFlags dwflags, IntPtr lParam);

        [Flags()]
        private enum ChangeDisplaySettingsFlags : uint
        {
            CDS_NONE = 0,
            CDS_UPDATEREGISTRY = 0x00000001,
            CDS_TEST = 0x00000002,
            CDS_FULLSCREEN = 0x00000004,
            CDS_GLOBAL = 0x00000008,
            CDS_SET_PRIMARY = 0x00000010,
            CDS_VIDEOPARAMETERS = 0x00000020,
            CDS_ENABLE_UNSAFE_MODES = 0x00000100,
            CDS_DISABLE_UNSAFE_MODES = 0x00000200,
            CDS_RESET = 0x40000000,
            CDS_RESET_EX = 0x20000000,
            CDS_NORESET = 0x10000000
        }

        public static List<DisplayConfiguration> GetCurrentDisplayConfigurations()
        {
            List<DisplayConfiguration> displayConfigurations = new List<DisplayConfiguration>();

            foreach (Screen screen in Screen.AllScreens)
            {
                DisplayConfiguration config = new DisplayConfiguration {
                    DisplayName = screen.DeviceName,
                    PosX = screen.Bounds.X,
                    PosY = screen.Bounds.Y,
                    Width = screen.Bounds.Width,
                    Height = screen.Bounds.Height,
                    IsPrimary = screen.Primary
                };

                displayConfigurations.Add(config);
            }

            return displayConfigurations;
        }

        public static List<DisplayConfiguration> GetCurrentDisplayConfigurationsNEW()
        {
            List<DisplayConfiguration> displayConfigs = new List<DisplayConfiguration>();
            DISPLAY_DEVICE device = new DISPLAY_DEVICE();
            device.cb = Marshal.SizeOf(device);

            for (uint id = 0; EnumDisplayDevices(null, id, ref device, 0); id++)
            {
                DEVMODE devMode = new DEVMODE();
                devMode.dmSize = (short)Marshal.SizeOf(devMode);

                if(EnumDisplaySettings(device.DeviceName, -1, ref devMode))
                {
                    DisplayConfiguration config = new DisplayConfiguration
                    {
                        DisplayName = device.DeviceName,
                        PosX = devMode.dmPositionX,
                        PosY = devMode.dmPositionY,
                        Width = devMode.dmPelsWidth,
                        Height = devMode.dmPelsHeight,
                        Orientation = devMode.dmDisplayOrientation,
                        IsPrimary = (device.StateFlags & 0x00000004) != 0, // DISPLAY_DEVICE_PRIMARY_DEVICE
                        DisplayFlags = (uint)devMode.dmDisplayFlags
                    };

                    displayConfigs.Add(config);
                }

                device = new DISPLAY_DEVICE();
                device.cb = Marshal.SizeOf(device);
            }

            return displayConfigs;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct DISPLAY_DEVICE
        {
            public int cb;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string DeviceName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string DeviceString;
            public int StateFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string DeviceID;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string DeviceKey;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct DEVMODE
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public int dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }
    }
}
