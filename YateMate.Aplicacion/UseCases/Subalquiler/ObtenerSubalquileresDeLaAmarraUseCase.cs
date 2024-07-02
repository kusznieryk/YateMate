using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Subalquiler;

public class ObtenerSubalquileresDeLaAmarraUseCase(IRepositorioSubalquiler repo)
{
    public List<Entidades.Subalquiler> Ejecutar(int idAmarra)
    {
        return repo.ObtenerSubalquileresDeLaAmarra(idAmarra);
    }
}