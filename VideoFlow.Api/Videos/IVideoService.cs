namespace VideoFlow.Api.Videos;

public interface IVideoService
{
    Task<VideoDto?> GetById(int id);
    Task<List<VideoDto>> GetAll();
    Task<VideoDto?> Create(CreateVideoDto videoDto);
}
