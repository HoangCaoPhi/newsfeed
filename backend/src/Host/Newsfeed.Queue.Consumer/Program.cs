using MassTransit;
using Microsoft.EntityFrameworkCore;
using Newsfeed.Queue.Consumer;
using Newsfeed.Queue.Consumer.Consumers;
using Newsfeed.Queue.Consumer.Contexts;
using Quartz;
using Quartz.Impl.AdoJobStore;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var databaseMySqlOptions = builder.Configuration
                                        .GetSection(MySQLOptions.GetSectionName())
                                        .Get<MySQLOptions>();
builder.Services.AddDbContext<ScheduleContext>(options =>
{   
    options.UseMySQL(databaseMySqlOptions.ConnectionString, dbOptions =>
    {
        dbOptions.EnableRetryOnFailure();
    });
});

builder.Services.AddQuartz(q =>
{
    q.UsePersistentStore(c =>
    {
        c.PerformSchemaValidation = true; // default
        c.UseProperties = true; // preferred, but not default
        c.RetryInterval = TimeSpan.FromSeconds(15);

        // Use for MySQL database
        c.UseMySql(mysqlOptions =>
        {
            mysqlOptions.UseDriverDelegate<MySQLDelegate>();
            mysqlOptions.ConnectionString = databaseMySqlOptions.ConnectionString;
        });

        c.UseNewtonsoftJsonSerializer();
        c.UseClustering(c =>
        {
            c.CheckinMisfireThreshold = TimeSpan.FromSeconds(20);
            c.CheckinInterval = TimeSpan.FromSeconds(10);
        });

    });
});

builder.Services.AddQuartzHostedService(opt =>
{
    opt.WaitForJobsToComplete = true;
});

// Masstransit
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ScheduleConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "rabbitmq", h => {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("schedule-config", ep =>
        {
            ep.ConfigureConsumer<ScheduleConsumer>(context);
            ep.PrefetchCount = 16;
            ep.UseMessageRetry(r => r.Interval(2, 100));
        });
    });
});

var host = builder.Build();

// migration db
using (var scope = host.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ScheduleContext>();
    await dbContext.Database.MigrateAsync();
}

host.Run();
