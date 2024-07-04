using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.UseCases.Subalquiler;

namespace YateMate.Aplicacion.UseCases.Amarras;

public class EliminarAmarraUseCase(IRepositorioAmarra repo, IRepositorioSubalquiler repoSub)
{
    public void Ejecutar(int idAmarra)
    {
        var listaDeSubalquileres=repoSub.ObtenerSubalquileresDeLaAmarra(idAmarra);
        listaDeSubalquileres.ForEach(sub => repoSub.EliminarSubalquiler(sub.Id));
        repo.EliminarAmarra(idAmarra);
    }
}