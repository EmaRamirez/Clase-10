using Clase6.Data;
using Clase6.Models;
using Clase6.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class RestaurantController : Controller
{

    private readonly MenuContext _context;
    public RestaurantController(MenuContext context)
    {
        this._context = context;
    }


    public IActionResult Index()
    {
        var listado = _context.Restaurant.ToList();
        var model = new RestaurantIndexViewModel();

        model.restaurants = listado;

        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        //ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Name");
        ViewData["MenuId"] = new SelectList(_context.Menu.ToList(), "Id", "Name");
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
        var menus = _context.Menu.Where(x => restaurantCreate.MenuIds.Contains(x.Id)).ToList();
        var restaurant = new Restaurant(restaurantCreate.Name, restaurantCreate.Address, restaurantCreate.Mail, restaurantCreate.Phone, menus);

        _context.Restaurant.Add(restaurant);
        _context.SaveChanges();


        return RedirectToAction("Index");
    }
}