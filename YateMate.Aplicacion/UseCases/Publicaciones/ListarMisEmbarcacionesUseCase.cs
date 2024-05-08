using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases;

public class ListarMisEmbarcacionesUseCase(IRepositorioEmbarcacion repo)
{
    public List<Embarcacion> Ejecutar(string idCliente)
    {
        return repo.ObtenerEmbarcacionesDe(idCliente);
    }
}