using Microsoft.AspNetCore.Mvc.ModelBinding;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Reserva;

public class ListarReservasDeUseCase
{
    private readonly IRepositorioReserva _repo;

    public ListarReservasDeUseCase(IRepositorioReserva repo)
    {
        _repo = repo;
    }

    public List<Entidades.Reserva> Ejecutar(string usuarioId)
    {
        return _repo.ListarReservasDe(usuarioId);
    }
}