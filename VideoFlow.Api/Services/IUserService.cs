using VideoFlow.Api.Dtos;
using VideoFlow.Api.Models;

namespace VideoFlow.Api.Services;

public interface IUserService
{
    User? GetById(int id);
    List<User> GetAll();
    User Create(CreateUserDto userDto);
}
