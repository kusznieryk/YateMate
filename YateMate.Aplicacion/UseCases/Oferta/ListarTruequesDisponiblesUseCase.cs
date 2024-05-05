using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Oferta;

public class ListarTruequesDisponiblesUseCase
{
    private readonly IRepositorioOferta _repo;

    public ListarTruequesDisponiblesUseCase(IRepositorioOferta repo)
    {
        this._repo = repo;
    }

    public List<Publicacion> Ejecutar()
    {
        return _repo.ListarTruequesDisponibles();
    }
}