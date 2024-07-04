using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.UseCases.Reserva;

namespace YateMate.Repositorio;

public class RepositorioReserva : IRepositorioReserva
{
    public void HacerReserva(Reserva reserva)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            context.Add(reserva);
            context.SaveChanges();
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

    public List<Reserva> ListarReservas()
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Reservas.ToList();
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
    
    public async Task<List<(DateTime Start, DateTime End)>> ObtenerFechasOcupadas(int subalquilerId)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            var reservas = await context.Reservas
                .Where(r => r.SubalquilerId == subalquilerId)
                .Select(r => new { r.FechaInicio, r.FechaFin })
                .ToListAsync();

            return reservas.Select(r => (r.FechaInicio, r.FechaFin)).ToList();
        }
    }

    public List<Reserva> ListarReservasDeSubalquiler(int subalquilerId)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Reservas.Where(r => r.SubalquilerId.Equals(subalquilerId)).ToList();
        }
    }

    public List<Reserva> ObtenerReservasDeSubalquiler(int id)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Reservas.Where(r => r.SubalquilerId == id).ToList();
        }
    }
}