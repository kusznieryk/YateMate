using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Reserva;

public class ObtenerFechasOcupadasUseCase(IRepositorioReserva repo)
{
    public async Task<List<(DateTime Start, DateTime End)>> Ejecutar(int subalquilerId)
    {
        return await repo.ObtenerFechasOcupadas(subalquilerId);
    }
}