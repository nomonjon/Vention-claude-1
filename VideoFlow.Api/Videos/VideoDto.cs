namespace VideoFlow.Api.Videos;

public class VideoDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string AuthorName { get; set; } = string.Empty;
}

public class CreateVideoDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int UserId { get; set; }
}

public static class VideoMapper
{
    public static VideoDto ToDto(this Video video)
    {
        return new VideoDto
        {
            Id = video.Id,
            Title = video.Title,
            Description = video.Description,
            CreatedAt = video.CreatedAt,
            AuthorName = video.User?.Name ?? string.Empty
        };
    }

    public static Video ToEntity(this CreateVideoDto videoDto)
    {
        return new Video
        {
            Title = videoDto.Title,
            Description = videoDto.Description,
            UserId = videoDto.UserId
        };
    }
}
