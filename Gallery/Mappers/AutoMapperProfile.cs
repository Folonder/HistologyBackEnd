using AutoMapper;
using Gallery.DTO.Album;
using Gallery.DTO.Image;
using Gallery.Extensions;
using Gallery.Models;

namespace Gallery.Mappers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddImageDto, Image>();
        CreateMap<Image, GetImageDto>();
        CreateMap<AddAlbumDto, Album>();
        CreateMap<Album, GetAlbumDto>();
        CreateMap<PostImageDto, AddImageDto>()
            .ForMember(dest => dest.ImageBytes, opt => opt.MapFrom(src => FormFileToByteArray(src.File)));

    }
    
    private byte[] FormFileToByteArray(IFormFile formFile)
    {
        using (var memoryStream = new MemoryStream())
        {
            formFile.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}