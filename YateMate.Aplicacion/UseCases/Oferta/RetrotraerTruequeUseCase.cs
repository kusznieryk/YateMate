using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Oferta;

public class RetrotraerTruequeUseCase
{
    private readonly IRepositorioOferta _repo;

    public RetrotraerTruequeUseCase(IRepositorioOferta repo)
    {
        this._repo = repo;
    }

    public void Ejecutar(int ofertaId)
    {
        _repo.EliminarOferta(ofertaId);
    }
}   