using Gallery.Models;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Data;

public class GalleryContext : DbContext
{
    public GalleryContext(DbContextOptions<GalleryContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Image> Images { get; set; }
    public DbSet<Album> Albums { get; set; }
}