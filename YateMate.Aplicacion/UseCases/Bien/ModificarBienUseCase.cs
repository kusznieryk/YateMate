using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;
namespace YateMate.Aplicacion.UseCases.Bien;

public class ModificarBienUseCase
{
    private readonly IRepositorioBien _repo;

    public ModificarBienUseCase(IRepositorioBien repo)
    {
        this._repo = repo;
    }

    public void Ejecutar(Entidades.Bien bien)
    {
        _repo.ModificarBien(bien);
    }
}