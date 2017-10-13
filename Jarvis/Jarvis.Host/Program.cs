using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;

namespace Jarvis.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            // trigger async evaluation
            RunProgram().GetAwaiter().GetResult();
            Console.ReadLine();
        }

        private static async Task RunProgram()
        {
            try
            {
                // Grab the Scheduler instance from the Factory
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" },
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                IScheduler scheduler = await factory.GetScheduler();

                // and start it off
                await scheduler.Start();

                await scheduler.ScheduleJob(new JobDetailImpl("demo", typeof(DemoJob)), new SimpleTriggerImpl("trigger", -1, TimeSpan.FromSeconds(1)));

                //// some sleep to show what's happening
                //await Task.Delay(TimeSpan.FromSeconds(60));

                //// and last shut down the scheduler when you are ready to close your program
                //await scheduler.Shutdown();
            }
            catch (SchedulerException se)
            {
                await Console.Error.WriteLineAsync(se.ToString());
            }
        }
    }
}
