namespace Newsfeed.Domain.AggregatesModel.PostAggregate.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DisplayMode
{
    Public = 1,
    Private = 2
}
