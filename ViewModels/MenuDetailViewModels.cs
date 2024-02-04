using Clase6.Models;
using NuGet.Protocol.Plugins;

namespace Clase6.ViewModels;

public class MenuDetailViewModels
{
    public MenuDetailViewModels()
    {

    }
    public MenuDetailViewModels(int id)
    {
        this.Id = id;
    }

    public MenuDetailViewModels(int id, string name, decimal price, string type, bool Is, int calorias) : this(id)
    {
        this.Name = name;
        this.Price = price;
        this.Type = type;
        this.IsVegetarian = Is;
        this.Calorias = calorias;

    }
    public MenuDetailViewModels(int id, string name, decimal price, string type, bool Is, int calorias, List<Restaurant> rest) : this(id, name, price, type, Is, calorias)
    {
        this.Restaurants = rest;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Type { get; set; }
    public bool IsVegetarian { get; set; } = false;
    public int Calorias { get; set; }
    public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();

}