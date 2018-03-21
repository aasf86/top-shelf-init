﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TopShelfInit
{
    public class ServiceTimer
    {
        private Timer _timer;

        public ServiceTimer()
        {
            _timer = new Timer(60000);
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