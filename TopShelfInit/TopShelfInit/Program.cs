using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TopShelfInit
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var cmdRun = HostFactory.Run(svc => 
            {
                svc.Service<ServiceTimer>(service =>
                {
                    service.ConstructUsing(name => new ServiceTimer());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });

                svc.RunAsLocalSystem();

                svc.SetDescription("Sample Topshelf Host - Init @aasf86");
                svc.SetDisplayName("@aasf86 - Demo");
                svc.SetServiceName("@aasf86 - Demo");

            });

            var exitCode = (int)Convert.ChangeType(cmdRun, cmdRun.GetTypeCode());
            Environment.ExitCode = exitCode;

            return;
            
            /*
            using (var svc = new ServiceTimer())
            {
                svc.Start();

                var arrayCount = new List<string>() { "" };

                while (true)
                {
                    arrayCount.Add("");
                    Console.WriteLine("Running{0}", string.Join(".", arrayCount));                    
                    System.Threading.Thread.Sleep(1000);                    
                    if (arrayCount.Count == 20) arrayCount.Clear(); arrayCount.Add("");                    
                }
            }
            */
        }
    }
}
