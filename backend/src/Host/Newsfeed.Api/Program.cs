using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newsfeed.Api;
using Newsfeed.Application;
using Newsfeed.Infrastructure.Identity;
using Newsfeed.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    { Title = "Newsfeed API", Description = "A social media for enterprise buidling by hcphi and pmquan", Version = "v1" });
});

// add service layer
builder.Services.AddInfrastructurePersistenceLayer(builder.Configuration);
builder.Services.AddInfrastructureIdentityLayer(builder.Configuration);
builder.Services.AddApplicationLayer();

builder.Services.AddMappingMapster();

// add api version
builder.Services.AddApiVersioning(config =>
{
    // Specify the default API Version as 1.0
    config.DefaultApiVersion = new ApiVersion(1, 0);
    // If the client hasn't specified the API version in the request, use the default API version number 
    config.AssumeDefaultVersionWhenUnspecified = true;
    // Advertise the API versions supported for the particular endpoint
    config.ReportApiVersions = true;
});

// Add services to the container.
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// migration db
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<NewsfeedDbContext>();
    dbContext.Database.Migrate();
    var identityDbContext = scope.ServiceProvider.GetRequiredService<IdentityDbAppContext>();
    identityDbContext.Database.Migrate();
}

app.Run();
 