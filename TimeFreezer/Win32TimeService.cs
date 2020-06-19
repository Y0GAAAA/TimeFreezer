using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceProcess;
using System.IO;
using System.Diagnostics;

namespace Win32Time
{

    public class TimeService
    {

        private const string TIME_SERVICE_NAME = "W32Time";

        private const string TIME_PROCESS_NAME = "w32tm.exe";

        private string TimeProcessFileName => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), TIME_PROCESS_NAME);

        private ServiceController TimeServiceController { get; } = new ServiceController(TIME_SERVICE_NAME);

        public bool IsRunning {

            get {

                TimeServiceController.Refresh();

                return TimeServiceController.Status == ServiceControllerStatus.Running;

            }

        }

        public void Start()
        {

            if (IsRunning)
                return;

            TimeServiceController.Start();

        }

        public void Stop()
        {

            if (!IsRunning)
                return;

            TimeServiceController.Stop();

        }

        public void Resync()
        {

            ProcessStartInfo starter = GetInvisibleStarter();

            starter.FileName = TimeProcessFileName;
            starter.Arguments = "/resync";

            Process timeProcess = Process.Start(starter);

            timeProcess.WaitForExit();

        }

        private ProcessStartInfo GetInvisibleStarter()
        {

            return new ProcessStartInfo() { CreateNoWindow = true, WindowStyle = ProcessWindowStyle.Hidden, UseShellExecute = true };

        }

    }

}
