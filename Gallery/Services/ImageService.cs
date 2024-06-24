using AutoMapper;
using Gallery.DTO.Image;
using Gallery.Models;
using Gallery.Repositories;

namespace Gallery.Services;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;
    private readonly IAlbumRepository _albumRepository;
    private readonly IMapper _mapper;
    private readonly IClassifierService _classifierService;

    public ImageService(IImageRepository imageRepository, IMapper mapper, IClassifierService classifierService, IAlbumRepository albumRepository)
    {
        _imageRepository = imageRepository;
        _mapper = mapper;
        _classifierService = classifierService;
        _albumRepository = albumRepository;
    }

    public async Task<IEnumerable<GetImageDto>> GetImagesAsync()
    {
        var images = await _imageRepository.GetImagesAsync();
        return _mapper.Map<IEnumerable<GetImageDto>>(images);
    }

    public async Task<GetImageDto> GetImageByIdAsync(int id)
    {
        var image = await _imageRepository.GetImageByIdAsync(id);
        return _mapper.Map<GetImageDto>(image);
    }

    public async Task<GetImageDto> AddImageAsync(AddImageDto addImageDto)
    {
        var image = _mapper.Map<Image>(addImageDto);
        image.Album = await _albumRepository.GetAlbumByIdAsync(addImageDto.AlbumId);
        image.Category = await _classifierService.GetImageClass(image.ImageBytes);
        await _imageRepository.AddImageAsync(image);
        return _mapper.Map<GetImageDto>(image);
    }

    public async Task DeleteImageAsync(int id)
    {
        await _imageRepository.DeleteImageAsync(id);
    }

    public async Task UpdateImageAsync(int id, AddImageDto addImageDto)
    {
        var image = _mapper.Map<Image>(addImageDto);
        await _imageRepository.UpdateImageAsync(image);
    }

    public async Task<IEnumerable<GetImageDto>> GetImagesByAlbumIdAsync(int id)
    {
        return _mapper.Map<IEnumerable<GetImageDto>>(await _imageRepository.GetImageByAlbumIdAsync(id));
    }
}