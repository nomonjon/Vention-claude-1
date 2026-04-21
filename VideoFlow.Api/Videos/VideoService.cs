using Microsoft.EntityFrameworkCore;
using VideoFlow.Api.Data;
using VideoFlow.Api.Users;

namespace VideoFlow.Api.Videos;

public class VideoService(AppDbContext context) : IVideoService
{
    public async Task<VideoDto?> Create(CreateVideoDto videoDto)
    {

        var user = await context.Users.AnyAsync(u => u.Id == videoDto.UserId);

        if (!user)
        {
            return null;
        }

        var video = videoDto.ToEntity();

        context.Videos.Add(video);
        await context.SaveChangesAsync();
        return await context.Videos
            .Where(v => v.Id == video.Id)
            .Select(v => new VideoDto
            {
                Id = v.Id,
                Title = v.Title,
                Description = v.Description,
                CreatedAt = v.CreatedAt,
                AuthorName = v.User.Name
            })
            .FirstOrDefaultAsync();

    }

    public async Task<List<VideoDto>> GetAll()
    {
        return await context.Videos
            .AsNoTracking()
            .Select(v => new VideoDto
            {
                Id = v.Id,
                Title = v.Title,
                Description = v.Description,
                CreatedAt = v.CreatedAt,
                AuthorName = v.User.Name
            })
            .ToListAsync();
    }

    public async Task<VideoDto?> GetById(int id)
    {
        var video = await context.Videos
            .AsNoTracking()
            .Include(v => v.User)
            .FirstOrDefaultAsync(v => v.Id == id);

        return video?.ToDto();
    }
}
