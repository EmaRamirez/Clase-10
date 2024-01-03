using Clase6.Data;
using Clase6.Models;
using Clase6.Utils;
using Clase6.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Clase6.Controllers;

public class MenuController : Controller
{
    private readonly MenuContext _context;
    public MenuController(MenuContext _Serv)
    {
        this._context = _Serv;
    }

    public IActionResult Index(string NameFilter)
    {
        var query = from menu in _context.Menu select menu;



        if (!string.IsNullOrEmpty(NameFilter))
        {
            query = query.Where(x => x.Name.ToLower().Contains(NameFilter.ToLower()));
        }
        var restaurants = query.Include(x => x.Restaurants).Select(x => x.Restaurants).ToList();
        var model = new MenuViewModel();
        model.Menus = query.ToList();


        return View(model);
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult OnPostCreate(Menu Obj)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Create");
        }
        _context.Menu.Add(Obj);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult Detail(int id)
    {
        var filtro = _context.Menu.Include(x => x.Restaurants).FirstOrDefault(x => x.Id == id);

        //var resta = _context.Restaurant.Where(x => x.menuId == filtro.Id).ToList();
        var viewModels = new MenuDetailViewModels(filtro.Name, filtro.Price, (filtro.Type).ToString(), filtro.IsVegetarian, filtro.Calorias, filtro.Restaurants);

        return View(viewModels);
    }

    public IActionResult Delete(int id)
    {
        if (id == null)
        {
            return RedirectToAction("Index");
        }
        var borrar = _context.Menu.FirstOrDefault(x => x.Id == id);
        _context.Menu.Remove(borrar);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var filtro = _context.Menu.FirstOrDefault(x => x.Id == id);
        return View(filtro);
    }

    public IActionResult OnPostEdit(Menu obj)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Edit");
        }
        var borrar = _context.Menu.First(x => x.Id == obj.Id);
        _context.Menu.Remove(borrar);
        _context.Menu.Add(obj);
        _context.SaveChanges();
        return RedirectToAction("Index");

    }
}