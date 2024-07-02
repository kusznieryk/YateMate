using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.Interfaces;

public interface IRepositorioReserva
{
    void HacerReserva(Reserva reserva);
    void CancelarReserva(int id);
    void ModificarReserva(Reserva reserva);
    List<Reserva> ListarReservasDe(string usuarioId);
    Reserva? ObtenerReserva(int id);
    ApplicationUser? ObtenerDuenioReserva(string id);
}