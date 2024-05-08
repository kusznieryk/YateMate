using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.UseCases;

public class FiltrarPublicacionesPorCaladoUseCase
{
    public List<Embarcacion> Ejecutar(List<Embarcacion> original, double caladoMin, double caladoMax)
    {
        return original.Where((embarcacion => embarcacion.Calado<caladoMax && embarcacion.Calado>caladoMin)).ToList();
    }
}