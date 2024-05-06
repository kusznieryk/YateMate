using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;
namespace YateMate.Aplicacion.UseCases.Oferta;

public class ObtenerBienUseCase
{
    private readonly IRepositorioBien _repo;

    public ObtenerBienUseCase(IRepositorioBien repo)
    {
        this._repo = repo;
    }

    public Bien? Ejecutar(int id)
    {
        return _repo.ObtenerBien(id);
    }
}