using Microsoft.EntityFrameworkCore;
using Clase6.Models;

namespace Clase6.Data;

public class MenuContext : DbContext
{
    public MenuContext(DbContextOptions<MenuContext> options) : base(options)
    {

    }

    public DbSet<Menu> Menu { get; set; }

    public DbSet<Restaurant> Restaurant { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Menu>()
        .HasMany(p => p.Restaurants)
        .WithOne(p => p.Menu)
        .HasForeignKey(x => x.menuId);
    }
}