using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.Entidades;
namespace YateMate.Aplicacion.UseCases.Oferta;

public class ListarOfertasDeUseCase(IRepositorioOferta repo, IRepositorioBien repoBi)
{

    public List<Entidades.Oferta> Ejecutar(int publicacionId, bool mostrar)
    {
        if (!mostrar)
        {
            return repo.ListarOfertasDe(publicacionId).Where(e => !repoBi.TieneOfertaAceptada(e.BienId)).ToList();
        }
        return repo.ListarOfertasDe(publicacionId);
    }
}