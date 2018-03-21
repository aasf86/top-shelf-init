using System;
using System.IO;
using System.Timers;

namespace TopShelfInit
{
    public class ServiceTimer : IDisposable
    {
        private Timer _timer;

        public ServiceTimer()
        {
            _timer = new Timer(3000) { AutoReset = true };
            _timer.Elapsed += (obj, sender) =>
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "log.txt"), true))
                {
                    var logNow = $"TopShelfInit -> {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff")}";
                    Console.WriteLine(logNow);
                    sw.WriteLine(logNow);
                }
            };
        }

        public void Dispose()
        {
            _timer.Dispose();
            GC.ReRegisterForFinalize(this);            
        }

        public void Start()
        {         
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
