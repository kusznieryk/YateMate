using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Subalquiler;

public class ModificarSubalquilerUseCase(IRepositorioSubalquiler repo)
{
    public void Ejecutar(Entidades.Subalquiler subalquiler)
    {
        repo.ModificarSubalquiler(subalquiler);
    }
}