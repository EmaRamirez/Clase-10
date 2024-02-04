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
        /*
        FORMAS DE HACER LA RELACION MUCHOS A MUCHOS 
        
        modelBuilder.Entity<Restaurant>()
         .HasMany(x => x.Menus).
         WithMany(x => x.Restaurants).
         UsingEntity(
             "MenuRestaurante",
             l => l.HasOne(typeof(Menu)).WithMany().HasForeignKey("MenuId").HasPrincipalKey(nameof(Menu.Id)),
             k => k.HasOne(typeof(Restaurant)).WithMany().HasForeignKey("RestaurantId").HasPrincipalKey(nameof(Restaurant.Id)),
             m => m.HasKey("MenuId", "RestaurantId")

NO ESPECIFICAMOS EL NOMBRE DE LA TABLA
        modelBuilder.Entity<Restaurant>()
         .HasMany(x => x.Menus)
         .WithMany(x => x.Restaurants);
             );

             */
        //ESPECIFICAMOS EL NOMBRE DE LA TABLA
        modelBuilder.Entity<Menu>()
        .HasMany(x => x.Restaurants)
        .WithMany(p => p.Menus)
        .UsingEntity("MenuRestaurant");


    }

}