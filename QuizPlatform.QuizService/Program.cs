using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using QuizPlatform.QuizService;
using QuizPlatform.QuizService.EndPointDefinitions;
using QuizPlatform.QuizService.Extensions;
using QuizPlatform.QuizService.Repositories.DbContext;

var builder = WebApplication.CreateBuilder(args);

var connectionString=builder.Configuration.GetConnectionString("QuizDataDb");
builder.Services.AddDbContextPool<QuizDbContext>(options =>
    options.UseNpgsql(connectionString, npgsqlBuilder =>
            npgsqlBuilder.MigrationsAssembly(typeof(Program).Assembly.GetName().Name))
        .ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning)));
builder.EnrichNpgsqlDbContext<QuizDbContext>(settings=>settings.DisableRetry=true);

builder.AddRabbitMQClient("messaging");

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireClaim("Admin"));
    options.AddPolicy("UserPolicy", policy => policy.RequireClaim("User"));
    options.AddPolicy("GuestPolicy", policy => policy.RequireClaim("Guest"));
});
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(x =>
    {
        x.Authority = builder.Configuration["Authentication:Authority"];
        x.RequireHttpsMetadata = false;
        x.Audience = builder.Configuration["Authentication:Audience"];
        x.MetadataAddress = builder.Configuration["Authentication:MetaDataAddress"]!;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"]
        };
    });
   
builder.RegisterServices();

builder.RegisterDependencies();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", cfg =>
    {
        cfg.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.RegisterMiddlewares();

app.RegisterProjectEndpoints();