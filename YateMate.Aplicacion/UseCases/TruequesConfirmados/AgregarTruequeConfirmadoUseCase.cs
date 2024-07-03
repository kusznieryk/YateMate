using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.TruequesConfirmados;

public class AgregarTruequeConfirmadoUseCase(IRepositorioTruequeConfirmado repo)
{
    public void Ejecutar(Entidades.Oferta oferta)
    {
        repo.AgregarTruequeConfirmado(oferta);
    }
}