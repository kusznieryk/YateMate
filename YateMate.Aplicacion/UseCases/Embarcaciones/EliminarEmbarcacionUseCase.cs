using System.Security.Permissions;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Embarcaciones;

public class EliminarEmbarcacionUseCase
{
    private readonly IRepositorioEmbarcacion _repo;

    public EliminarEmbarcacionUseCase(IRepositorioEmbarcacion repo)
    {
        _repo = repo;
    }

    public void Ejecutar(int embarcacionId)
    {
        _repo.EliminarEmbarcacion(embarcacionId);
    }
}