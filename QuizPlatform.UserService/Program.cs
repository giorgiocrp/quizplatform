using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using QuizPlatform.Db;
using QuizPlatform.Db.Models;
using QuizPlatform.UserService.EndPointDefinitions;
using QuizPlatform.UserService.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.AddNpgsqlDbContext<QuizDataDbContext>("neoreportDb",
    null,
    optionsBuilder => optionsBuilder.UseNpgsql(npgsqlBuilder =>
        npgsqlBuilder.MigrationsAssembly(typeof(Program).Assembly.GetName().Name)));

builder.AddRabbitMQClient("messaging");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddKeycloakJwtBearer(
        serviceName: "keycloak",
        realm: "QuizPlatformRealm",
        configureOptions: options =>
        {
            options.RequireHttpsMetadata = false;
            options.Audience = builder.Configuration["Authentication:Audience"];
            options.MetadataAddress = builder.Configuration["Authentication:MetaDataAddress"]!;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Authentication:Issuer"],
                ValidAudience = builder.Configuration["Authentication:Audience"]
            };
        });

builder.Services.AddAuthorizationBuilder();

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