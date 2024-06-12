namespace Newsfeed.Application.Features.Posts.Queries.GetOne;
public record GetOnePostQuery(int PostId) : IRequest<ServiceResponse<GetOnePostResponse>>;