using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Oferta;

public class ListarTruequesDisponiblesUseCase(IRepositorioOferta repo, IRepositorioOferta repoOf)
{

    public List<Publicacion> Ejecutar()
    {
        return repo.ListarTruequesDisponibles().Where(pub =>!repoOf.TieneOfertaAceptada(pub.Id)).ToList();
    }
}