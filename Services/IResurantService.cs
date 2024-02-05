using Clase6.Models;


namespace Clase6.Services;
public interface IRestaurantService
{
    void Create(Restaurant obj);

    List<Restaurant> GetAll();

    Restaurant GetById(int id);

    void Update(Restaurant obj);

    void Delete(int id);



}