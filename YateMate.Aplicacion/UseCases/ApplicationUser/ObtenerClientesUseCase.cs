using YateMate.Aplicacion.Interfaces;
namespace YateMate.Aplicacion.UseCases.ApplicationUser;

public class ObtenerClientesUseCase
{
    private readonly IRepositorioApplicationUser _repo;

    public ObtenerClientesUseCase(IRepositorioApplicationUser repo)
    {
        _repo = repo;
    }

    public List<Entidades.ApplicationUser> Ejecutar()
    {
        return _repo.ObtenerClientes();
    }
}