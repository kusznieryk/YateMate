using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Subalquiler;

public class FiltrarPorFechaUseCase(IRepositorioReserva repo)
{
    public List<Entidades.Subalquiler> Ejecutar(List<Entidades.Subalquiler> lista, DateTime fechaInicio, DateTime fechaFin)
    {
        var reservas = new Dictionary<int,List<Entidades.Reserva>>();
        lista.ForEach(sub=>reservas.Add(sub.Id, repo.ListarReservasDeSubalquiler(sub.Id)));
        return lista
            .Where(s => 
                        s.FechaInicio <= fechaInicio
                        && s.FechaFin >= fechaFin 
                        && !reservas[s.Id].Any(reserva =>
                            (reserva.FechaInicio < fechaFin && reserva.FechaFin > fechaInicio))
            ).ToList();
    }
}