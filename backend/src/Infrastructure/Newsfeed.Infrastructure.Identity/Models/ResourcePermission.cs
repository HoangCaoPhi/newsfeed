namespace Newsfeed.Infrastructure.Identity.Models;
internal class ResourcePermission
{
    public string Resource { get; set; }
    public string[] Action { get; set; }
}