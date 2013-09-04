using System;
using System.Timers;
using SampleService.Properties;

namespace SampleService
{
    public class TimeService
    {
        private readonly static int intervalInMilliseconds = Settings.Default.IntervalInMS;
        private readonly ILogger logger;
        private readonly Timer timer;
        private readonly static bool useTimerAutoReset = Settings.Default.UseTimerAutoReset;

        public TimeService(ILogger logger)
        {
            this.logger = logger;
            timer = new Timer(intervalInMilliseconds)
                    {
                        AutoReset = useTimerAutoReset,
                    };
            timer.Elapsed += (s, e) => logger.Write(string.Format("Time Service says, 'The time is now {0}.'", DateTime.Now));
        }

        public void Start()
        {
            timer.Start();
            logger.Write("Time Service was started.");
        }

        public void Stop()
        {
            timer.Stop();
            logger.Write("Time Service was stopped.");
        }
    }
}
