using System.ComponentModel.DataAnnotations;
using Clase6.Models;
namespace Clase6.ViewModels;

public class RestaurantDetailViewModel
{
    public RestaurantDetailViewModel(string name, string address, string mail, string phone)
    {
        this.Name = name;
        this.Address = address;
        this.Mail = mail;
        this.Phone = phone;
    }
    public RestaurantDetailViewModel(string name, string address, string mail, string phone, List<Menu> menus) : this(name, address, mail, phone)
    {
        this.Menus = menus;
    }
    
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    [Display(Name = "Direccion")]
    public string Address { get; set; }
    [Display(Name = "Correo")]
    public string Mail { get; set; }
    [Display(Name = "Telefono")]
    public string Phone { get; set; }

    [Display(Name = "Carta")]
    public virtual List<Menu> Menus { get; set; }
}