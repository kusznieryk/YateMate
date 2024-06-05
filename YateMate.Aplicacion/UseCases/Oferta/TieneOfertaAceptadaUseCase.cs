using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Oferta;

public class TieneOfertaAceptadaUseCase(IRepositorioOferta repo)
{
    public bool Ejecutar(int publicacionId)
    {
        return repo.TieneOfertaAceptada(publicacionId);
    }
}