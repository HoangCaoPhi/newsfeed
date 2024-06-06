namespace Newsfeed.Infrastructure.Persistence.EntityConfigurations;
public class NewsfeedDbSchema
{
    public const string KeyDefault = "Id";

    public static class Category
    {
        public const string TableName = "Categories";
    }

    public static class Post
    {
        public const string TableName = "Posts";
        public const string CategoryIdTableName = "PostCategoryIds";
        public const string CategoryIdColumnName = "CategoryId";
    }

    public static class Reaction
    {
        public const string TableName = "ReactionUserIds";
        public const string UserIdColumnName = "UserId";
    }
}
