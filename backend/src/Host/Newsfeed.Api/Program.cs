using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newsfeed.Api;
using Newsfeed.Api.ErrorHandling;
using Newsfeed.Application;
using Newsfeed.Infrastructure.Identity;
using Newsfeed.Infrastructure.Identity.Models;
using Newsfeed.Infrastructure.Identity.Seeds;
using Newsfeed.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpoints();

// add service layer
builder.Services.AddInfrastructureIdentityLayer(builder.Configuration);
builder.Services.AddInfrastructurePersistenceLayer(builder.Configuration);
builder.Services.AddInfrastructureIdentityLayer(builder.Configuration);
builder.Services.AddApplicationLayer();

builder.Services.AddMappingMapster();

// Configure API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1);
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

// Configure Swagger (if using)
builder.Services.AddSwaggerGen(options =>
{
    var provider = builder.Services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
    foreach (var description in provider.ApiVersionDescriptions)
    {
        options.SwaggerDoc(description.GroupName, new Microsoft.OpenApi.Models.OpenApiInfo()
        {
            Title = $"A social media API with version {description.ApiVersion}, built by HCPHI",
            Version = description.ApiVersion.ToString()
        });
    }
});

// Add services to the container.
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();
app.UseAuthentication(); 
app.UseAuthorization();
app.UseCors("AllowSpecificOrigin");

// migration db
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<NewsfeedDbContext>();
    dbContext.Database.Migrate();
    var identityDbContext = scope.ServiceProvider.GetRequiredService<IdentityDbAppContext>();
    identityDbContext.Database.Migrate();

    // seeding data
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    await DefaultRoles.SeedAsync(roleManager);
    await DefaultAdmin.SeedAsync(userManager);
}


app.UseExceptionHandler();
app.MapEndpoints();
app.Run();
 