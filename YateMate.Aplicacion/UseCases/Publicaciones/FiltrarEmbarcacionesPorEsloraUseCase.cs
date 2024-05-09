using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.UseCases;

public class FiltrarEmbarcacionesPorEsloraUseCase
{
    public List<Embarcacion> Ejecutar(List<Embarcacion> original, double esloraMin, Double esloraMax)
    {
        return original.Where((embarcacion => embarcacion.Eslora>esloraMin && embarcacion.Eslora<esloraMax)).ToList();
    }
}