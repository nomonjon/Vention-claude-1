using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;

namespace VideoFlow.Api.Videos;

public static class VideoEndpoints
{
    public static void MapVideoEndpoints(this WebApplication app)
    {
        app.MapGet("/videos", async (IVideoService videoService) =>
        {
            var videos = await videoService.GetAll();
            return Results.Ok(videos);
        });

        app.MapGet("/videos/{id}", async (int id, IVideoService videoService) =>
        {

            var video = await videoService.GetById(id);
            return video is not null ? Results.Ok(video) : Results.NotFound();

        });

        app.MapPost("/videos", async (CreateVideoDto videoDto, IVideoService videoService, IValidator<CreateVideoDto> validator) =>
        {
            var validationResult = await validator.ValidateAsync(videoDto);
            if (validationResult.IsValid is false)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            var video = await videoService.Create(videoDto);
            return video.IsSuccess
                ? Results.Created($"/videos/{video.Value!.Id}", video.Value)
                : Results.BadRequest(video.Error);
        });
    }
}