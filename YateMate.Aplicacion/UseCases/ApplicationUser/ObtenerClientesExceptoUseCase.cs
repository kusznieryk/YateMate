using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.ApplicationUser;

public class ObtenerClientesExceptoUseCase
{
    private readonly IRepositorioApplicationUser _repo;

    public ObtenerClientesExceptoUseCase(IRepositorioApplicationUser repo)
    {
        _repo = repo;
    }

    public List<Entidades.ApplicationUser> Ejecutar(string id)
    {
        return _repo.ObtenerClientesExcepto(id);
    }
}