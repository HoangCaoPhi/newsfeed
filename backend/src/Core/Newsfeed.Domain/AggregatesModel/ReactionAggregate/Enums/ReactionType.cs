namespace Newsfeed.Domain.AggregatesModel.PostAggregate.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ReactionType
{
    Like = 1,
    Love = 2,
    Sad = 3
}