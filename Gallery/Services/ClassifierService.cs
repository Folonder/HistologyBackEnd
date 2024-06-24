using Microsoft.Extensions.Options;
using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace Gallery.Services;

public class ClassifierService : IClassifierService
{
    private readonly string _url;
    
    public ClassifierService(IOptions<ClassifierServiceOptions> options)
    {
        _url = options.Value.Url;
    }

    public async Task<string> GetImageClass(byte[] imageBytes)
    {
        using var client = new HttpClient();
        using var content = new MultipartFormDataContent();
        var imageContent = new ByteArrayContent(imageBytes);
        imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

        content.Add(imageContent, "image", "image.jpg");

        var response = await client.PostAsync(_url, content);

        return await response.Content.ReadAsStringAsync();
    }
}