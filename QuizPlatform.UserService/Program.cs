using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using QuizPlatform.Db;
using QuizPlatform.Db.Models;
using QuizPlatform.UserService.EndPointDefinitions;
using QuizPlatform.UserService.Extensions;
using QuizPlatform.UserService.Repositories.DbContext;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

var connectionString=builder.Configuration.GetConnectionString("QuizDataDb");
builder.Services.AddDbContextPool<UserDbContext>(options =>
    options.UseNpgsql(connectionString, npgsqlBuilder =>
        npgsqlBuilder.MigrationsAssembly(typeof(Program).Assembly.GetName().Name))
        .ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning)));
builder.EnrichNpgsqlDbContext<UserDbContext>(settings=>settings.DisableRetry=true);

builder.AddRabbitMQClient("messaging");

builder.Services.AddAuthorization();
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(x =>
    {
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

app.Run();