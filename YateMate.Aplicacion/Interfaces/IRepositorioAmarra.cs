using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.Interfaces;

public interface IRepositorioAmarra
{
    void AgregarAmarra(int amarraId, string userId);
    void EliminarAmarra(int id);
    void ModificarAmarra(Amarra amarra);
    List<Amarra> ListarAmarrasDe(string id);
    List<Amarra> ListarAmarrasSinAsignar();
    Amarra? ObtenerAmarra(int id);
}