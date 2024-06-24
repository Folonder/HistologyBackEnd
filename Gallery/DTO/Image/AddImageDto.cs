namespace Gallery.DTO.Image;

public class AddImageDto
{
    public byte[] ImageBytes { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int AlbumId { get; set; }
}