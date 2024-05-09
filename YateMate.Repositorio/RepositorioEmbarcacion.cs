using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Repositorio;

public class RepositorioEmbarcacion:IRepositorioEmbarcacion
{
    public void AgregarEmbarcacion(Embarcacion embarcacion)
    {
        using ( var context = ApplicationDbContext.CrearContexto())        
        {
            context.Add(embarcacion);
            context.SaveChanges();
        }
    }

    public List<Embarcacion> ObtenerEmbarcacionesDe(string clienteId)
    {
        using ( var context = ApplicationDbContext.CrearContexto())        {
            return context.Embarcaciones.Where(embarcacion => embarcacion.ClienteId.Equals(clienteId) ).ToList();
        }
    }

    public void ModificarEmbarcacion(Embarcacion embarcacion)
    {
        using ( var context = ApplicationDbContext.CrearContexto())        {
            var embarcacionVieja = context.Embarcaciones.FirstOrDefault(e => e.Id == embarcacion.Id);
            embarcacionVieja.Nombre = embarcacion.Nombre;
            embarcacionVieja.Eslora = embarcacion.Eslora;
            embarcacionVieja.Calado = embarcacion.Calado;
            context.SaveChanges();
        }
    }
    public List<Embarcacion> ObtenerEmbarcaciones()
    {
        throw new NotImplementedException();
    }

    public List<Embarcacion> ObtenerEmbarcacionesDe(int clienteId)
    {
        using var context = ApplicationDbContext.CrearContexto();
        var embarcaciones = context.Embarcaciones.Where(embarcacion => embarcacion.ClienteId.Equals(clienteId)).ToList();
        return embarcaciones;
    }

    public Embarcacion ObtenerEmbarcacion(int embarcacionId)
    {
        throw new NotImplementedException();
    }

    public bool EliminarEmbarcacion(int embarcacionId)
    {
        using ( var context = ApplicationDbContext.CrearContexto())
        {
            var embarcacion = context.Embarcaciones.FirstOrDefault((emb => emb.Id == embarcacionId));
            if (embarcacion != null)
            {
                context.Remove(embarcacion);
                return true;
            }
        }

        return false;
    }
}