using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.Interfaces;

public interface IRepositorioTruequeConfirmado
{
    public void AgregarTruequeConfirmado(TruequeConfirmado truequeConfirmado);
    public List<TruequeConfirmado> ObtenerTruequesConfirmados();
    public List<TruequeConfirmado> ObtenerTruequesConfirmadosDeLaPublicacion(int idPublicacion);

}