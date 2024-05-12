using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Bien;

public class AgregarBienUseCase
{
    private readonly IRepositorioBien _repo;

    public AgregarBienUseCase(IRepositorioBien repo)
    {
        this._repo = repo;
    }

    public void Ejecutar(Entidades.Bien bien)
    {
        _repo.AgregarBien(bien);
    }
}