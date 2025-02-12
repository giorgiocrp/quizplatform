var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var user = builder.AddParameter("keycloakusername");
var pass = builder.AddParameter("keycloakpassword", secret: true);

var keycloak = builder.AddKeycloak("keycloak", 8080, user,pass)
    .WithDataVolume();

var postgres = builder.AddPostgres("postgres")
    .WithPgAdmin()
    .WithDataVolume();

var username = builder.AddParameter("messagingusername", secret: true);
var password = builder.AddParameter("messagingpassword", secret: true);

var messaging = builder.AddRabbitMQ("messaging", username, password)
    .WithManagementPlugin();

var quizDb = postgres.AddDatabase("QuizDataDb");
var reportDb = postgres.AddDatabase("QuizReportDb");

var dbmanager= builder.AddProject<Projects.QuizPlatform_DbManager>("dbmanagerservice")
    .WithReference(keycloak)
    .WaitFor(keycloak)
    .WithReference(quizDb)
    .WaitFor(quizDb)
    .WithReference(reportDb)
    .WaitFor(reportDb);

var apiService = builder.AddProject<Projects.QuizPlatform_ApiService>("apiservice")
    .WithReference(keycloak)
    .WaitFor(keycloak);

var quizService = builder.AddProject<Projects.QuizPlatform_QuizService>("quizservice")
    .WithReference(keycloak)
    .WaitFor(keycloak)
    .WithReference(messaging)
    .WaitFor(messaging)
    .WithReference(quizDb)
    .WaitFor(quizDb)
    .WithExternalHttpEndpoints();

var reportService = builder.AddProject<Projects.QuizPlatform_ReportService>("reportservice")
    .WithReference(keycloak)
    .WaitFor(keycloak)
    .WithReference(messaging)
    .WaitFor(messaging)
    .WithReference(reportDb)
    .WaitFor(reportDb)
    .WithExternalHttpEndpoints();

var userService = builder.AddProject<Projects.QuizPlatform_UserService>("userservice")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(keycloak)
    .WaitFor(keycloak)
    .WithReference(messaging)
    .WaitFor(messaging)
    .WithReference(quizDb)
    .WaitFor(quizDb)
    .WithExternalHttpEndpoints();

builder.AddProject<Projects.QuizPlatform_Web>("webfrontend")
    .WithReference(keycloak)
    .WaitFor(keycloak)
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(userService)
    .WaitFor(userService)
    .WithReference(quizService)
    .WaitFor(quizService)
    .WithReference(reportService)
    .WaitFor(reportService)
    .WithReference(apiService)
    .WaitFor(apiService)
    .WithExternalHttpEndpoints();

builder.Build().Run();
