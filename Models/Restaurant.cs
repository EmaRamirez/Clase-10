using System.ComponentModel.DataAnnotations;

namespace Clase6.Models;
public class Restaurant
{
    public int Id { get; set; }
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    [Display(Name = "Direccion")]
    public string Address { get; set; }
    [Display(Name = "Correo")]
    public string Mail { get; set; }
    [Display(Name = "Telefono")]
    public string Phone { get; set; }
    [Display(Name = "Nro Menu")]
    public int menuId { get; set; }

    //Carga peresosa, solo me trae la informacion si yo se lo pido
    public virtual Menu Menu { get; set; }


}