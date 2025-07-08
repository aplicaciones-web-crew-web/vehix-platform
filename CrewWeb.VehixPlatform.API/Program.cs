using Cortex.Mediator.Commands;
using Cortex.Mediator.DependencyInjection;
using CrewWeb.VehixPlatform.API.Analytics.Application.Internal.CommandServices;
using CrewWeb.VehixPlatform.API.Analytics.Application.Internal.QueryServices;
using CrewWeb.VehixPlatform.API.Analytics.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Analytics.Domain.Services;
using CrewWeb.VehixPlatform.API.Analytics.Infrastructure.Persistence.EFC.Repositories;
using CrewWeb.VehixPlatform.API.ASM.Application.Internal;
using CrewWeb.VehixPlatform.API.ASM.Application.Internal.QueryServices;
using CrewWeb.VehixPlatform.API.ASM.Domain.Repositories;
using CrewWeb.VehixPlatform.API.ASM.Domain.Services;
using CrewWeb.VehixPlatform.API.ASM.Infrastructure.Persistence.EFC.Repositories;
using CrewWeb.VehixPlatform.API.IAM.Application.Internal.CommandServices;
using CrewWeb.VehixPlatform.API.IAM.Application.Internal.QueryServices;
using CrewWeb.VehixPlatform.API.IAM.Domain.Repositories;
using CrewWeb.VehixPlatform.API.IAM.Domain.Services;
using CrewWeb.VehixPlatform.API.IAM.Infrastructure.Hashing.BCrypt.Services;
using CrewWeb.VehixPlatform.API.IAM.Infrastructure.Tokens.JWT.Services;
using CrewWeb.VehixPlatform.API.IAM.Infrastructure.Tokens.JWT.Configuration;
using CrewWeb.VehixPlatform.API.IAM.Application.Internal.OutboundServices;
using CrewWeb.VehixPlatform.API.IAM.Infrastructure.Persistence.EFC.Repositories;
using CrewWeb.VehixPlatform.API.SAP.Application.Internal.CommandServices;
using CrewWeb.VehixPlatform.API.SAP.Application.Internal.QueryServices;
using CrewWeb.VehixPlatform.API.SAP.Domain.Repositories;
using CrewWeb.VehixPlatform.API.SAP.Domain.Services;
using CrewWeb.VehixPlatform.API.SAP.Infrastructure.Persistence.EFC.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Domain.Exceptions;
using CrewWeb.VehixPlatform.API.Shared.Domain.Repositories;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using CrewWeb.VehixPlatform.API.Shared.Infrastructure.Mediator.Cortex.Configuration;
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

//Subscription Bounded Context
// Repositories
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
// Commands Services
builder.Services.AddScoped<IPlanCommandService, PlanCommandService>();
builder.Services.AddScoped<IPaymentCommandService, PaymentCommandService>();
// Queries Services
builder.Services.AddScoped<IPlanQueryService, PlanQueryService>();
builder.Services.AddScoped<IPaymentQueryService, PaymentQueryService>();

// Anlytics Bounded Context
// Repositories
builder.Services.AddScoped<IAnalyticRepository, AnalyticRepository>();
// Commands Services
builder.Services.AddScoped<IAnalyticCommandService, AnalyticCommandService>();
// Queries Services
builder.Services.AddScoped<IAnalyticQueryService, AnalyticQueryService>();

// Assets and Resource Management Bounded Context
// Repositories
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
// Commands Services
builder.Services.AddScoped<IVehicleCommandService, VehicleCommandService>();
// Queries Services
builder.Services.AddScoped<IVehicleQueryService, VehicleQueryService>();

/*
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
*/
// Identity and Access Management Bounded Context
// Repositories
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
// Commands Services
builder.Services.AddScoped<IRoleCommandService, RoleCommandService>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
// Queries Services
builder.Services.AddScoped<IRoleQueryService, RoleQueryService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
// Authentication Services
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));


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
    if (app.Environment.IsDevelopment())
    {
        // Recreate the database on each run during development
        context.Database.EnsureDeleted();
    }
    context.Database.EnsureCreated();
}

// Use Swagger for API documentation if in development mode
//if (app.Environment.IsDevelopment())
//{
 //   app.UseSwagger();
 //   app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

// Apply CORS Policy
app.UseCors("AllowAllPolicy");

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();