using Gallery.Data;
using Gallery.Exceptions;
using Gallery.Models;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Repositories;

public class AlbumRepository : IAlbumRepository
{
    private readonly GalleryContext _context;

    public AlbumRepository(GalleryContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Album>> GetAlbumsAsync()
    {
        return await _context.Albums.ToListAsync();
    }

    public async Task<Album> GetAlbumByIdAsync(int id)
    {
        return await _context.Albums.FindAsync(id) ?? 
               throw new NotFoundException($"Album with id: {id} id not found");
    }

    public async Task AddAlbumAsync(Album album)
    {
        await _context.Albums.AddAsync(album);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAlbumAsync(int id)
    {
        var album = await GetAlbumByIdAsync(id);
        _context.Albums.Remove(album);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAlbumAsync(Album album)
    {
        _context.Albums.Update(album);
        await _context.SaveChangesAsync();
    }
}