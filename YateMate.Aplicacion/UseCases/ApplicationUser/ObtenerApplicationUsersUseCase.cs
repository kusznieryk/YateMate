using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.UseCases.ApplicationUser;

public class ObtenerApplicationUsersUseCase
{
    private readonly IRepositorioApplicationUser _repo;

    public ObtenerApplicationUsersUseCase(IRepositorioApplicationUser repo)
    {
        _repo = repo;
    }

    public List<Entidades.ApplicationUser> Ejecutar()
    {
        return _repo.ObtenerApplicationUsers();
    }
}