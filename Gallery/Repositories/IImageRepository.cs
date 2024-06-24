using Gallery.Models;

namespace Gallery.Repositories;

public interface IImageRepository
{
    Task<IEnumerable<Image>> GetImagesAsync();
    Task<Image> GetImageByIdAsync(int id);
    Task AddImageAsync(Image image);
    Task DeleteImageAsync(int id);
    Task UpdateImageAsync(Image image);
    Task<IEnumerable<Image>> GetImageByAlbumIdAsync(int id);
}