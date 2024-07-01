using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Reserva;

public class ModificarReservaUseCase
{
    private readonly IRepositorioReserva _repo;

    public ModificarReservaUseCase(IRepositorioReserva repo)
    {
        this._repo = repo;
    }

    public void Ejecutar(Entidades.Reserva reserva)
    {
        _repo.ModificarReserva(reserva);
    }
}