using Clase6.Models;

namespace Clase6.ViewModels;

public class MenuDetailViewModels
{
    public MenuDetailViewModels(string name, decimal price, string type, bool Is, int calorias, List<Restaurant> rest)
    {
        this.Name = name;
        this.Price = price;
        this.Type = type;
        this.IsVegetarian = Is;
        this.Calories = calorias;
        this.Restaurants = rest;
    }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Type { get; set; }
    public bool IsVegetarian { get; set; } = false;
    public int Calories { get; set; }
    public List<Restaurant> Restaurants { get; set; }

}