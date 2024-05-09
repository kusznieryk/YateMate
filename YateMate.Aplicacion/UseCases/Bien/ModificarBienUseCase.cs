using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;
namespace YateMate.Aplicacion.UseCases.Oferta;

public class ModificarBienUseCase
{
    private readonly IRepositorioBien _repo;

    public ModificarBienUseCase(IRepositorioBien repo)
    {
        this._repo = repo;
    }

    public void Ejecutar(Bien bien)
    {
        _repo.ModificarBien(bien);
    }
}