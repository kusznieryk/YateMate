using System.Collections;
using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;
namespace YateMate.Aplicacion.UseCases.Oferta;

public class ListarBienesDeUseCase
{
    private readonly IRepositorioBien _repo;

    public ListarBienesDeUseCase(IRepositorioBien repo)
    {
        this._repo = repo;
    }

    public List<Bien> Ejecutar(int id)
    {
        return _repo.ListarBienesDe(id);
    }
}