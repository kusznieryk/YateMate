using System.Security.AccessControl;
using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;
namespace YateMate.Repositorio.Data;

public class RepositorioOferta : IRepositorioOferta
{
    public List<Publicacion> ListarTruequesDisponibles()
    {
        using (var context = new ApplicationDbContext())
        {
            return context.Publicaciones.ToList();
        }
    }
}