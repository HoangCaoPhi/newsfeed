using MassTransit;
using Newsfeed.Domain.Message;
using Newsfeed.Queue.Consumer.Services;

namespace Newsfeed.Queue.Consumer.Consumers;
public class ScheduleConsumer(IServiceProvider serviceProvider) : IConsumer<ScheduleConfigMessage>
{
    public async Task Consume(ConsumeContext<ScheduleConfigMessage> context)
    {
        if(context is null) return;

        var data = context.Message;

        await ScheduleService.Run(data, serviceProvider);
    }
}
