using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.ApplicationUser;

public class ObtenerEmpleadosUseCase
{
    private readonly IRepositorioApplicationUser _repo;

    public ObtenerEmpleadosUseCase(IRepositorioApplicationUser repo)
    {
        _repo = repo;
    }

    public List<Entidades.ApplicationUser> Ejecutar()
    {
        return _repo.ObtenerEmpleados();
    }
}