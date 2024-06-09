namespace Newsfeed.Domain.SeedWork;
public interface IRecordHistory
{
    public DateTime? Created { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public string ModifiedBy { get; set; }

    public Guid EditVersion { get; set; }
}
