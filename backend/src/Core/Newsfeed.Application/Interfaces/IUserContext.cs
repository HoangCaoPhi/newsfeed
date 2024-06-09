namespace Newsfeed.Application.Interfaces;
public interface IUserContext
{
    bool IsAuthenticated { get; }

    string UserId { get; }

    string FullName { get; }

    string Email { get; }
}
