

using Clase6.Models;
using Clase6.Services;
using Clase6.Data;
using Microsoft.EntityFrameworkCore;


namespace Clase6.Services;

public class RestaurantServices : IRestaurantService
{
    private readonly MenuContext _context;

    public RestaurantServices(MenuContext context)
    {
        this._context = context;
    }

    public void Create(Restaurant obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var restaurante = GetById(id);
        _context.Restaurant.Remove(restaurante);
    }

    public List<Restaurant> GetAll()
    {
        return _context.Restaurant.Include(x => x.Menus).ToList();
    }

    public Restaurant GetById(int id)
    {
        return _context.Restaurant.Include(x => x.Menus).FirstOrDefault(x => x.Id == id);
    }

    public void Update(Restaurant obj)
    {
        throw new NotImplementedException();
    }
}