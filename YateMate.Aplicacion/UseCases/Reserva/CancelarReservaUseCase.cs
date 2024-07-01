using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Reserva;

public class CancelarReservaUseCase
{
    private readonly IRepositorioReserva _repo;

    public CancelarReservaUseCase(IRepositorioReserva repo)
    {
        this._repo = repo;
    }

    public void Ejecutar(int id)
    {
        _repo.CancelarReserva(id);
    }
}