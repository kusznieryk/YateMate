using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.ApplicationUser;

public class ModificarApplicationUserUseCase
{
    private readonly IRepositorioApplicationUser _repo;

    public ModificarApplicationUserUseCase(IRepositorioApplicationUser repo)
    {
        _repo = repo;
    }

    public void Ejecutar(Entidades.ApplicationUser user)
    {
        _repo.ModificarApplicationUser(user);
    }
}