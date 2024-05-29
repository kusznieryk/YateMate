using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Oferta;

public class ObtenerPublicacionDeUseCase
{
    private readonly IRepositorioOferta _repo;

    public ObtenerPublicacionDeUseCase(IRepositorioOferta repo)
    {
        this._repo = repo;
    }

    public Publicacion Ejecutar(int id)
    {
        return _repo.ObtenerPublicacionDe(id);
    }
}