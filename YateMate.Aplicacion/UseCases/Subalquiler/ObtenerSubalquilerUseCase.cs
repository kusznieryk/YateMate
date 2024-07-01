using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Subalquiler;

public class ObtenerSubalquilerUseCase
{
    private readonly IRepositorioSubalquiler _repo;

    public ObtenerSubalquilerUseCase(IRepositorioSubalquiler repo)
    {
        _repo = repo;
    }

    public Entidades.Subalquiler? Ejecutar(int id)
    {
        return _repo.ObtenerSubalquiler(id);
    }
}