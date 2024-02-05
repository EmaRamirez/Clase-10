using Clase6.Data;
using Clase6.Models;
using Clase6.Services;
using Clase6.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class RestaurantController : Controller
{

    private IRestaurantService _RestServ; // directamente se lo mandamos a la interface para que trabaje con ese, ya que si se hace testing es mas facil poder trabajarlo directo de la interface
    public RestaurantController(IRestaurantService serv)
    {
        this._RestServ = serv;
    }


    public IActionResult Index()
    {
        var listado = _RestServ.GetAll();
        var model = new RestaurantIndexViewModel();
        model.restaurants = listado;

        return View(model);
    }

    public IActionResult Details(int id)
    {
        var restaurant = _RestServ.GetById(id);

        var detail = new RestaurantDetailViewModel(restaurant.Name, restaurant.Address, restaurant.Mail, restaurant.Phone, restaurant.Menus);
        return View(detail);

    }

    [HttpGet]
    public IActionResult Create()
    {
        //ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Name");
        ViewData["MenuId"] = new SelectList(new List<Menu>(), "Id", "Name");// agregar el service de menu
        return View();
    }

    //CHECKEADO - FUNCIONA
    [HttpPost]
    public IActionResult Create(RestaurantCreateViewModel restaurantCreate)
    {

        if (!ModelState.IsValid)
        {
            return RedirectToAction("Create");
        }

        //FALTA AGREGAR EL SERVICIO DE MENU PARA AGREGAR LOS PLATOS QUE TIENE EL RESTAURANTE EN CREAR
        var restaurant = new Restaurant(restaurantCreate.Name, restaurantCreate.Address, restaurantCreate.Mail, restaurantCreate.Phone, menus);

        _RestServ.Create(restaurant);



        return RedirectToAction("Index");
    }
}

