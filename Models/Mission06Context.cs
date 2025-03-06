using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class Mission06Context : DbContext
{
    public Mission06Context(DbContextOptions<Mission06Context> options) : base(options) //constructor
    {
    }
    
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Category)
            .WithMany(c => c.Movies)
            .HasForeignKey(m => m.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    
}