using Clase6.Models;


namespace Clase6.Services;
public interface IRestaurantService
{
    void Create(Restaurant obj);

    List<Restaurant> GetAll();

    Restaurant GetById(int id);

    void Update(int id,Restaurant obj);

    void Delete(int id);



}