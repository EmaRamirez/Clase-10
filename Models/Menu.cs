using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Clase6.Utils;

namespace Clase6.Models;

public class Menu
{

    public Menu(string Name, decimal Price, MenuType Type, bool IsVegetarian, int Calorias)
    {
        this.Name = Name;
        this.Price = Price;
        this.Type = Type;
        this.IsVegetarian = IsVegetarian;
        this.Calorias = Calorias;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    [Display(Name = "Precio")]
    public decimal Price { get; set; }
    [Display(Name = "Tipo")]
    public MenuType Type { get; set; } 
    [Display(Name = "Es vegetariano")]
    public bool IsVegetarian { get; set; } = false;
    [Display(Name = "Calorias")]
    public int Calorias { get; set; }

    public virtual List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();

}