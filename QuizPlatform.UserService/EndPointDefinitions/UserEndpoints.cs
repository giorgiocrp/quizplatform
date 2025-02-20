using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using QuizPlatform.Db.Models;
using QuizPlatform.UserService.Features.Roles.Queries.GetRoleById;
using QuizPlatform.UserService.Features.Roles.Queries.GetRoles;
using QuizPlatform.UserService.Features.Users.Commands;
using QuizPlatform.UserService.Features.Users.Commands.CreateUser;
using QuizPlatform.UserService.Features.Users.DTOs;
using QuizPlatform.UserService.Features.Users.Queries.GetUser;
using QuizPlatform.UserService.Features.Users.Queries.GetUserByRole;
using QuizPlatform.UserService.Features.Users.Queries.GetUsers;

namespace QuizPlatform.UserService.EndPointDefinitions;

public static class UserEndpoints
{
    public static void RegisterProjectEndpoints(this IEndpointRouteBuilder routes)
    {
        var userEndpoints = routes.MapGroup("/api/V1/users");
        
        userEndpoints.MapGet("/GetUsers", LeggiUtenti).WithName("GetUsers").WithOpenApi().RequireAuthorization();
        userEndpoints.MapGet("/GetUser/{id}", LeggiUtente).WithName("GetUser").WithOpenApi().RequireAuthorization();
        userEndpoints.MapGet("/GetUsersByRole/{id}", LeggiUtentiDaRuolo).WithName("GetUsersByRole").WithOpenApi().RequireAuthorization();
        userEndpoints.MapGet("/GetRoles", LeggiRuoli).WithName("GetRoles").WithOpenApi().RequireAuthorization();
        userEndpoints.MapGet("/Logout", Logout).WithName("Logout").WithOpenApi();
        
        userEndpoints.MapGet("/GetRoles", LeggiRuoli).WithName("GetRoles").WithOpenApi().RequireAuthorization();
        userEndpoints.MapGet("/GetRole/{id}", LeggiRuolo).WithName("GetRole").WithOpenApi().RequireAuthorization();
        userEndpoints.MapPost("/CreateUser", NuovoUtente).WithName("CreateUser").WithOpenApi().RequireAuthorization();
        userEndpoints.MapPost("/CreateRole", NuovoRuolo).WithName("CreateRole").WithOpenApi().RequireAuthorization();
        userEndpoints.MapPost("/AddUserToRole/{iduser}/{idrole}", AggiungiUtenteARuolo).WithName("AddUserToRole").WithOpenApi().RequireAuthorization();
        userEndpoints.MapPost("/Login", Login).WithName("Login").WithOpenApi();
        
        userEndpoints.MapPut("/UpdateUser", ModificaUtente).WithName("UpdateUser").WithOpenApi().RequireAuthorization();
        userEndpoints.MapPut("/UpdateRole", ModificaRuolo).WithName("UpdateRole").WithOpenApi().RequireAuthorization();
        userEndpoints.MapPost("/RemoveUserFromRole/{iduser}/{idrole}", RimuoviUtenteARuolo).WithName("RemoveUserToRole").WithOpenApi().RequireAuthorization();
        
        userEndpoints.MapDelete("/DeleteUser", EliminaUtente).WithName("DeleteUser").WithOpenApi().RequireAuthorization();
        userEndpoints.MapDelete("/DeleteRole", EliminaRuolo).WithName("DeleteRole").WithOpenApi().RequireAuthorization();
       
    }

    private static async Task<IResult> EliminaRuolo(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task<IResult> EliminaUtente(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task<IResult> RimuoviUtenteARuolo(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task<IResult> ModificaRuolo(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task<IResult> ModificaUtente(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task<IResult> Login(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task<IResult> AggiungiUtenteARuolo(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task<IResult> NuovoRuolo(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task<IResult> NuovoUtente(IMediator mediator, [FromBody] CreateUserDto utente)
    {
        return await mediator.Send(new CreateUserCommand(utente)) is var result
            ? Results.Ok(result)
            : Results.NotFound();
    }

    private static async Task<IResult> Logout(HttpContext context)
    {
        throw new NotImplementedException();
    }
    
    private static async Task<IResult> LeggiRuolo(IMediator mediator, [FromRoute] int id, CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetRoleByIdQuery(id), cancellationToken) is var result
            ? Results.Ok(result)
            : Results.NotFound();
    }

    private static async Task<IResult> LeggiRuoli(IMediator mediator, CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetRolesQuery(), cancellationToken) is var result
            ? Results.Ok(result)
            : Results.NotFound();
    }

    private static async Task<IResult> LeggiUtentiDaRuolo(IMediator mediator, [FromRoute] int id, CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetUserByRoleQuery(id), cancellationToken) is var result
            ? Results.Ok(result)
            : Results.NotFound();
    }

    public static async Task<IResult> LeggiUtenti(IMediator mediator, CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetUsersQuery(), cancellationToken) is var result
            ? Results.Ok(result)
            : Results.NotFound();
    } 
    
    public static async Task<IResult> LeggiUtente(IMediator mediator, [FromRoute] int id, CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetUserQuery(id), cancellationToken) is var result
            ? Results.Ok(result)
            : Results.NotFound();
    } 
    
}