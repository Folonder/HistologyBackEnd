using Gallery.Data;
using Gallery.Exceptions;
using Gallery.Models;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Repositories;

public class ImageRepository : IImageRepository
{
    private readonly GalleryContext _context;

    public ImageRepository(GalleryContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Image>> GetImagesAsync()
    {
        return await _context.Images.Include(o => o.Album).ToListAsync();
    }

    public async Task<Image> GetImageByIdAsync(int id)
    {
        return await _context.Images.Include(o => o.Album).FirstOrDefaultAsync(o => o.ImageId == id) ??
               throw new NotFoundException($"Image with id: {id} is not found");
    }

    public async Task AddImageAsync(Image image)
    {
        await _context.Images.AddAsync(image);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteImageAsync(int id)
    {
        var image = await GetImageByIdAsync(id);
        _context.Remove(id);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateImageAsync(Image image)
    {
        _context.Images.Update(image);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Image>> GetImageByAlbumIdAsync(int id)
    {
        return await _context.Images.Where(i => i.Album.AlbumId == id).ToListAsync();
    }
}