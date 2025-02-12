using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations;
using QuizPlatform.Db;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<QuizPlatformDbInitializer>();

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

builder.Services.AddDbContextPool<QuizDataDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("QuizDataDb"), npgsqlBuilder =>
    {
        npgsqlBuilder.MigrationsAssembly("QuizPlatform.Db");
        npgsqlBuilder.MigrationsHistoryTable(
            tableName: HistoryRepository.DefaultTableName,
            schema: "QuizDataDb"
        );
    }).ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning)));
builder.EnrichNpgsqlDbContext<QuizDataDbContext>(settings=>settings.DisableRetry=true);

builder.Services.AddDbContextPool<QuizReportDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("QuizReportDb"), npgsqlBuilder =>
    {
        npgsqlBuilder.MigrationsAssembly("QuizPlatform.Db");  
        npgsqlBuilder.MigrationsHistoryTable(
            tableName: HistoryRepository.DefaultTableName,
            schema: "QuizReportDb"
        );
    }).ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning)));
builder.EnrichNpgsqlDbContext<QuizReportDbContext>(settings=>settings.DisableRetry=true);

builder.Services.AddSingleton<QuizPlatformDbInitializer>();
builder.Services.AddHostedService(sp => sp.GetRequiredService<QuizPlatformDbInitializer>());

var app = builder.Build();

await app.RunAsync();
