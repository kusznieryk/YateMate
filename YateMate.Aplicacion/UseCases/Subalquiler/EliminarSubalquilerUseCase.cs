using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Subalquiler;

public class EliminarSubalquilerUseCase(IRepositorioSubalquiler repo)
{
    public void Ejecutar(string idSubalquiler)
    {
        repo.EliminarSubalquiler(idSubalquiler);
    }
}