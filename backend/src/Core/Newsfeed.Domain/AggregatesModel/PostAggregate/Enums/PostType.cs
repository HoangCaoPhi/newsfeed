using System.Text.Json.Serialization;

namespace Newsfeed.Domain.AggregatesModel.PostAggregate;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PostType
{
    /// <summary>
    /// Chia sẻ
    /// </summary>
    Share = 1,
    /// <summary>
    /// Tin tức
    /// </summary>
    News = 2,
    /// <summary>
    /// Bình chọn
    /// </summary>
    Poll = 3
}
