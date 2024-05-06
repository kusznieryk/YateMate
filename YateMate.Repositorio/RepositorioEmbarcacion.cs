using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.Entidades;

namespace YateMate.Repositorio;

public class RepositorioEmbarcacion : IRepositorioEmbarcacion
{
    public void AgregarEmbarcacion(Embarcacion embarcacion)
    {
        (using var context = new ApplicationDbContext()) //poner el metodo que hizo edu
        {
            context.Add(embarcacion);
            context.SaveChanges;
        }
    }

    public List<Embarcacion> ListarEmbarcacionesDe(int id)
    {
        (using var context = new ApplicationDbContext())
        {
            return context.Embarcacion.Where(embarcacion => embarcacion.Id == id).ToList();
        }
    }

    public void ModificarEmbarcacion(Embarcacion embarcacion)
    {
        (using var context = new ApplicationDbContext())
        {
            var embarcacionVieja = context.Embarcacion.FirstOrDefault(e => e.Id == embarcacion.Id);
            embarcacionVieja.Nombre = embarcacion.Nombre;
            embarcacionVieja.Eslora = embarcacion.Eslora;
            embarcacionVieja.Calado = embarcacion.Calado;
            context.SaveChanges();
        }
    }
}