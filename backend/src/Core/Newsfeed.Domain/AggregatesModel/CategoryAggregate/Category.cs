
namespace Newsfeed.Domain.AggregatesModel.CategoryAggregate;
public class Category : BaseEntity, IAggregateRoot, IRecordHistory
{
    public string CategoryName { get; private set; }
    public DateTime? Created { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public string ModifiedBy { get; set; }
    public Guid EditVersion { get; set; }

    public Category(string categoryName)
    {
        CategoryName = categoryName;
    }
}
