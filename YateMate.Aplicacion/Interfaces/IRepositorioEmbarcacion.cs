using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.Interfaces;

public interface IRepositorioEmbarcacion
{
    List<Embarcacion> ObtenerEmbarcaciones();
    List<Embarcacion> ObtenerEmbarcacionesDe(int idCliente);

    Embarcacion ObtenerEmbarcacion(int idCliente);
    bool EliminarEmbarcacion(int idEmbarcacion);

}