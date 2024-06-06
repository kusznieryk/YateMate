using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Publicaciones;

public class ObtenerDuenioUseCase(IRepositorioEmbarcacion repo)
{
    public string? Ejecutar(Publicacion publicacion)
    {
        return repo.ObtenerEmbarcacion(publicacion.EmbarcacionId)?.ClienteId;
    }
}