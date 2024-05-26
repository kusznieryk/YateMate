using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.Interfaces;

public interface IRepositorioMensaje
{
    void AgregarMensaje(MensajeChat message);
    List<MensajeChat> ObtenerMensajesEntre(string contact1Id, string contact2Id);
    
}