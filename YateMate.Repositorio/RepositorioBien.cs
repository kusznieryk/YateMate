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
            var duenio = context.ApplicationUsers.FirstOrDefault(a => a.Id == bien.UsuarioId);
            if (duenio != null)
            {
                duenio.Bienes?.Add(bien);
                context.Add(bien);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("No se encontro a un usuario con ese ID");
            }
        }
    }

    public Bien? ObtenerBien(int id)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Bienes.FirstOrDefault(b => b.Id == id);
        }
    }

    public bool TieneOfertaAceptada(int bienId)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Ofertas.Any(o => o.BienId == bienId && o.Aceptada);
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
            bien.EstaEliminado = true;
            context.SaveChanges();
        }
    }

    public List<Bien> ListarBienesDe(string id)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Bienes.Where(b => b.UsuarioId == id).ToList();
        }
    }
}