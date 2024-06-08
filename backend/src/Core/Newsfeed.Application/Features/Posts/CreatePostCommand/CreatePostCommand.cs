using MediatR;

namespace Newsfeed.Application.Features.Posts.CreatePostCommand;
public record CreatePostCommand() : IRequest<bool>;