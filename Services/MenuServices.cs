using Clase6.Data;
using Clase6.Models;
using Microsoft.EntityFrameworkCore;

namespace Clase6.Services;

public class MenuServices : IMenuServices
{

    private readonly MenuContext _context;

    public MenuServices(MenuContext context)
    {
        this._context = context;
    }
    public void Create(Menu obj)
    {
        _context.Menu.Add(obj);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var delete = GetById(id);
        _context.Menu.Remove(delete);
        _context.SaveChanges();
    }

    public Menu GetById(int id)
    {
        return _context.Menu.Include(x => x.Restaurants).FirstOrDefault(x => x.Id == id);
    }

    public List<Menu> GetMenus()
    {
        return _context.Menu.Include(x => x.Restaurants).ToList();
    }

    public void Update(Menu obj)
    {
        Delete(obj.Id);
        Create(obj);
    }
}