using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using QuizPlatform.Db.Models;
using QuizPlatform.UserService.Events;
using QuizPlatform.UserService.Features.Roles.Commands.CreateRole;
using QuizPlatform.UserService.Features.Roles.Commands.DeleteRole;
using QuizPlatform.UserService.Features.Roles.Commands.UpdateRole;
using QuizPlatform.UserService.Features.Roles.DTOs;
using QuizPlatform.UserService.Features.Roles.Queries.GetRoleById;
using QuizPlatform.UserService.Features.Roles.Queries.GetRoles;
using QuizPlatform.UserService.Features.Users.Commands;
using QuizPlatform.UserService.Features.Users.Commands.CreateUser;
using QuizPlatform.UserService.Features.Users.Commands.DeleteUser;
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

        #region User
        userEndpoints.MapGet("/GetUsers", LeggiUtenti).WithName("GetUsers").WithOpenApi().RequireAuthorization();
        userEndpoints.MapGet("/GetUser/{id}", LeggiUtente).WithName("GetUser").WithOpenApi().RequireAuthorization();
        userEndpoints.MapGet("/GetUsersByRole/{id}", LeggiUtentiDaRuolo).WithName("GetUsersByRole").WithOpenApi().RequireAuthorization();
        userEndpoints.MapPut("/UpdateUser", ModificaUtente).WithName("UpdateUser").WithOpenApi().RequireAuthorization();
        userEndpoints.MapDelete("/DeleteUser/{id}", EliminaUtente).WithName("DeleteUser").WithOpenApi().RequireAuthorization();
        userEndpoints.MapPost("/CreateUser", NuovoUtente).WithName("CreateUser").WithOpenApi().RequireAuthorization();
        userEndpoints.MapPost("/RemoveUserFromRole/{iduser}/{idrole}", RimuoviUtenteARuolo).WithName("RemoveUserToRole").WithOpenApi().RequireAuthorization();
        userEndpoints.MapPost("/AddUserToRole/{iduser}/{idrole}", AggiungiUtenteARuolo).WithName("AddUserToRole").WithOpenApi().RequireAuthorization();
        #endregion

        #region Login
        userEndpoints.MapGet("/Logout", Logout).WithName("Logout").WithOpenApi();
        userEndpoints.MapPost("/Login", Login).WithName("Login").WithOpenApi();
        #endregion

        #region Role
        userEndpoints.MapGet("/GetRoles", LeggiRuoli).WithName("GetRoles").WithOpenApi().RequireAuthorization();
        userEndpoints.MapGet("/GetRole/{id}", LeggiRuolo).WithName("GetRole").WithOpenApi().RequireAuthorization();
        userEndpoints.MapPost("/CreateRole", NuovoRuolo).WithName("CreateRole").WithOpenApi().RequireAuthorization();
        userEndpoints.MapPut("/UpdateRole", ModificaRuolo).WithName("UpdateRole").WithOpenApi().RequireAuthorization();
        userEndpoints.MapDelete("/DeleteRole/{id}", EliminaRuolo).WithName("DeleteRole").WithOpenApi().RequireAuthorization();
        #endregion
        
    }

    private static async Task<IResult> EliminaRuolo(IMediator mediator, [FromRoute] int id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteRoleCommand(id));
        await mediator.Publish(new RoleDeletedNotification(){Id=id}, CancellationToken.None);
        return Results.Ok();
    }

    private static async Task<IResult> EliminaUtente(IMediator mediator, [FromRoute] int id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteUserCommand(id));
        await mediator.Publish(new UserDeletedNotification(){Id=id}, CancellationToken.None);
        return Results.Ok();
    }

    private static async Task<IResult> RimuoviUtenteARuolo(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task<IResult> ModificaRuolo(IMediator mediator, [FromBody] UpdateRoleDto ruolo)
    {
        var role= await mediator.Send(new UpdateRoleCommand(ruolo));
        await mediator.Publish(new RoleUpdatedNotification(){Ruolo=role}, CancellationToken.None);
        return role is var result?Results.Ok(result):Results.NotFound();
    }

    private static async Task<IResult> ModificaUtente(IMediator mediator, [FromBody] CreateUserDto utente)
    {
        var newUtente= await mediator.Send(new CreateUserCommand(utente));
        await mediator.Publish(new UserUpdatedNotification(){Utente=newUtente}, CancellationToken.None);
        return newUtente is var result?Results.Ok(result):Results.NotFound();
    }

    private static async Task<IResult> Login(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task<IResult> AggiungiUtenteARuolo(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task<IResult> NuovoRuolo(IMediator mediator, [FromBody] CreateRoleDto ruolo)
    {
        var newRole = await mediator.Send(new CreateRoleCommand(ruolo));
        await mediator.Publish(new RoleCreatedNotification(){Ruolo=newRole}, CancellationToken.None);
        return newRole is var result ? Results.Ok(result) : Results.NotFound();
    }

    private static async Task<IResult> NuovoUtente(IMediator mediator, [FromBody] CreateUserDto utente)
    {
        var newUtente= await mediator.Send(new CreateUserCommand(utente));
        await mediator.Publish(new UserCreatedNotification(){Utente=newUtente}, CancellationToken.None);
        return newUtente is var result?Results.Ok(result):Results.NotFound(); 
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