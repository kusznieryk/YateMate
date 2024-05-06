using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;
namespace YateMate.Aplicacion.UseCases.Oferta;

public class EliminarBienUseCase
{
    private readonly IRepositorioBien _repo;

    public EliminarBienUseCase(IRepositorioBien repo)
    {
        this._repo = repo;
    }

    public void Ejecutar(int id)
    {
        _repo.EliminarBien(id);
    }
}