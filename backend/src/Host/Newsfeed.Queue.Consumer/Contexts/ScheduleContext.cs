using AppAny.Quartz.EntityFrameworkCore.Migrations;
using AppAny.Quartz.EntityFrameworkCore.Migrations.MySql;
using Microsoft.EntityFrameworkCore;

namespace Newsfeed.Queue.Consumer.Contexts;
public class ScheduleContext(DbContextOptions<ScheduleContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Prefix and schema can be passed as parameters

        // Adds Quartz.NET MySql schema to EntityFrameworkCore
        modelBuilder.AddQuartz(builder => builder.UseMySql());
    }
}
