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
        using ( var context = ApplicationDbContext.CrearContexto()){
            return context.Embarcaciones.Where(embarcacion => embarcacion.ClienteId.Equals(clienteId) && !embarcacion.EstaEliminado).ToList();
        }
    }

    public void ModificarEmbarcacion(Embarcacion embarcacion)
    {
        using ( var context = ApplicationDbContext.CrearContexto())        {
            var embarcacionVieja = context.Embarcaciones.FirstOrDefault(e => e.Id == embarcacion.Id);
            embarcacionVieja!.Nombre = embarcacion.Nombre;
            embarcacionVieja.Eslora = embarcacion.Eslora;
            embarcacionVieja.Calado = embarcacion.Calado;
            embarcacionVieja.Matricula = embarcacion.Matricula;
            embarcacionVieja.Manga = embarcacion.Manga;
            embarcacionVieja.Bandera = embarcacion.Bandera;
            //TODO: descomentar esto
            context.SaveChanges();
        }
    }
    public List<Embarcacion> ObtenerEmbarcaciones()
    {
        using var context = ApplicationDbContext.CrearContexto();
        var embarcaciones = context.Embarcaciones.ToList();
        return embarcaciones;
    }

    public List<Embarcacion> ObtenerEmbarcacionesDe(int clienteId)
    {
        using var context = ApplicationDbContext.CrearContexto();
        var embarcaciones = context.Embarcaciones.Where(embarcacion => embarcacion.ClienteId.Equals(clienteId)).ToList();
        return embarcaciones;
    }

    public Embarcacion? ObtenerEmbarcacion(int embarcacionId)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Embarcaciones.FirstOrDefault(e => e.Id == embarcacionId);
        }
    }

   
    public Embarcacion? ObtenerEmbarcacionPorMatricula(string matricula)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Embarcaciones.FirstOrDefault(e => e.Matricula == matricula);
        }
    }

    public void EliminarEmbarcacion(int embarcacionId, bool tienePublicacion)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            var embarcacionAEliminar = context.Embarcaciones.FirstOrDefault((emb => emb.Id == embarcacionId));
            if (embarcacionAEliminar != null)
            {
                if (tienePublicacion)
                {
                    embarcacionAEliminar.EstaEliminado = true;
                }
                else
                    context.Remove(embarcacionAEliminar);
            }
            context.SaveChanges();
        }
    }

    public bool tienePublicacion(int id)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Publicaciones.Any(pub => pub.EmbarcacionId == id);
        }
    }
}