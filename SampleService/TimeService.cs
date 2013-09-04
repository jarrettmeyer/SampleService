using System;
using System.Timers;

namespace SampleService
{
    public class TimeService
    {
        private const int INTERVAL_IN_MILLISECONDS = 5000;
        private const bool USE_TIMER_AUTO_RESET = true;
        private readonly ILogger logger;
        private readonly Timer timer;

        public TimeService(ILogger logger)
        {
            this.logger = logger;
            timer = new Timer(INTERVAL_IN_MILLISECONDS)
                    {
                        AutoReset = USE_TIMER_AUTO_RESET
                    };
            timer.Elapsed += (s, e) => logger.Write(string.Format("Time Service: {0}.", DateTime.Now));
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
