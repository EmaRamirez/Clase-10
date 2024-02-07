using System.ComponentModel.DataAnnotations;
using Clase6.Models;
namespace Clase6.ViewModels;

public class RestaurantEditViewModel
{
    public RestaurantEditViewModel(int id, string name, string address, string mail, string phone)
    {
        this.Id = id;
        this.Name = name;
        this.Address = address;
        this.Mail = mail;
        this.Phone = phone;

    }
    public RestaurantEditViewModel(int id, string name, string address, string mail, string phone, List<Menu> menus) : this(id, name, address, mail, phone)
    {
        this.Menus = menus;
    }

    public int Id { get; set; }

    [Display(Name = "Nombre")]
    public string Name { get; set; }
    [Display(Name = "Direccion")]
    public string Address { get; set; }
    [Display(Name = "Correo")]
    public string Mail { get; set; }
    [Display(Name = "Telefono")]
    public string Phone { get; set; }

    [Display(Name = "Carta")]
    public virtual List<Menu> Menus { get; set; } = new List<Menu>();
}