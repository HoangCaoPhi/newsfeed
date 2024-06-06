namespace Newsfeed.Domain.AggregatesModel.PostAggregate;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PostStatus
{
    Draft = 1,
    Public = 2
}
