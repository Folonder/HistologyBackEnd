using Gallery.DTO.Album;
using Gallery.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gallery.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlbumController : ControllerBase
{
    private readonly IAlbumService _albumService;
    private readonly ILogger<AlbumController> _logger;

    public AlbumController(IAlbumService albumService, ILogger<AlbumController> logger)
    {
        _albumService = albumService;
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetAlbumDto>>> GetAlbums()
    {
        _logger.LogInformation($"Getting all albums");
        var albums = await _albumService.GetAlbumsAsync();
        _logger.LogInformation($"Got albums: {string.Join(", ", albums)}");
        return Ok(albums);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetAlbumDto>> GetAlbum(int id)
    {
        _logger.LogInformation($"Getting album with id: {id}");
        var album = await _albumService.GetAlbumByIdAsync(id);
        _logger.LogInformation($"Got album with id: {album.AlbumId}");
        return Ok(album);
    }

    [HttpPost]
    public async Task<ActionResult<GetAlbumDto>> PostAlbum(AddAlbumDto addAlbumDto)
    {
        _logger.LogInformation($"Adding album: {addAlbumDto}");
        var getAlbumDto = await _albumService.AddAlbumAsync(addAlbumDto);
        _logger.LogInformation($"Added album: {getAlbumDto}");
        return CreatedAtAction(nameof(GetAlbum), new { id = getAlbumDto.AlbumId }, getAlbumDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAlbum(int id)
    {
        _logger.LogInformation($"Deleting album with id: {id}");
        await _albumService.DeleteAlbumAsync(id);
        _logger.LogInformation($"Deleted album with id: {id}");
        return Ok();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAlbum(int id, [FromBody] AddAlbumDto updateAlbumDto)
    {
        _logger.LogInformation($"Updating album: {updateAlbumDto} with id: {id}");
        await _albumService.UpdateAlbumAsync(id, updateAlbumDto);
        _logger.LogInformation($"Updated album with id: {id}");
        return Ok();
    }
}