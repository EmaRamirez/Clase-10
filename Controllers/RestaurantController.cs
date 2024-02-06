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
    private IMenuServices _menuServ;
    public RestaurantController(IRestaurantService serv, IMenuServices menuServ)
    {
        this._RestServ = serv;
        this._menuServ = menuServ;
    }


    public IActionResult Index()
    {
        var listado = _RestServ.GetAll();
        var model = new RestaurantIndexViewModel();
        model.restaurants = listado;

        return View(model);
    }

    public IActionResult Detail(int id)
    {
        var restaurant = _RestServ.GetById(id);

        var detail = new RestaurantDetailViewModel(restaurant.Name, restaurant.Address, restaurant.Mail, restaurant.Phone, restaurant.Menus);
        return View(detail);

    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewData["MenuId"] = new SelectList(_menuServ.GetMenus(), "Id", "Name");// agregar el service de menu
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
        var menu = new List<Menu>();
        foreach (var item in restaurantCreate.MenuIds)
        {
            menu.Add(_menuServ.GetById(item));
        }
        var restaurant = new Restaurant(restaurantCreate.Name, restaurantCreate.Address, restaurantCreate.Mail, restaurantCreate.Phone, menu);

        _RestServ.Create(restaurant);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var restaurant = _RestServ.GetById(id);

        var detail = new RestaurantDetailViewModel(restaurant.Name, restaurant.Address, restaurant.Mail, restaurant.Phone, restaurant.Menus);
        return View(detail);
    }


    //TO DO: VER EL EDIT QUE FUNCIONE
    [HttpPost]
    public IActionResult Edit(RestaurantDetailViewModel obj)
    {
        var menu = new List<Menu>();
        foreach (var item in obj.Menus)
        {
            menu.Add(_menuServ.GetById(item.Id));
        }
        var restaurant = new Restaurant(obj.Name, obj.Address, obj.Mail, obj.Phone, menu);
        _RestServ.Update(restaurant);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        _RestServ.Delete(id);
        return RedirectToAction("Index");
    }
}

