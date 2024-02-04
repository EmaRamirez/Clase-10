using Clase6.Utils;
namespace Clase6.ViewModels;

public class MenuCreateViewModel
{

    public int Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public MenuType Type { get; set; }

    public bool IsVegetarian { get; set; } = false;

    public int Calorias { get; set; }


}