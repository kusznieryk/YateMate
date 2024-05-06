using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.Interfaces;

public interface IRepositorioEmbarcacion
{
    void AgregarEmbarcacion(Embarcacion embarcacion);
    List<Embarcacion> ListarEmbarcacionesDe(int id);
    void ModificarEmbarcacion(Embarcacion embarcacion);
}