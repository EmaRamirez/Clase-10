

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
        var model = new MenuViewModel();

        model.Restaurantes = listado;

        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewData["MenuId"] = new SelectList(_context.Menu, "Id", "Name");
        return View();
    }

    [HttpPost]
    public IActionResult Create(Restaurant restaurant)
    {
        ModelState.Remove("Menu");

        if (!ModelState.IsValid)
        {
            return RedirectToAction("Create");
        }
        _context.Restaurant.Add(restaurant);
        _context.SaveChanges();


        return RedirectToAction("Index");
    }
}