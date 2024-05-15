using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases;

public class FiltrarPublicacionesPorEsloraUseCase(IRepositorioEmbarcacion repo)
{
    public List<Publicacion> Ejecutar(List<Publicacion> original, double esloraMin, Double esloraMax)
    {
        var emb = repo.ObtenerEmbarcaciones().Where(embarcacion => embarcacion.Eslora>=esloraMin && embarcacion.Eslora<esloraMax).Select(emb=>emb.Id);
        return original.Where(pub => emb.Contains(pub.EmbarcacionId)).ToList();
    }
}