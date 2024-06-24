using AutoMapper;
using Gallery.DTO.Image;
using Gallery.Extensions;
using Gallery.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gallery.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;
    private readonly ILogger<ImageController> _logger;
    private readonly IMapper _mapper;

    public ImageController(IImageService imageService, ILogger<ImageController> logger, IMapper mapper)
    {
        _imageService = imageService;
        _logger = logger;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetImageDto>>> GetImages()
    {
        _logger.LogInformation($"Getting all images");
        var images = await _imageService.GetImagesAsync();
        _logger.LogInformation($"Got images: {string.Join(", ", images)}");
        return Ok(images);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetImageDto>> GetImage(int id)
    {
        _logger.LogInformation($"Getting image with id: {id}");
        var image = await _imageService.GetImageByIdAsync(id);
        _logger.LogInformation($"Got image with id: {image.ImageId}");
        return Ok(image);
    }

    [HttpPost]
    public async Task<ActionResult<GetImageDto>> PostImage(PostImageDto postImageDto)
    {
        var addImageDto = _mapper.Map<AddImageDto>(postImageDto);
        _logger.LogInformation($"Adding image: {addImageDto}");
        var getImageDto = await _imageService.AddImageAsync(addImageDto);
        _logger.LogInformation($"Added image: {getImageDto}");
        return CreatedAtAction(nameof(GetImage), new { id = getImageDto.ImageId }, getImageDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteImage(int id)
    {
        _logger.LogInformation($"Deleting image with id: {id}");
        await _imageService.DeleteImageAsync(id);
        _logger.LogInformation($"Deleted image with id: {id}");
        return Ok();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateImage(int id, [FromQuery] string name, [FromQuery] int albumId, IFormFile file)
    {
        var updateImageDto = new AddImageDto() { Name = name, AlbumId = albumId, ImageBytes = await file.ReadFile() };
        _logger.LogInformation($"Updating image: {updateImageDto} with id: {id}");
        await _imageService.UpdateImageAsync(id, updateImageDto);
        _logger.LogInformation($"Updated image with id: {id}");
        return Ok();
    }
}