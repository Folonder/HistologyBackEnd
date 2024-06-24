using Gallery.Models;

namespace Gallery.Repositories;

public interface IAlbumRepository
{
    Task<IEnumerable<Album>> GetAlbumsAsync();
    Task<Album> GetAlbumByIdAsync(int id);
    Task AddAlbumAsync(Album album);
    Task DeleteAlbumAsync(int id);
    Task UpdateAlbumAsync(Album album);
}