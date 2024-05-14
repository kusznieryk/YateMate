using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.Entidades;
namespace YateMate.Aplicacion.UseCases.Embarcaciones;

public class ModificarEmbarcacionUseCase
{
    private readonly IRepositorioEmbarcacion _repo;

    public ModificarEmbarcacionUseCase(IRepositorioEmbarcacion repo)
    {
        _repo = repo;
    }

    public void Ejecutar(Embarcacion embarcacion)
    {
        _repo.ModificarEmbarcacion(embarcacion);
    }
}