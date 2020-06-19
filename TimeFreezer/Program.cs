using System;
using System.Data;
using System.Timers;

using Win32Time;

namespace TimeFreezer
{

    class Program
    {

        private static TimeService timeService { get; } = new TimeService();

        private static int datePatchInterval = 500;

        static void Main(string[] args)
        {

            TimeChanger.SYSTEMTIME fakeDate = DateTime.UtcNow.ToSystemTime();

            fakeDate.wMilliseconds = 0;

            timeService.Stop();
            Console.WriteLine("Time updating service stopped.");

            Timer updateFakeDateTimer = new Timer();

            updateFakeDateTimer.Elapsed += (e, s) => SetDate(fakeDate);

            updateFakeDateTimer.AutoReset = true;
            updateFakeDateTimer.Interval = datePatchInterval;

            updateFakeDateTimer.Start();

            Console.WriteLine("Press any key to resynchronize time...");
            Console.ReadKey(true);

            updateFakeDateTimer.Stop();

            timeService.Start();
            Console.WriteLine("Time synchronizer back up.");

            Console.WriteLine("Synchronizing...");

            timeService.Resync();

            Console.WriteLine("Synchronized.");

            Console.WriteLine("Press any key to exit...");

            Console.ReadKey(true);

        }

        private static void SetDate(TimeChanger.SYSTEMTIME fakeDate)
        {

            TimeChanger.SetSystemTime(ref fakeDate);

        }

    }

}
