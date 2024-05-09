using System.Reflection.Metadata.Ecma335;
using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;
namespace YateMate.Repositorio;

public class RepositorioBien : IRepositorioBien
{
    public void AgregarBien(Bien bien)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            context.Add(bien);
            context.SaveChanges();
        }
    }

    public Bien? ObtenerBien(int id)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Bienes.FirstOrDefault(b => b.Id == id);
        }
    }

    public void ModificarBien(Bien bien)
    {
        using (var context =ApplicationDbContext.CrearContexto())
        {
            var bienViejo = context.Bienes.FirstOrDefault(b => b.Id == bien.Id);
            if (bienViejo != null)
            {
                bienViejo.Nombre = bien.Nombre;
                bienViejo.Descripcion = bien.Descripcion;
                bienViejo.Imagen = bien.Imagen;
                context.SaveChanges();
            }
        }
    }

    public void EliminarBien(int id)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            var bien = context.Bienes.FirstOrDefault(b => b.Id == id);
            if (bien != null)
            {
                context.Remove(bien);
                context.SaveChanges();
            }
        }
    }

    public List<Bien> ListarBienesDe(int id)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Bienes.Where(b => b.UsuarioId == id).ToList();
        }
    }
}