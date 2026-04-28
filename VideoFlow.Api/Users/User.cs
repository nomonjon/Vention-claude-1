using VideoFlow.Api.Videos;

namespace VideoFlow.Api.Users;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<Video> Videos { get; set; } = [];
}
