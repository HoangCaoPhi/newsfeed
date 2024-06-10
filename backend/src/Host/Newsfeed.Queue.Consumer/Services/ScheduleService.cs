using Newsfeed.Domain.Message;
using Newsfeed.Queue.Consumer.Jobs;
using Quartz;

namespace Newsfeed.Queue.Consumer.Services;
public class ScheduleService
{
    public static async Task Run(ScheduleConfigMessage config, IServiceProvider serviceProvider)
    {
        ISchedulerFactory factory = serviceProvider.GetRequiredService<ISchedulerFactory>();
        IScheduler scheduler = await factory.GetScheduler();
        await scheduler.Start();
        
        var indentiyJob = $"Job_{config.Id}";
        IJobDetail job = JobBuilder.Create<ScheduleJob>()
            .WithIdentity(indentiyJob, "email-sent")
            .UsingJobData(nameof(config.Id), config.Id)
            .Build();
        
        var valid = CronExpression.IsValidExpression(config.CronExpression);

        var indentiyTrigger = $"Trigger_{config.Id}";
        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity(indentiyTrigger, "email-sent")
            .StartNow()
            .WithCronSchedule(config.CronExpression)
            .Build();

        // Tell Quartz to schedule the job using our trigger
        await scheduler.ScheduleJob(job, trigger);
    }
}