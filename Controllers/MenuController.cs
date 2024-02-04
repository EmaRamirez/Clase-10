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
        var model = new MenuIndexViewModel();
        model.Menus = query.ToList();


        return View(model);
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult OnPostCreate(MenuCreateViewModel ObjCreate)
    {

        if (!ModelState.IsValid)
        {
            return RedirectToAction("Create");
        }

        var Obj = new Menu(ObjCreate.Name, ObjCreate.Price, ObjCreate.Type, ObjCreate.IsVegetarian, ObjCreate.Calorias);
        _context.Menu.Add(Obj);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult Detail(int id)
    {
        var filtro = _context.Menu.Include(x => x.Restaurants).FirstOrDefault(x => x.Id == id);

        
        var viewModels = new MenuDetailViewModels(filtro.Id,filtro.Name, filtro.Price, (filtro.Type).ToString(), filtro.IsVegetarian, filtro.Calorias, filtro.Restaurants);

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
        var model = new MenuDetailViewModels(filtro.Id, filtro.Name, filtro.Price, (filtro.Type).ToString(), filtro.IsVegetarian, filtro.Calorias);

        return View(model);
    }

    public IActionResult OnPostEdit(MenuDetailViewModels objEdit)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Edit");
        }
        var tipo = new MenuType();
        if (objEdit.Type == "0")
        {
            tipo = MenuType.Main;
        }
        else if (objEdit.Type == "1")
        {
            tipo = MenuType.Dessert;
        }
        else
        {
            tipo = MenuType.Entree;
        };

        var borrar = _context.Menu.First(x => x.Id == objEdit.Id);
        _context.Menu.Remove(borrar);
        var obj = new Menu(objEdit.Name, objEdit.Price, tipo, objEdit.IsVegetarian, objEdit.Calorias);
        _context.Menu.Add(obj);
        _context.SaveChanges();
        return RedirectToAction("Index");

    }
}