using Gallery.DTO.Album;

namespace Gallery.Services;

public interface IAlbumService
{
    Task<IEnumerable<GetAlbumDto>> GetAlbumsAsync();
    Task<GetAlbumDto> GetAlbumByIdAsync(int id);
    Task<GetAlbumDto> AddAlbumAsync(AddAlbumDto addAlbumDto);
    Task DeleteAlbumAsync(int id);
    Task UpdateAlbumAsync(int id, AddAlbumDto addAlbumDto);
}