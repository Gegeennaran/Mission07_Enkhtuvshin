using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class Mission06Context : DbContext
{
    public Mission06Context(DbContextOptions<Mission06Context> options) : base(options) //constructor
    {
    }
    
    public DbSet<Application> Applications { get; set; }
}