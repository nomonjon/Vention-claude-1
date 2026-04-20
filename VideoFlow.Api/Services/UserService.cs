using VideoFlow.Api.Dtos;
using VideoFlow.Api.Models;

namespace VideoFlow.Api.Services;


public class UserService : IUserService
{
    private List<User> users =
    [
        new() { Id = 1, Name = "Alice", Email = "alice@example.com" },
        new() { Id = 2, Name = "Bob", Email = "bob@example.com" },
        new() { Id = 3, Name = "Charlie", Email = "charlie@example.com" }
    ];

    private int nextId = 4;

    public User Create(CreateUserDto userDto)
    {
        var user =
            new User
            {
                Id = nextId++,
                Name = userDto.Name,
                Email = userDto.Email
            };

        users.Add(user);

        return user;
    }

    public List<User> GetAll()
    {
        return users;
    }

    public User? GetById(int id)
    {
        return users.FirstOrDefault(u => u.Id == id);
    }
}