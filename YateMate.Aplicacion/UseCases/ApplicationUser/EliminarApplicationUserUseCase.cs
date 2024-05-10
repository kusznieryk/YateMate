using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.UseCases.ApplicationUser;

public class EliminarApplicationUserUseCase
{
    private readonly IRepositorioApplicationUser _repo;

    public EliminarApplicationUserUseCase(IRepositorioApplicationUser repo)
    {
        _repo = repo;
    }

    public void Ejecutar(string id)
    {
        _repo.EliminarApplicationUser(id);
    }
}