using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Win32Time
{
    public static class TimeChanger
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);


        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }

        public static SYSTEMTIME ToSystemTime(this DateTime time)
        {

            SYSTEMTIME systemTime = new SYSTEMTIME();

            systemTime.wYear = (short)time.Year;
            systemTime.wMonth = (short)time.Month;
            systemTime.wDay = (short)time.Day;
            systemTime.wDayOfWeek = (short)time.DayOfWeek;

            systemTime.wHour = (short)time.Hour;
            systemTime.wMinute = (short)time.Minute;
            systemTime.wSecond = (short)time.Second;
            systemTime.wMilliseconds = (short)time.Millisecond;

            return systemTime;

        }

    }

}
