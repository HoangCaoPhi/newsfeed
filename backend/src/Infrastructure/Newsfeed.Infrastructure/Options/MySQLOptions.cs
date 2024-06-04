namespace Newsfeed.Infrastructure.Persistence.Options;
public class MySQLOptions
{
    public static string ConfigName = "MySQLOptions";

    public string ConnectionString { get; set; }

    public int EnableRetryOnFailure { get; set; }
}