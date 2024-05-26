using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Mensaje;

public class AgregarMensajeUseCase
{
    private readonly IRepositorioMensaje _repo;

    public AgregarMensajeUseCase(IRepositorioMensaje repo)
    {
        _repo = repo;
    }

    public void Ejecutar(MensajeChat msg)
    {
        _repo.AgregarMensaje(msg);
    }
}