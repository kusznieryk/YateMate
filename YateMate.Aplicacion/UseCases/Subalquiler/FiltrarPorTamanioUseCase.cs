using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Subalquiler;

public class FiltrarPorTamanioUseCase(IRepositorioAmarra repo)
{
    public List<Entidades.Subalquiler> Ejecutar(List<Entidades.Subalquiler> lista, List<TamanioEstandar> filtros)
    {
        return lista.Where(s => filtros.Contains(repo.ObtenerAmarra(s.IdAmarra).Tamanio)).ToList();
    }
}