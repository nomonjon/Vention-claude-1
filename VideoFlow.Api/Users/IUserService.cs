namespace VideoFlow.Api.Users;

public interface IUserService
{
    Task<UserDto?> GetById(int id);
    Task<List<UserDto>> GetAll();
    Task<User> Create(CreateUserDto userDto);
}
