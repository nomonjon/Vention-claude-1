using FluentValidation;
using Microsoft.EntityFrameworkCore;
using VideoFlow.Api.Data;
using VideoFlow.Api.Users;
using VideoFlow.Api.Videos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IVideoService, VideoService>();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();


app.UseHttpsRedirection();

app.MapGet("/health", () => Results.Ok(new
{
    status = "ok",
    timespan = DateTime.UtcNow.ToString("o")
}));

app.MapVideoEndpoints();
app.MapUserEndpoints();


app.UseExceptionHandler(errorapp =>
{
    errorapp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new
        {
            type = "InternalServerError",
            message = "An unexpected error occurred. Please try again later."
        });
    });
});

app.Run();