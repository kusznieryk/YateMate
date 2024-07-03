using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.TruequesConfirmados;

public class AgregarTruequeConfirmadoUseCase(IRepositorioTruequeConfirmado repo)
{
    public void Ejecutar(Entidades.TruequeConfirmado tc)
    {
        repo.AgregarTruequeConfirmado(tc);
    }
}