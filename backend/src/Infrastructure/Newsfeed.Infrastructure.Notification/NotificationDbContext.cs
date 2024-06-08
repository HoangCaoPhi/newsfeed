using Microsoft.EntityFrameworkCore;

namespace Newsfeed.Infrastructure.Notification;
public class NotificationDbContext(DbContextOptions<NotificationDbContext> options) : DbContext(options)
{
}
