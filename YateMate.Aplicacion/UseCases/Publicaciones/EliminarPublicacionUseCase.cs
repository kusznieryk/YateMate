using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Publicaciones;

public class EliminarPublicacionUseCase(IRepositorioPublicacion repo, IRepositorioOferta repoOferta)
{
    public void Ejecutar(Publicacion pub)
    {

        repo.EliminarPublicacion(pub.EmbarcacionId);
        repoOferta.EliminarOfertasDe(pub.Id);

    }
}