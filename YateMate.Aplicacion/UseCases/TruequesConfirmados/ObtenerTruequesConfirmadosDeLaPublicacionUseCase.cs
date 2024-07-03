using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.TruequesConfirmados;

public class ObtenerTruequesConfirmadosDeLaPublicacionUseCase(IRepositorioTruequeConfirmado repo)
{
    public List<TruequeConfirmado> Ejecutar(int idPubli)
    {
        return repo.ObtenerTruequesConfirmadosDeLaPublicacion(idPubli);
    }
}