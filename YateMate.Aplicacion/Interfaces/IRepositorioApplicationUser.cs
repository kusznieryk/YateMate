using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.Interfaces;

public interface IRepositorioApplicationUser
{
    void EliminarApplicationUser(string id);
    List<ApplicationUser> ObtenerApplicationUsers();
}