using VideoFlow.Api.Videos;

namespace VideoFlow.Api.Users;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<VideoDtoForUser> Videos { get; set; } = [];
}


public class CreateUserDto
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;

}

public static class UserMapper
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }

    public static User ToEntity(this CreateUserDto userDto)
    {
        return new User
        {
            Name = userDto.Name,
            Email = userDto.Email
        };
    }
}