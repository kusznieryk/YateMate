using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Reserva;

public class ListarReservasDeSubalquilerUseCase(IRepositorioReserva repo)
{
    public List<Entidades.Reserva>Ejecutar(int subalquilerId)
    {
        return repo.ListarReservasDeSubalquiler(subalquilerId);
    }
}