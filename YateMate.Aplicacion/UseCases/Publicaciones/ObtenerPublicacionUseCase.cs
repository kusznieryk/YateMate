using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Publicaciones;

public class ObtenerPublicacionUseCase(IRepositorioPublicacion repo)
{
    public Publicacion? Ejecutar(int idEmbarcacion)
    {
        return repo.ObtenerPublicacion(idEmbarcacion);
    }
}