using Clase6.Models;

namespace Clase6.ViewModels;

public class MenuIndexViewModel
{
    public MenuIndexViewModel()
    {

    }
    public List<Menu> Menus { get; set; } = new List<Menu>();

    public string? NameFilter { get; set; }




}