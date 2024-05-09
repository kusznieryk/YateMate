using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.Interfaces;

public interface IRepositorioPublicacion
{
    bool AgregarPublicacion(Embarcacion embarcacion);
    List<Embarcacion> ObtenerPublicaciones();
    List<Embarcacion> ObtenerPublicacionesDe(int idCliente);
    Embarcacion ObtenerPublicacion(int idPublicacion);
    bool EliminarPublicacion(int idPublicacion);
}