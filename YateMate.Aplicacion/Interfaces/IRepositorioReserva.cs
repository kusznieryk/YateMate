using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.Interfaces;

public interface IRepositorioReserva
{
    void HacerReserva(Reserva reserva);
    void CancelarReserva(int id);
    void ModificarReserva(Reserva reserva);
    List<Reserva> ListarReservasDe(string usuarioId);
    List<Reserva> ListarReservas();
    List<Reserva> ListarReservasDeSubalquiler(int subalquilerId);
    Reserva? ObtenerReserva(int id);
    ApplicationUser? ObtenerDuenioReserva(string id);
    Task<List<(DateTime Start, DateTime End)>> ObtenerFechasOcupadas(int subalquilerId);
    List<Reserva> ObtenerReservasDeSubalquiler(int id);
 
}