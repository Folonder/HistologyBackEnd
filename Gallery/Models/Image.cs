using System.ComponentModel.DataAnnotations.Schema;

namespace Gallery.Models;

[Table("images")]
public class Image
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("image_id")]
    public int ImageId { get; set; }
    [Column("image_bytes")]
    public Byte[] ImageBytes { get; set; } = null!;
    [Column("name")] 
    public string Name { get; set; } = null!;
    [Column("category")] 
    public string Category { get; set; } = null!;
    [Column("album_id")]
    public Album Album { get; set; } = null!;
}