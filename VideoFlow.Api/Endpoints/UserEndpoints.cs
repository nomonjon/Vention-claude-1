using Microsoft.AspNetCore.Mvc;
using VideoFlow.Api.Dtos;
using VideoFlow.Api.Services;

namespace VideoFlow.Api.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        app.MapGet("/users", (IUserService userService) => userService.GetAll());

        app.MapGet("/users/{id}", (int id, IUserService userService) =>
        {
            var user = userService.GetById(id);
            return user is not null ? Results.Ok(user) : Results.NotFound();
        });
        
        app.MapPost("/users", (CreateUserDto userDto, IUserService userService) =>
        {
            var user = userService.Create(userDto);
            return Results.Created($"/users/{user.Id}", user);
        });
    }
}