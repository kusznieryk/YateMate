using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;
namespace YateMate.Aplicacion.UseCases.Oferta;

public class AgregarBienUseCase
{
    private readonly IRepositorioBien _repo;

    public AgregarBienUseCase(IRepositorioBien repo)
    {
        this._repo = repo;
    }

    public void Ejecutar(Bien bien)
    {
        _repo.AgregarBien(bien);
    }
}