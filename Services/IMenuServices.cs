using Clase6.Models;

namespace Clase6.Services;

public interface IMenuServices
{
    List<Menu> GetMenus();

    void Delete(int id);

    Menu GetById(int id);

    void Create(Menu obj);

    void Update(Menu obj);
}