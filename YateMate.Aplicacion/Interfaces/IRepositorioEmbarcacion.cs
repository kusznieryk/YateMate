using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.Interfaces;

public interface IRepositorioEmbarcacion
{
    void AgregarEmbarcacion(Embarcacion embarcacion);
    List<Embarcacion> ObtenerEmbarcaciones();
    List<Embarcacion> ObtenerEmbarcacionesDe(string clienteId);
    void ModificarEmbarcacion(Embarcacion embarcacion);
    Embarcacion ObtenerEmbarcacion(int embarcacionId);
    void EliminarEmbarcacion(int idEmbarcacion);

}