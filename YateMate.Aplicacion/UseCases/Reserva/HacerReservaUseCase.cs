using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Reserva;

public class HacerReservaUseCase
{
    private readonly IRepositorioReserva _repo;

    public HacerReservaUseCase(IRepositorioReserva repo)
    {
        this._repo = repo;
    }

    public void Ejecutar(Entidades.Reserva reserva)
    {
        _repo.HacerReserva(reserva);
    }
}