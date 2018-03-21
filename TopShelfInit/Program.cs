using System;
using Topshelf;

namespace TopShelfInit
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var cmdRun = HostFactory.Run(process => 
            {
                process.Service<ServiceTimer>(service =>
                {
                    service.ConstructUsing(name => new ServiceTimer());
                    service.WhenStarted(svc => svc.Start());
                    service.WhenStopped(svc => svc.Stop());
                });

                process.RunAsLocalSystem();

                process.SetDescription("Sample Topshelf Host - Init @aasf86");
                process.SetDisplayName("@aasf86 - Demo");
                process.SetServiceName("@aasf86 - Demo");

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
