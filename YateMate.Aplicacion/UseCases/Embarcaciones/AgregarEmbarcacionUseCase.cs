using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Embarcaciones;

public class AgregarEmbarcacionUseCase
{
    private readonly IRepositorioEmbarcacion _repo;

    public AgregarEmbarcacionUseCase(IRepositorioEmbarcacion repo)
    {
        _repo = repo;
    }

    public void Ejecutar(Embarcacion embarcacion)
    {
        _repo.AgregarEmbarcacion(embarcacion);
    }
}