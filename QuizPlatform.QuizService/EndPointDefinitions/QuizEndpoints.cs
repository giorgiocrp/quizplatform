using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QuizPlatform.QuizService.EndPointDefinitions;

public static class QuizEndpoints
{
    public static void RegisterProjectEndpoints(this IEndpointRouteBuilder routes)
    {
        var userEndpoints = routes.MapGroup("/api/V1/quiz");
        
    }
    
}