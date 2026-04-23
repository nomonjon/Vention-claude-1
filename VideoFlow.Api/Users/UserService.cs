using Microsoft.EntityFrameworkCore;
using VideoFlow.Api.Data;
using VideoFlow.Api.Videos;

namespace VideoFlow.Api.Users;


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

    public async Task<List<UserDto>> GetAll()
    {
        var users = await context.Users.AsNoTracking().Select(u => new UserDto
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email,
            Videos = u.Videos.Select(v => v.ToDtoForUser()).ToList()
        }).ToListAsync();
        return users;
    }

    public async Task<UserDto?> GetById(int id)
    {
        var user =  await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        return user?.ToDto();
    }
}