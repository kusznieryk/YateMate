using System.Collections;
using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.Entidades;
namespace YateMate.Aplicacion.UseCases.Bien;

public class ListarBienesDeUseCase
{
    private readonly IRepositorioBien _repo;

    public ListarBienesDeUseCase(IRepositorioBien repo)
    {
        this._repo = repo;
    }

    public List<Entidades.Bien> Ejecutar(String id)
    {
        return _repo.ListarBienesDe(id);
    }
}