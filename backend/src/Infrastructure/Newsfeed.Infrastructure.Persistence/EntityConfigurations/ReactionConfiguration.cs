using Newsfeed.Domain.AggregatesModel.PostAggregate;

namespace Newsfeed.Infrastructure.Persistence.EntityConfigurations;
internal class ReactionConfiguration : IEntityTypeConfiguration<Reaction>
{
    public void Configure(EntityTypeBuilder<Reaction> builder)
    {
        builder.OwnsMany(x => x.UserReactions, options =>
        {
            options.ToTable(NewsfeedDbSchema.Reaction.TableName);
            options.Property(x => x.Value).HasColumnName(NewsfeedDbSchema.Reaction.UserIdColumnName);
            options.HasKey(NewsfeedDbSchema.KeyDefault);
        });
    }
}
