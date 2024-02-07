using Clase6.Data;
using Clase6.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

    public List<Menu> GetMenus(string filter)
    {
        var query = GetQuery();

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
        }
        return query.Include(x => x.Restaurants).ToList();
    }

    public void Update(int id, Menu obj)
    {
        Delete(id);
        Create(obj);
    }

    private IQueryable<Menu> GetQuery() => from manu in _context.Menu select manu;
}