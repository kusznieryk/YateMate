using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Oferta;

public class ListarOfertasHechasUseCase
{
    private readonly IRepositorioOferta _repo;

    public ListarOfertasHechasUseCase(IRepositorioOferta repo)
    {
        this._repo = repo;
    }

    public List<Entidades.Oferta> Ejecutar(string id)
    {
        return _repo.ListarOfertasHechas(id);
    }
}