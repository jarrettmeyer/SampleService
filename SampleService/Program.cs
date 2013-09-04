using System;
using Topshelf;

namespace SampleService
{
    public class Program
    {
        private static bool isRunMode;
        private static ILogger logger;

        public static void Main(string[] args)
        {
            InitializeLogger(args);
            InitializeServiceHostFactory();
        }

        private static void InitializeLogger(string[] args)
        {
            isRunMode = ArgumentChecker.CheckArgumentValue(args, 0, "run");
            if (isRunMode)
            {
                logger = new ConsoleLogger();
                Console.WriteLine("Using console.");
            }
            else
            {
                logger = new FileLogger();
                Console.WriteLine("Using file.");
            }
        }

        private static void InitializeServiceHostFactory()
        {
            HostFactory.Run(cfg =>
            {
                cfg.Service<TimeService>(s =>
                {
                    s.ConstructUsing(_ => new TimeService(logger));
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
