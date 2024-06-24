using AutoMapper;
using Gallery.DTO.Album;
using Gallery.Models;
using Gallery.Repositories;

namespace Gallery.Services;

public class AlbumService : IAlbumService
{
    private readonly IAlbumRepository _albumRepository;
    private readonly IMapper _mapper;

    public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
    {
        _albumRepository = albumRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<GetAlbumDto>> GetAlbumsAsync()
    {
        var albums = await _albumRepository.GetAlbumsAsync();
        return _mapper.Map<IEnumerable<GetAlbumDto>>(albums);
    }

    public async Task<GetAlbumDto> GetAlbumByIdAsync(int id)
    {
        var album = await _albumRepository.GetAlbumByIdAsync(id);
        return _mapper.Map<GetAlbumDto>(album);
    }

    public async Task<GetAlbumDto> AddAlbumAsync(AddAlbumDto addAlbumDto)
    {
        var album = _mapper.Map<Album>(addAlbumDto);
        await _albumRepository.AddAlbumAsync(album);
        return _mapper.Map<GetAlbumDto>(album);
    }

    public async Task DeleteAlbumAsync(int id)
    {
        await _albumRepository.DeleteAlbumAsync(id);
    }

    public async Task UpdateAlbumAsync(int id, AddAlbumDto addAlbumDto)
    {
        var album = _mapper.Map<Album>(addAlbumDto);
        await _albumRepository.UpdateAlbumAsync(album);
    }
}