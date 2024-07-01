using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Reserva;

public class ObtenerDuenioReservaUseCase(IRepositorioReserva repo)
{
    public Entidades.ApplicationUser? Ejecutar(string id)
    {
        return repo.ObtenerDuenioReserva(id);
    }
}