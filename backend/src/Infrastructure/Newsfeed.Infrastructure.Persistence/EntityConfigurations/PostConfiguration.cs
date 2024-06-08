using Newsfeed.Domain.AggregatesModel.PostAggregate;
using Newsfeed.Domain.AggregatesModel.PostAggregate.Enums;
using Newsfeed.Domain.SeedWork;

namespace Newsfeed.Infrastructure.Persistence.EntityConfigurations;
internal class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.OwnsOne(x => x.Author);

        builder.Property(e => e.PostType)
         .HasConversion(
             v => v.Name,
             v => Enumeration.FromDisplayName<PostType>(v))
         .HasMaxLength(255);

        builder.Property(e => e.DisplayMode)
         .HasConversion(
             v => v.Name,
             v => Enumeration.FromDisplayName<DisplayMode>(v))
         .HasMaxLength(255);
 
        builder.OwnsMany(x => x.PostAttachments, options =>
        {
            options.ToTable("PostAttachments");
            options.HasKey(NewsfeedDbSchema.KeyDefault);
        });

        builder.OwnsMany(x => x.PostHashTags, options =>
        {
            options.ToTable("PostHashTags");
            options.HasKey(NewsfeedDbSchema.KeyDefault);
        });

        builder.OwnsMany(x => x.PostCategories, builder =>
        {
            builder.ToTable("PostCategories");
            builder.HasKey(NewsfeedDbSchema.KeyDefault);
        });

        builder.HasMany<Reaction>().WithOne();
    }
}
