using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Oferta;

public class HacerOfertaUseCase
{
    private readonly IRepositorioOferta _repo;

    public HacerOfertaUseCase(IRepositorioOferta repo)
    {
        this._repo = repo;
    }

    public void Ejecutar(Entidades.Oferta oferta)
    {
        _repo.HacerOferta(oferta);
    }
}