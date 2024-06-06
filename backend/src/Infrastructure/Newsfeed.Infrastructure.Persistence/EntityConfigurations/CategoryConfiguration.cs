using Newsfeed.Domain.AggregatesModel.CategoryAggregate;

namespace Newsfeed.Infrastructure.Persistence.EntityConfigurations;
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.CategoryName)
               .IsRequired()
               .HasMaxLength(500);
    }
}
