using VideoFlow.Api.Models;

namespace VideoFlow.Api.Dtos;

public class CreateUserDto
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;

}