using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.ApplicationUser;

public class ObtenerApplicationUserUseCase
{
    private readonly IRepositorioApplicationUser _repo;

    public ObtenerApplicationUserUseCase(IRepositorioApplicationUser repo)
    {
        _repo = repo;
    }

    public Entidades.ApplicationUser? Ejecutar(string id)
    {
        return _repo.ObtenerApplicationUser(id);
    }
}