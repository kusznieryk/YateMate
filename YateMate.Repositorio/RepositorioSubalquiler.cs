using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Repositorio;

public class RepositorioSubalquiler : IRepositorioSubalquiler
{
    public List<Subalquiler> ObtenerSubalquileres()
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Subalquileres.ToList();
        }
    }

    public List<Subalquiler> ObtenerSubalquileresDe(string idDuenio)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Subalquileres.Where(subalquiler => subalquiler.IdDuenio == idDuenio).ToList();
        }
    }

    public List<Subalquiler> ObtenerSubalquileresEntre(DateTime fechaI, DateTime fechaF)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Subalquileres.Where(subalquiler => subalquiler.FechaInicio >=fechaI && subalquiler.FechaFin <= fechaF).ToList();
        }
    }

    public List<Subalquiler> ObtenerSubalquileresVigentes()
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Subalquileres.Where(subalquiler => subalquiler.FechaFin >= DateTime.Today).ToList();
        }
    }

    public List<Subalquiler> ObtenerSubalquileresDeLaAmarra(string idAmarra)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Subalquileres.Where(subalquiler => subalquiler.IdAmarra==idAmarra).ToList();
        }
    }
}