using Microsoft.AspNetCore.Mvc;
using VideoFlow.Api.Videos;

namespace VideoFlow.Api.Users;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        app.MapGet("/users", async (IUserService userService) => await userService.GetAll());

        app.MapGet("/users/{id}", async (int id, IUserService userService) =>
        {
            var user = await userService.GetById(id);
            return user is not null ? Results.Ok(user) : Results.NotFound();
        });

        app.MapGet("/users/{id}/videos", async (int id, IVideoService videoService) =>
        {
            var videos = await videoService.GetByUserId(id);
            return videos is null ? Results.NotFound() : Results.Ok(videos);
        });

        app.MapPost("/users", async (CreateUserDto userDto, IUserService userService) =>
        {
            var user = await userService.Create(userDto);
            return Results.Created($"/users/{user.Id}", user);
        });
    }
}