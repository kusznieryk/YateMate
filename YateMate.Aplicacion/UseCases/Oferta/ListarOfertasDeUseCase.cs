using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.Entidades;
namespace YateMate.Aplicacion.UseCases.Oferta;

public class ListarOfertasDeUseCase
{
    private readonly IRepositorioOferta _repo;

    public ListarOfertasDeUseCase(IRepositorioOferta repo)
    {
        this._repo = repo;
    }

    public List<Entidades.Oferta> Ejecutar(int publicacionId)
    {
        return _repo.ListarOfertasDe(publicacionId);
    }
}