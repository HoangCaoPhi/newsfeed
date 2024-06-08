using Newsfeed.Domain.AggregatesModel.PostAggregate;

namespace Newsfeed.Infrastructure.Persistence.EntityConfigurations;
internal class ReactionConfiguration : IEntityTypeConfiguration<Reaction>
{
    public void Configure(EntityTypeBuilder<Reaction> builder)
    {
        builder.OwnsMany(x => x.UserReactions, options =>
        {            
            options.Property(x => x.Value).HasColumnName(NewsfeedDbSchema.Reaction.UserId);
            options.HasKey(NewsfeedDbSchema.KeyDefault);
        });
    }
}
