using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Video.Data.Entities
{
    [Table("Movies")]
    [Microsoft.EntityFrameworkCore.Index(nameof(Id), IsUnique = true)]
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }

    }
}
