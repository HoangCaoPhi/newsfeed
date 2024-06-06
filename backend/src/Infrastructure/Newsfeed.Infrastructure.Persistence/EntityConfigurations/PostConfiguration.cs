using Newsfeed.Domain.AggregatesModel.PostAggregate;

namespace Newsfeed.Infrastructure.Persistence.EntityConfigurations;
internal class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable(NewsfeedDbSchema.Post.TableName);

        builder.OwnsOne(x => x.Author);

        builder.Property(x => x.PostType)
               .IsRequired()
               .HasConversion<string>()
               .HasMaxLength(10);

        builder.OwnsMany(x => x.PostAttachments, options =>
        {
            options.HasKey(NewsfeedDbSchema.KeyDefault);
        });

        builder.OwnsMany(x => x.HashTags, options =>
        {
            options.HasKey(NewsfeedDbSchema.KeyDefault);
        });

        builder.HasMany(x => x.Categories).WithMany();

        builder.HasMany<Reaction>().WithOne();
    }
}
