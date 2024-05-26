using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Mensaje;

public class ObtenerMensajesEntreUseCase
{
    private readonly IRepositorioMensaje _repo;

    public ObtenerMensajesEntreUseCase(IRepositorioMensaje repo)
    {
        _repo = repo;
    }

    public List<MensajeChat> Ejecutar(string id1, string id2)
    {
        return _repo.ObtenerMensajesEntre(id1, id2);
    }
}