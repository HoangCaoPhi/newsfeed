namespace Newsfeed.Domain.AggregatesModel.PostAggregate;

public class PostType : Enumeration
{
    /// <summary>
    /// Chia sẻ
    /// </summary>
    public static PostType Share = new(1, nameof(Share));
    /// <summary>
    /// Tin tức
    /// </summary>
    public static PostType News = new(2, nameof(News));
    /// <summary>
    /// Bình chọn
    /// </summary>
    public static PostType Poll = new(3, nameof(Poll));

    protected PostType(int id, string name) : base(id, name)
    {
    }
}
