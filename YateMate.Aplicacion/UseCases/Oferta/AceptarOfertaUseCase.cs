using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Oferta;

public class AceptarOfertaUseCase(IRepositorioOferta repo)
{
    public void Ejecutar(Entidades.Oferta oferta)
    {
        oferta.Aceptada = true;
        repo.ModificarOferta(oferta);
    }
}