namespace Gallery.Services;

public interface IClassifierService
{
    Task<string> GetImageClass(byte[] imageBytes);
}