namespace VideoFlow.Api.Users;

public interface IUserService
{
    Task<User?> GetById(int id);
    Task<List<UserDto>> GetAll();
    Task<User> Create(CreateUserDto userDto);
}
