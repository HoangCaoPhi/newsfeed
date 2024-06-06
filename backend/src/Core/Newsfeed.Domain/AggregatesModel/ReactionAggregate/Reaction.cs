using Newsfeed.Domain.AggregatesModel.PostAggregate.Enums;
using Newsfeed.Domain.AggregatesModel.ReactionAggregate.ValueObjects;

namespace Newsfeed.Domain.AggregatesModel.PostAggregate;

public class Reaction : BaseEntity, IAggregateRoot
{
    public ReactionType ReactionType { get; init; }

    public int PostId { get; init; }

    private readonly List<UserReaction> _userReactions;

    public IReadOnlyCollection<UserReaction> UserReactions => _userReactions.AsReadOnly();
}
