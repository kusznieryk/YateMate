using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Subalquiler;

public class ObtenerDuenioSubalquilerUseCase(IRepositorioSubalquiler repo)
{
    public Entidades.ApplicationUser Ejecutar(string id)
    {
        return repo.ObtenerDuenioSubalquiler(id);
    }
}