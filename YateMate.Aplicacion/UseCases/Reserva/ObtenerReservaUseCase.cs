using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Reserva;

public class ObtenerReservaUseCase(IRepositorioReserva repo)
{
    public Entidades.Reserva? Ejecutar(int id)
    {
        return repo.ObtenerReserva(id);
    }
}