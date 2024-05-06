using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases;

public class ListarMisEmbarcacionesUseCase(IRepositorioEmbarcacion repo)
{
    public List<Embarcacion> Ejecutar(int idCliente)
    {
        return repo.ObtenerEmbarcacionesDe(idCliente);
    }
}