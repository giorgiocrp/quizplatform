using FluentValidation;
using MediatR;
using QuizPlatform.UserService.Behaviors;
using QuizPlatform.UserService.Middleware;
using QuizPlatform.UserService.Profiles;
using QuizPlatform.UserService.Repositories.Implementations;
using QuizPlatform.UserService.Repositories.Interfaces;
using QuizPlatform.UserService.Services.Implementations;
using QuizPlatform.UserService.Services.Interfaces;
using Scalar.AspNetCore;

namespace QuizPlatform.UserService.Extensions;

public static class Configuration
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddProblemDetails()
            .AddEndpointsApiExplorer();

        builder.Services.AddOpenApi();
    }

    public static void RegisterMiddlewares(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        app.UseHttpsRedirection();
        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        app.UseAuthentication();
        app.UseAuthorization();
    }

    public static void RegisterDependencies(this WebApplicationBuilder builder)
    {
        // Add services to DI.
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, Services.Implementations.UserService>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
        builder.Services.AddScoped<IRoleService, Services.Implementations.RoleService>();
        builder.Services.AddScoped<IKeycloakService, KeycloakService>();
        // builder.Services.AddScoped<INotificationService, NotificationService>();
        builder.Services.AddAutoMapper(expression =>
        {
            expression.AllowNullCollections = true;
        },typeof(MappingProfile));
    }
}