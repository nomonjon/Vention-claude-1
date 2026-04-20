using Microsoft.EntityFrameworkCore;
using VideoFlow.Api.Data;
using VideoFlow.Api.Dtos;
using VideoFlow.Api.Models;

namespace VideoFlow.Api.Services;


public class UserService(AppDbContext _context) : IUserService
{
    private readonly AppDbContext context = _context;
    public async Task<User> Create(CreateUserDto userDto)
    {
        var user = new User
        {
            Name = userDto.Name,
            Email = userDto.Email
        };

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        return user;
    }

    public async Task<List<User>> GetAll()
    {
        return await context.Users.ToListAsync();
    }

    public async Task<User?> GetById(int id)
    {
        return await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
    }
}