using Microsoft.EntityFrameworkCore;
using VideoFlow.Api.Data;
using VideoFlow.Api.Endpoints;
using VideoFlow.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();


app.UseHttpsRedirection();

app.MapGet("/health", () => Results.Ok(new
{
    status = "ok",
    timespan = DateTime.UtcNow.ToString("o")
}));

app.MapUserEndpoints();

app.Run();