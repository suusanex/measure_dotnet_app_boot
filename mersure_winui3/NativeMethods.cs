using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace mersure_winui3
{
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetCurrentProcess();

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool GetProcessTimes(IntPtr hProcess,
            out FILETIME lpCreationTime,
            out FILETIME lpExitTime,
            out FILETIME lpKernelTime,
            out FILETIME lpUserTime);

        [StructLayout(LayoutKind.Sequential)]
        internal struct FILETIME
        {
            public uint dwLowDateTime;
            public uint dwHighDateTime;
        }

        internal static DateTime FileTimeToDateTime(FILETIME ft)
        {
            long hFT = (((long)ft.dwHighDateTime) << 32) + ft.dwLowDateTime;
            return DateTime.FromFileTimeUtc(hFT).ToLocalTime();
        }

    }
}
