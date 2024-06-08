namespace Newsfeed.Infrastructure.Persistence.EntityConfigurations;
public class NewsfeedDbSchema
{
    public const string KeyDefault = "Id";

    public static class Category
    {
        public const string Categories = "Categories";
    }

    public static class Post
    {
        public const string Posts = "Posts";
        public const string PostCategoryIds = "PostCategoryIds";
        public const string CategoryId = "CategoryId";
    }

    public static class Reaction
    {
        public const string ReactionUserIds = "ReactionUserIds";
        public const string UserId = "UserId";
    }
}
