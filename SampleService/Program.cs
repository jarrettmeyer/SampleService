using System;
using System.Threading;
using Topshelf;

namespace SampleService
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                TimeService timeService = new TimeService(new ConsoleLogger());
                timeService.Start();
                Thread.Sleep(TimeSpan.FromSeconds(10.0));
                timeService.Stop();
            }
            else
            {
                HostFactory.Run(cfg =>
                {
                    cfg.Service<TimeService>(s =>
                    {
                        s.ConstructUsing(_ => new TimeService(new FileLogger()));
                        s.WhenStarted(ts => ts.Start());
                        s.WhenStopped(ts => ts.Stop());
                    });
                    cfg.RunAsLocalSystem();
                    cfg.SetDescription("Sample Time Service");
                    cfg.SetDisplayName("Sample_Time_Service");
                    cfg.SetServiceName("Sample_Time_Service");
                });
                
            }


        }
    }
}
