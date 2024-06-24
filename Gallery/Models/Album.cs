using System.ComponentModel.DataAnnotations.Schema;

namespace Gallery.Models;

[Table("albums")]
public class Album
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("album_id")]
    public int AlbumId { get; set; }

    [Column("name")] 
    public string Name { get; set; } = null!;
}