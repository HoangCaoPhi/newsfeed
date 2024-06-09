using Newsfeed.Domain.AggregatesModel.PostAggregate.Enums;
using Newsfeed.Domain.AggregatesModel.ReactionAggregate.ValueObjects;

namespace Newsfeed.Domain.AggregatesModel.PostAggregate;

public class Reaction : BaseEntity, IAggregateRoot, IRecordHistory
{
    public ReactionType ReactionType { get; init; }

    public int PostId { get; init; }

    private readonly List<UserReaction> _userReactions;

    public IReadOnlyCollection<UserReaction> UserReactions => _userReactions.AsReadOnly();

    public DateTime? Created { get ; set ; }
    public string CreatedBy { get ; set ; }
    public DateTime? Modified { get ; set ; }
    public string ModifiedBy { get ; set ; }
    public Guid EditVersion { get ; set ; }
}
