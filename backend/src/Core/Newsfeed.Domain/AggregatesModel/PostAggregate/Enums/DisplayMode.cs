namespace Newsfeed.Domain.AggregatesModel.PostAggregate.Enums;

public class DisplayMode : Enumeration
{
    public static DisplayMode Public = new(1, nameof(Public));
    public static DisplayMode Private = new(2, nameof(Private));

    protected DisplayMode(int id, string name) : base(id, name)
    {
    }
}
