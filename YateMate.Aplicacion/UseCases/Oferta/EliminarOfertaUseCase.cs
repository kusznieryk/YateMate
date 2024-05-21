using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.UseCases.Oferta;

public class EliminarOfertaUseCase
{
    private readonly IRepositorioOferta _repo;

    public EliminarOfertaUseCase(IRepositorioOferta repo)
    {
        this._repo = repo;
    }

    public void Ejecutar(int id)
    {
        _repo.EliminarOferta(id);
    }
}