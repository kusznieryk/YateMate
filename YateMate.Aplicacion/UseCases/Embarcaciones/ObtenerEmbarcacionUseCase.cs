using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.Entidades;
namespace YateMate.Aplicacion.UseCases.Embarcaciones;

public class ObtenerEmbarcacionUseCase
{
    private readonly IRepositorioEmbarcacion _repo;

    public ObtenerEmbarcacionUseCase(IRepositorioEmbarcacion repo)
    {
        _repo = repo;
    }

    public Embarcacion Ejecutar(int embarcacionId)
    {
        return _repo.ObtenerEmbarcacion(embarcacionId);
    }
}