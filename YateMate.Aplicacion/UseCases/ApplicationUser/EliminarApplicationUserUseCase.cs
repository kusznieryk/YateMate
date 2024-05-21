using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.UseCases.ApplicationUser;

public class EliminarApplicationUserUseCase
{
    private readonly IRepositorioApplicationUser _repo;
    private readonly IRepositorioEmbarcacion _repoEmbarcacion;
    private readonly IRepositorioBien _repoBien;
    private readonly IRepositorioPublicacion _repositorioPublicacion;

    public EliminarApplicationUserUseCase(IRepositorioApplicationUser repo, IRepositorioEmbarcacion repoEmbarcacion, IRepositorioBien repoBien, IRepositorioPublicacion repoPublicacion)
    {
        _repo = repo;
        _repoEmbarcacion = repoEmbarcacion;
        _repoBien = repoBien;
        _repositorioPublicacion = repoPublicacion;
    }

    public void Ejecutar(string id)
    {
        foreach (var embarcacion in _repoEmbarcacion.ObtenerEmbarcacionesDe(id))
        {
            _repositorioPublicacion.EliminarPublicacion(embarcacion.Id);
            _repoEmbarcacion.EliminarEmbarcacion(embarcacion.Id);
        }

        foreach (var bien in _repoBien.ListarBienesDe(id))
        {
            _repoBien.EliminarBien(bien.Id);
        }

        _repo.EliminarApplicationUser(id);
    }
}