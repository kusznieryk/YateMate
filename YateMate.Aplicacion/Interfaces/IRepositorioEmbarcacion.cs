using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.Interfaces;

public interface IRepositorioEmbarcacion
{
    void AgregarEmbarcacion(Embarcacion embarcacion);
    List<Embarcacion> ObtenerEmbarcaciones();
    List<Embarcacion> ObtenerEmbarcacionesDe(string clienteId);

    Embarcacion ObtenerEmbarcacion(int idCliente);
    bool EliminarEmbarcacion(int idEmbarcacion);

}