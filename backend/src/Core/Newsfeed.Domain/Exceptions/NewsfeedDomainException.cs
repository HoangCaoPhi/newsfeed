namespace Newsfeed.Domain.Exceptions;
public class NewsfeedDomainException : Exception
{
    public NewsfeedDomainException()
    { }

    public NewsfeedDomainException(string message)
        : base(message)
    { }

    public NewsfeedDomainException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
