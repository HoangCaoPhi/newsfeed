namespace Newsfeed.Infrastructure.Persistence.Options;
public class MySQLOptions
{
    public static string GetSectionName() => "MySQLOptions";

    public required string ConnectionString { get; set; }

    public required string NotificationDbConnectionString { get; set; }

    public int EnableRetryOnFailure { get; set; }
}