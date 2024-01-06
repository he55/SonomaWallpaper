using System.Runtime.InteropServices;

namespace SonomaWallpaper
{
    public static class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        [DllImport("User32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("Kernel32")]
        public static extern ulong GetTickCount64();

        public static ulong GetLastInputTickCount()
        {
            LASTINPUTINFO lii = new LASTINPUTINFO { cbSize = (uint)Marshal.SizeOf(typeof(LASTINPUTINFO)) };
            GetLastInputInfo(ref lii);
            ulong tick = GetTickCount64();
            return tick - lii.dwTime;
        }
    }
}
