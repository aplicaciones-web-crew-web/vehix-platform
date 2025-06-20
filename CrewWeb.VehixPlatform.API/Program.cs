using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Mediator.Cortex.Configuration;
using Cortex.Mediator.Commands;
using Cortex.Mediator.DependencyInjection;
using CrewWeb.VehixPlatform.API.Monitoring.Application.Internal.CommandServices;
using CrewWeb.VehixPlatform.API.Monitoring.Application.Internal.QueryServices;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Monitoring.Domain.Services;
using CrewWeb.VehixPlatform.API.Monitoring.Infrastructure.Persistence.EFC.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add ASP.NET Core MVC with Kebab Case Route Naming Convention
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
builder.Services.AddEndpointsApiExplorer();

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add Configuration for Entity Framework Core
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString == null) throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
});

// Add Swagger/OpenAPI support
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CrewWeb Vehix Platform API",
        Version = "v1",
        Description = "API for the CrewWeb Vehix Platform API",
        TermsOfService = new Uri("https://crew-web-vehix.com/tos"),
        Contact = new OpenApiContact
        {
            Name = "CrewWeb Team",
            Email = "contact@crewweb.com"
        },
        License = new OpenApiLicense
        {
            Name = "Apache 2.0",
            Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
        },
    });
    options.EnableAnnotations();
});

// Dependency Injection

// Shared Bounded Context
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Monitoring Bounded Context
// Repositories
builder.Services.AddScoped<IBadPracticeRepository, BadPracticeRepository>();
builder.Services.AddScoped<IOdbErrorRepository, OdbErrorRepository>();
builder.Services.AddScoped<IFailureRepository, FailureRepository>();
//Commands Services
builder.Services.AddScoped<IBadPracticeCommandService, BadPracticeCommandService>();
builder.Services.AddScoped<IOdbErrorCommandService, OdbErrorCommandService>();
builder.Services.AddScoped<IFailureCommandService, FailureCommandService>();
//Queries Services
builder.Services.AddScoped<IBadPracticeQueryService, BadPracticeQueryService>();
builder.Services.AddScoped<IOdbErrorQueryService, OdbErrorQueryService>();
builder.Services.AddScoped<IFailureQueryService, FailureQueryService>();

builder.Services.AddScoped(typeof(ICommandPipelineBehavior<>), typeof(LoggingCommandBehavior<>));

// Add Mediator for CQRS
builder.Services.AddCortexMediator(
    configuration: builder.Configuration,
    handlerAssemblyMarkerTypes: new[] { typeof(Program) }, configure: options =>
    {
        options.AddOpenCommandPipelineBehavior(typeof(LoggingCommandBehavior<>));
        //options.AddDefaultBehaviors();
    });

var app = builder.Build();

// Verify if the database exists and create it if it doesn't
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();
}

// Use Swagger for API documentation if in development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply CORS Policy
app.UseCors("AllowAllPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();