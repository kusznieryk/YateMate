using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Embarcaciones;

public class ObtenerEmbarcacionPorMatriculaUseCase
{
    private readonly IRepositorioEmbarcacion _repo;

    public ObtenerEmbarcacionPorMatriculaUseCase(IRepositorioEmbarcacion repo)
    {
        _repo = repo;
    }

    public Embarcacion? Ejecutar(string matricula)
    {
        return _repo.ObtenerEmbarcacionPorMatricula(matricula);
    }
}