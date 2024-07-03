using Microsoft.VisualBasic;
using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Repositorio;

public class RepositorioReserva : IRepositorioReserva
{
    public void HacerReserva(Reserva reserva, Subalquiler? subalquiler)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            if (subalquiler != null)
            {
                if (CheckearDisponibilidad(reserva, subalquiler))
                {
                    context.Add(reserva);
                    // subalquiler.Reservas.Add(reserva);
                    context.SaveChanges();
                }
            }
        }
    }

    public void CancelarReserva(int id)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            var reserva = context.Reservas.FirstOrDefault(r => r.Id == id);
            if (reserva != null)
            {
                context.Remove(reserva);
                context.SaveChanges();
            }
        }
    }

    public void ModificarReserva(Reserva reserva)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            var vieja = context.Reservas.FirstOrDefault(r => r.Id == reserva.Id);
            if(vieja == null) return;
            vieja.FechaInicio = reserva.FechaInicio;
            vieja.FechaFin = reserva.FechaFin;
            context.SaveChanges();
        }
    }

    public List<Reserva> ListarReservasDe(string usuarioId)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Reservas.Where(r => r.UsuarioId.Equals(usuarioId)).ToList();
        }
    }

    public Reserva? ObtenerReserva(int id)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Reservas.FirstOrDefault(r => r.Id == id);
        }
    }

    public ApplicationUser? ObtenerDuenioReserva(string id)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.ApplicationUsers.FirstOrDefault(a => a.Id == id);
        }
    }

    public List<Reserva> ListarReservasDeSubalquiler(int subalquilerId)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Reservas.Where(r => r.SubalquilerId == subalquilerId).ToList();
        }
    }


    private bool CheckearDisponibilidad(Reserva reserva, Subalquiler? subalquiler)
    {
        if (subalquiler == null)
        {
            return false;
        }
        var reservasSubalquiler = subalquiler.Reservas;
        if (reservasSubalquiler == null || !reservasSubalquiler.Any())
        {
            return true; // Está disponible si no hay reservas existentes
        }
        return !reservasSubalquiler.Any(r => (r.FechaInicio >= reserva.FechaInicio && r.FechaInicio <= reserva.FechaFin) 
                                            || (r.FechaFin >= reserva.FechaInicio && r.FechaFin <= reserva.FechaFin));
    }
}