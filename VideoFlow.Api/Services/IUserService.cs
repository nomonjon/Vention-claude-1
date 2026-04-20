using VideoFlow.Api.Dtos;
using VideoFlow.Api.Models;

namespace VideoFlow.Api.Services;

public interface IUserService
{
    Task<User?> GetById(int id);
    Task<List<User>> GetAll();
    Task<User> Create(CreateUserDto userDto);
}
