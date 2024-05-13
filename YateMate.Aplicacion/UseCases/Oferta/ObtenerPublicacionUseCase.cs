using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Oferta;

public class ObtenerPublicacionUseCase(IRepositorioPublicacion repo)
{
    public Publicacion? Ejecutar(int idEmbarcacion)
    {
        return repo.ObtenerPublicacion(idEmbarcacion);
    }
}