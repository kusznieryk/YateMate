using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Reserva;

public class ObtenerReservasVigentesUseCase(IRepositorioReserva repo)
{
    public List<Entidades.Reserva> Ejecutar()
    {
        return repo.ListarReservas().Where(r => r.FechaInicio < DateTime.Now).ToList();
    }
}