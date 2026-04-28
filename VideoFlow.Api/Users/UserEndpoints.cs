using FluentValidation;
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

        app.MapPost("/users", async (CreateUserDto userDto, IUserService userService, IValidator<CreateUserDto> validator) =>
        {
            var validationResult = await validator.ValidateAsync(userDto);
            if(validationResult.IsValid is false)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }
            var user = await userService.Create(userDto);
            return user.IsSuccess 
                ? Results.Created($"/users/{user.Value!.Id}", user.Value) 
                : Results.BadRequest(user.Error);
        });
    }
}