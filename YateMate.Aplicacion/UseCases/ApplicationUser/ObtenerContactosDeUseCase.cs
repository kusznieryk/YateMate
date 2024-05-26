using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.ApplicationUser;

public class ObtenerContactosDeUseCase
{
    private readonly IRepositorioApplicationUser _repo;

    public ObtenerContactosDeUseCase(IRepositorioApplicationUser repo)
    {
        _repo = repo;
    }

    public List<Entidades.ApplicationUser> Ejecutar(string id)
    {
        return _repo.ObtenerContactosDe(id);
    }
}