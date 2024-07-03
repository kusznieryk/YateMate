using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Reserva;

public class ObtenerReservasDeSubalquilerUseCase(IRepositorioReserva repo)
{
    public List<Entidades.Reserva> Ejecutar(int id)
    {
        return repo.ObtenerReservasDeSubalquiler(id);
    }
}