using System.Security.Permissions;
using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.UseCases.Publicaciones;

namespace YateMate.Aplicacion.UseCases.Embarcaciones;

public class EliminarEmbarcacionUseCase
{
    private readonly IRepositorioEmbarcacion _repo;
    private readonly ObtenerPublicacionUseCase _obtenerPublicacionUseCase;
    private readonly EliminarPublicacionUseCase _eliminarPublicacionUseCase;
    private readonly TienePublicacionUseCase _tienePublicacionUseCase;

    public EliminarEmbarcacionUseCase(IRepositorioEmbarcacion repo, ObtenerPublicacionUseCase obtenerPublicacionUseCase, EliminarPublicacionUseCase eliminarPublicacionUseCase, TienePublicacionUseCase tienePublicacionUseCase)
    {
        _repo = repo;
        _obtenerPublicacionUseCase = obtenerPublicacionUseCase;
        _eliminarPublicacionUseCase = eliminarPublicacionUseCase;
        _tienePublicacionUseCase = tienePublicacionUseCase;
    }

    public void Ejecutar(int embarcacionId)
    {
        bool tienePublicacion = _tienePublicacionUseCase.Ejecutar(embarcacionId);
        if(tienePublicacion)
            _eliminarPublicacionUseCase.Ejecutar(_obtenerPublicacionUseCase.Ejecutar(embarcacionId)!);
        _repo.EliminarEmbarcacion(embarcacionId, true);
    }
}