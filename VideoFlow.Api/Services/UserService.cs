using Microsoft.EntityFrameworkCore;
using VideoFlow.Api.Data;
using VideoFlow.Api.Dtos;
using VideoFlow.Api.Models;

namespace VideoFlow.Api.Services;


public class UserService(AppDbContext context) : IUserService
{

    public async Task<User> Create(CreateUserDto userDto)
    {
        var user = new User
        {
            Name = userDto.Name,
            Email = userDto.Email
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return user;
    }

    public async Task<List<User>> GetAll()
    {
        return await context.Users.AsNoTracking().ToListAsync();
    }

    public async Task<User?> GetById(int id)
    {
        return await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
    }
}