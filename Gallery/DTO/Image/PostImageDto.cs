namespace Gallery.DTO.Image;

public class PostImageDto
{
    public string Name { get; set; } = null!;
    public int AlbumId { get; set; }
    public IFormFile File {get; set; }
}