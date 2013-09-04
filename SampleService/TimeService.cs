using System;
using System.Timers;
using SampleService.Properties;

namespace SampleService
{
    public class TimeService
    {
        private readonly static int intervalInMilliseconds = Settings.Default.IntervalInMS;
        private readonly ILogger logger;
        private Timer timer;
        private readonly static bool useTimerAutoReset = Settings.Default.UseTimerAutoReset;

        public TimeService(ILogger logger)
        {
            if (logger == null)
                throw new ArgumentNullException("logger");
            this.logger = logger;
            InitializeTimer();
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

        private void InitializeTimer()
        {
            timer = new Timer
            {
                AutoReset = useTimerAutoReset,
                Interval = intervalInMilliseconds
            };
            timer.Elapsed += (s, e) => logger.Write(string.Format("Time Service says, 'The time is now {0}.'", DateTime.Now));
        }
    }
}
