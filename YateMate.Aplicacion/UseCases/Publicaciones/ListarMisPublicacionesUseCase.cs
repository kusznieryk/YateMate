using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases;

public class ListarMisPublicacionesUseCase(IRepositorioPublicacion repo)
{
    List<Publicacion> Ejecutar(string idCliente)
    {

       return repo.ObtenerPublicacionesDe(idCliente);

    }

}