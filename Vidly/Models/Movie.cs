using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [StringLength(255)]
        public string Name { get; set; }

        public Genere Genere { get; set; }

        [Required]
        public byte GenereId { get; set; }

        public DateTime ReleaseDate { get; set; }
        
        public DateTime DateAdded { get; set; }

        [Required]
        public byte Stock { get; set; }
    }
}
