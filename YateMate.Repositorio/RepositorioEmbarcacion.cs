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
            return context.Embarcaciones.Where(embarcacion => embarcacion.ClienteId.Equals(clienteId)).ToList();
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

    public Embarcacion ObtenerEmbarcacion(int embarcacionId)
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

    public void EliminarEmbarcacion(int embarcacionId)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            var embarcacionAEliminar = context.Embarcaciones.FirstOrDefault((emb => emb.Id == embarcacionId));
            if (embarcacionAEliminar != null)
            {
                embarcacionAEliminar.EstaEliminado = true;
                //context.Remove(embarcacionAEliminar); Para hard delete
                context.SaveChanges();
            }
        }
    }
}