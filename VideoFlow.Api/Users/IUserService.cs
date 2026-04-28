using VideoFlow.Api.Common;

namespace VideoFlow.Api.Users;

public interface IUserService
{
    Task<UserDto?> GetById(int id);
    Task<List<UserDto>> GetAll();
    Task<Result<UserDto>> Create(CreateUserDto userDto);
}
