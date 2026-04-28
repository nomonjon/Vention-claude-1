using VideoFlow.Api.Common;

namespace VideoFlow.Api.Videos;

public interface IVideoService
{
    Task<VideoDto?> GetById(int id);
    Task<List<VideoDto>> GetAll();
    Task<Result<VideoDto>> Create(CreateVideoDto videoDto);
    Task<List<VideoDto>?> GetByUserId(int userId);
}
