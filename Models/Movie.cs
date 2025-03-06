using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; } // Primary Key

        [ForeignKey("Category")]
        public int? CategoryId { get; set; } // Foreign Key (Nullable to prevent conflicts)

        public virtual Category? Category { get; set; } // Navigation Property

        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        
        public string? Director { get; set; } 
        
        public string? Rating { get; set; }
        [Required]
        public bool Edited { get; set; }

        public string? LentTo { get; set; } // Nullable
        [Required]
        public bool CopiedToPlex { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}