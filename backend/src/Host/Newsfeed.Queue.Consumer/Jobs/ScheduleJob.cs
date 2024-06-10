using Quartz;

namespace Newsfeed.Queue.Consumer.Jobs;
public class ScheduleJob : IJob
{
    public int Id { get; set; }

    public async Task Execute(IJobExecutionContext context)
    {
        JobKey key = context.JobDetail.Key;
        JobDataMap dataMap = context.MergedJobDataMap;

        await Console.Out.WriteLineAsync($"ScheduleJob is executing: " +
            $"{key} {Id} run at {DateTime.Now}.");
    }
}
