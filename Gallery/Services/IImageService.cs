using Gallery.DTO.Image;

namespace Gallery.Services;

public interface IImageService
{
    Task<IEnumerable<GetImageDto>> GetImagesAsync();
    Task<GetImageDto> GetImageByIdAsync(int id);
    Task<GetImageDto> AddImageAsync(AddImageDto addImageDto);
    Task DeleteImageAsync(int id);
    Task UpdateImageAsync(int id, AddImageDto addImageDto);
    Task<IEnumerable<GetImageDto>> GetImagesByAlbumIdAsync(int id);
}