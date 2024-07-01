using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Subalquiler;

public class ObtenerSubalquileresEntreUseCase(IRepositorioSubalquiler repo)
{
    public List<Entidades.Subalquiler> Ejecutar(DateTime fechaI, DateTime fechaF)
    {
        return repo.ObtenerSubalquileresEntre(fechaI, fechaF);
    }
}