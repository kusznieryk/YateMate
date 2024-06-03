using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Oferta;

public class ObtenerTruequesAcordadosUseCase
{
    private readonly IRepositorioOferta _repo;

    public ObtenerTruequesAcordadosUseCase(IRepositorioOferta repo)
    {
        this._repo = repo;
    }

    public List<Entidades.Oferta> Ejecutar()
    {
        return _repo.ObtenerTruequesAcordados();
    }
}