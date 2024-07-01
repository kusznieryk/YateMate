using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.Interfaces;

public interface IRepositorioAmarra
{
    void AgregarAmarra(Amarra amarra);
    void EliminarAmarra(int id);
    void ModificarAmarra(Amarra amarra);
    List<Amarra> ListarAmarrasDe(string id);
    Amarra? ObtenerAmarra(int id);
}