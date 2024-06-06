using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.Entidades;
namespace YateMate.Aplicacion.UseCases.Embarcaciones;

public class ObtenerEmbarcacionUseCase(IRepositorioEmbarcacion repo)
{
    public Embarcacion? Ejecutar(int embarcacionId)
    {
        return repo.ObtenerEmbarcacion(embarcacionId);
    }
}