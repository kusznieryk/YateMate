using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.Entidades;
namespace YateMate.Aplicacion.UseCases.Embarcaciones;

public class ObtenerEmbarcacionesDeUseCase
{
    private readonly IRepositorioEmbarcacion _repo;

    public ObtenerEmbarcacionesDeUseCase(IRepositorioEmbarcacion repo)
    {
        _repo = repo;
    }

    public List<Embarcacion> Ejecutar(string clienteId)
    {
        return _repo.ObtenerEmbarcacionesDe(clienteId);
    }
}