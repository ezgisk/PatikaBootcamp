using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Data.Entities
{
    [Table("Games")]
    [Microsoft.EntityFrameworkCore.Index(nameof(Id), IsUnique =true)]
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Platform { get; set; }
        public decimal Rating { get; set; }
    }
}
