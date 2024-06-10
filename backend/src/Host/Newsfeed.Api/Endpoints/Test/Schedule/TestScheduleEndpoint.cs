
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Newsfeed.Domain.Message;

namespace Newsfeed.Api.Endpoints.Test.Schedule;

public class TestScheduleEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("test/schdule", async([FromBody] ScheduleConfigMessage message, 
                                          ISendEndpointProvider sendEndpointProvider) =>
        {
            var endpoint = await sendEndpointProvider.GetSendEndpoint(new Uri("queue:schedule-config"));

            var cronExpression = message.GenerateCronExpression();
            message.CronExpression = cronExpression;
            await endpoint.Send(message);
        });
    }
}
