using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases;

public class FiltrarPublicacionesPorCaladoUseCase(IRepositorioEmbarcacion repo)
{
    public List<Publicacion> Ejecutar(List<Publicacion> original, double caladoMin, double caladoMax)
    {
        var emb = repo.ObtenerEmbarcaciones().Where(embarcacion => embarcacion.Calado<caladoMax && embarcacion.Calado>caladoMin).Select(emb=>emb.Id);
        return original.Where(pub => emb.Contains(pub.EmbarcacionId)).ToList();
    }
}