using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Embarcaciones;

public class TienePublicacionUseCase
{
    private readonly IRepositorioEmbarcacion _repo;

    public TienePublicacionUseCase(IRepositorioEmbarcacion repo)
    {
        _repo = repo;
    }

    public bool Ejecutar(int embarcacionId)
    {
        return _repo.tienePublicacion(embarcacionId);
    }
}