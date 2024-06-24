using Gallery.DTO.Album;

namespace Gallery.DTO.Image;

public class GetImageDto
{
    public int ImageId { get; set; }
    public Byte[] ImageBytes { get; set; } = null!;
    public string Name { get; set; } = null!;
    public GetAlbumDto Album { get; set; } = null!;
    public string Category { get; set; } = null!;
}