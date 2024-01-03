using Clase6.Models;

namespace Clase6.ViewModels;

public class MenuViewModel
{
    public MenuViewModel()
    {

    }
    public List<Menu> Menus { get; set; } = new List<Menu>();

    public string? NameFilter { get; set; }

    public List<Restaurant> Restaurantes { get; set; }


}