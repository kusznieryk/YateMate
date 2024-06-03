using System.Security.Permissions;
using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Embarcaciones;

public class EliminarEmbarcacionUseCase
{
    private readonly IRepositorioEmbarcacion _repo;
    private readonly IRepositorioPublicacion _repositorioPublicacion;

    public EliminarEmbarcacionUseCase(IRepositorioEmbarcacion repo, IRepositorioPublicacion repoPublicacion)
    {
        _repo = repo;
        _repositorioPublicacion = repoPublicacion;
    }

    public void Ejecutar(int embarcacionId)
    {
        _repositorioPublicacion.EliminarPublicacion(embarcacionId);
        _repo.EliminarEmbarcacion(embarcacionId);
    }
}