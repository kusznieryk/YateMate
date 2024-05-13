using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases;

public class PublicarEmbarcacionUseCase(IRepositorioPublicacion repo)
{
    public bool Ejecutar(Publicacion publicacion)
    {
        return repo.AgregarPublicacion(publicacion);
    }
}