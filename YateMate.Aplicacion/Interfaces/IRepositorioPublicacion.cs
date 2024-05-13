using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.Interfaces;

public interface IRepositorioPublicacion
{
    bool AgregarPublicacion(Publicacion publicacion);
    List<Publicacion> ObtenerPublicaciones();
    List<Publicacion> ObtenerPublicacionesDe(string idCliente);
    Publicacion? ObtenerPublicacion(int idPublicacion);
    bool EliminarPublicacion(int idPublicacion);
}