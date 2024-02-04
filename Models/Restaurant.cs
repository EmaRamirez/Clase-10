using System.ComponentModel.DataAnnotations;

namespace Clase6.Models;
public class Restaurant
{

    public Restaurant(string name, string address, string mail, string phone)
    {
        this.Name = name;
        this.Address = address;
        this.Mail = mail;
        this.Phone = phone;
    }
    public Restaurant(string name, string address, string mail, string phone, List<Menu> menus) : this(name, address, mail, phone)
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

    [Display(Name = "Menu")]
    public virtual List<Menu> Menus { get; set; }


}