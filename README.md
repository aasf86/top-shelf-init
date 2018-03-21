# top-shelf-init
================================================


Topshelf
--------
[nuget](https://www.nuget.org/packages/Topshelf/)

[github](https://github.com/Topshelf/Topshelf/)

Topshelf is an open source project for hosting services without friction. By referencing Topshelf, your console application *becomes* a service installer with a comprehensive set of command-line options for installing, configuring, and running your application as a service.

```powershell
PM> Install-Package Topshelf
```

Show me the code -> with console application
-----

Program - Main()

```csharp

    using System;
    using Topshelf;

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
        }
    }            

```

ServiceTimer

```csharp

    using System;
    using System.IO;
    using System.Timers;

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
```