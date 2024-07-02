using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Reserva;

public class HacerReservaUseCase
{
    private readonly IRepositorioReserva _repo;

    public HacerReservaUseCase(IRepositorioReserva repo)
    {
        this._repo = repo;
    }

    public void Ejecutar(Entidades.Reserva reserva, Entidades.Subalquiler? subalquiler)
    {
        _repo.HacerReserva(reserva, subalquiler);
    }
}