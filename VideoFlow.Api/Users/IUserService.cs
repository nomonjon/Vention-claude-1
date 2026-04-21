namespace VideoFlow.Api.Users;

public interface IUserService
{
    Task<User?> GetById(int id);
    Task<List<User>> GetAll();
    Task<User> Create(CreateUserDto userDto);
}
