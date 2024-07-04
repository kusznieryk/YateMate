using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Subalquiler;

public class ObtenerFechasReservadasUseCase(IRepositorioSubalquiler repo)
{
    public List<(DateTime Start, DateTime End)> Ejecutar(int idAmarra)
    {
        return repo.ObtenerFechasReservadas(idAmarra);
    }
}