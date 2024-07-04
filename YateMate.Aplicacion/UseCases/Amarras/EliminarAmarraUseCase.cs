using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.UseCases.Subalquiler;

namespace YateMate.Aplicacion.UseCases.Amarras;

public class EliminarAmarraUseCase(IRepositorioAmarra repo, IRepositorioSubalquiler repoSub)
{
    public void Ejecutar(int idAmarra)
    {
        repo.EliminarAmarra(idAmarra);
    }
}