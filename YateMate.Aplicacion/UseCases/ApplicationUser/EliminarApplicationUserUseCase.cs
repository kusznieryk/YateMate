using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.UseCases.Bien;
using YateMate.Aplicacion.UseCases.Embarcaciones;

namespace YateMate.Aplicacion.UseCases.ApplicationUser;

public class EliminarApplicationUserUseCase
{
    private readonly EliminarEmbarcacionUseCase _eliminarEmbarcacionUseCase;
    private readonly ObtenerEmbarcacionesDeUseCase _obtenerEmbarcacionesDeUseCase;
    private readonly ListarBienesDeUseCase _listarBienesDeUseCase;
    private readonly EliminarBienUseCase _eliminarBienUseCase;
    private readonly IRepositorioApplicationUser _repo;
    public EliminarApplicationUserUseCase(EliminarEmbarcacionUseCase eliminarEmbarcacionUseCase, ObtenerEmbarcacionesDeUseCase obtenerEmbarcacionesDeUseCase, ListarBienesDeUseCase listarBienesDeUseCase, EliminarBienUseCase eliminarBienUseCase, IRepositorioApplicationUser repo)
    {
        _eliminarEmbarcacionUseCase = eliminarEmbarcacionUseCase;
        _obtenerEmbarcacionesDeUseCase = obtenerEmbarcacionesDeUseCase;
        _listarBienesDeUseCase = listarBienesDeUseCase;
        _eliminarBienUseCase = eliminarBienUseCase;
        _repo = repo;
    }

    public void Ejecutar(string id)
    {
        foreach (var embarcacion in _obtenerEmbarcacionesDeUseCase.Ejecutar(id))
        {
            _eliminarEmbarcacionUseCase.Ejecutar(embarcacion.Id);
        }
        foreach (var bien in _listarBienesDeUseCase.Ejecutar(id))
        {
            _eliminarBienUseCase.Ejecutar(bien.Id);
        }
        _repo.EliminarApplicationUser(id);
    }
}