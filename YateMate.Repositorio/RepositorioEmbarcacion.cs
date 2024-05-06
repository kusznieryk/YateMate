using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Repositorio;

public class RepositorioEmbarcacion:IRepositorioEmbarcacion
{
    public List<Embarcacion> ObtenerEmbarcaciones()
    {
        throw new NotImplementedException();
    }

    public List<Embarcacion> ObtenerEmbarcacionesDe(int idCliente)
    {
        throw new NotImplementedException();
    }

    public Embarcacion ObtenerEmbarcacion(int idCliente)
    {
        throw new NotImplementedException();
    }

    public bool EliminarEmbarcacion(int idEmbarcacion)
    {
        using ( var context = ApplicationDbContext.CrearContexto())
        {
            var embarcacion = context.Embarcaciones.FirstOrDefault((emb => emb.Id == idEmbarcacion));
            if (embarcacion != null)
            {
                context.Remove(embarcacion);
                return true;
            }
        }

        return false;
    }
}