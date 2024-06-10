namespace Newsfeed.Queue.Consumer;
public class MySQLOptions
{
    public static string GetSectionName() => "MySQLOptions";

    public required string ConnectionString { get; set; }
}