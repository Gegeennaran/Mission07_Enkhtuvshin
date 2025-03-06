using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; } //primary key
    
    [Required]
    
    public string CategoryName { get; set; } =String.Empty; 
    
    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}