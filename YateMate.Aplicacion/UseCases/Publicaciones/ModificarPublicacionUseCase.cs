using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Publicaciones;

public class ModificarPublicacionUseCase(IRepositorioPublicacion repo)
{
    public void Ejecutar(Publicacion publicacion)
    {

        repo.ModificarPublicacion(publicacion);

    }
}