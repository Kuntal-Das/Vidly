using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Genere
    {
        [Required]
        public byte Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
    }
}