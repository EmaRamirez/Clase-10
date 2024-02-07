using Clase6.Data;
using Clase6.Models;
using Clase6.Services;
using Clase6.Utils;
using Clase6.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Clase6.Controllers;

public class MenuController : Controller
{
    private readonly IMenuServices _menuServ;
    public MenuController(IMenuServices menuServ)
    {
        this._menuServ = menuServ;
    }

    public IActionResult Index(string filter)
    {

        var model = new MenuIndexViewModel();
        model.Menus = _menuServ.GetMenus(filter);


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
        _menuServ.Create(Obj);
        return RedirectToAction("Index");
    }
    public IActionResult Detail(int id)
    {
        var filtro = _menuServ.GetById(id);
        var viewModels = new MenuDetailViewModels(filtro.Id, filtro.Name, filtro.Price, (filtro.Type).ToString(), filtro.IsVegetarian, filtro.Calorias, filtro.Restaurants);

        return View(viewModels);
    }

    public IActionResult Delete(int id)
    {
        if (id == null)
        {
            return RedirectToAction("Index");
        }
        _menuServ.Delete(id);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var filtro = _menuServ.GetById(id);
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


        var obj = new Menu(objEdit.Name, objEdit.Price, tipo, objEdit.IsVegetarian, objEdit.Calorias);
        _menuServ.Update(objEdit.Id, obj);
        return RedirectToAction("Index");

    }
}