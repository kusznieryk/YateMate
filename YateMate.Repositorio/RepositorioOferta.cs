using System.Security.AccessControl;
using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;
namespace YateMate.Repositorio;

public class RepositorioOferta : IRepositorioOferta
{
    public List<Publicacion> ListarTruequesDisponibles()
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Publicaciones.ToList();
        }
    }
}