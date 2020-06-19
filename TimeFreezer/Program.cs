using System;
using System.Threading;

using Win32Time;

namespace TimeFreezer
{

    class Program
    {

        private static TimeService timeService { get; } = new TimeService();

        private static bool freezeDate = false;

        private const int TIME_RESET_DELAY = 500;

        static void Main(string[] args)
        {

            TimeChanger.SYSTEMTIME fakeDate = DateTime.UtcNow.ToSystemTime();

            fakeDate.wMilliseconds = 0;

            timeService.Stop();
            Console.WriteLine("Time updating service stopped.");

            freezeDate = true;

            Thread setFakeDateThread = new Thread(() => SetFakeDateLoop(fakeDate));

            setFakeDateThread.IsBackground = true;
            setFakeDateThread.Start();

            Console.WriteLine("Press any key to resynchronize time...");
            Console.ReadKey(true);

            freezeDate = false;

            while (setFakeDateThread.IsAlive)
            {

                Thread.Sleep(TIME_RESET_DELAY / 2);

            }

            timeService.Start();
            Console.WriteLine("Time synchronizer back up.");

            Console.WriteLine("Synchronizing...");

            timeService.Resync();

            Console.WriteLine("Synchronized.");

            Console.WriteLine("Press any key to exit...");

            Console.ReadKey(true);

        }

        private static void SetFakeDateLoop(TimeChanger.SYSTEMTIME fakeDate)
        {

            while (freezeDate)
            {

                TimeChanger.SetSystemTime(ref fakeDate);

                Thread.Sleep(TIME_RESET_DELAY);

            }

        }

    }

}
