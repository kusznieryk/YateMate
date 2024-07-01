using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Subalquiler;

public class AgregarSubalquilerUseCase(IRepositorioSubalquiler repo)
{
    public void Ejecutar(Entidades.Subalquiler subalquiler)
    {
        repo.AgregarSubalquiler(subalquiler);
    }
}