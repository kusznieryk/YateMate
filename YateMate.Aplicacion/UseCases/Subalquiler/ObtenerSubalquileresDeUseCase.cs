using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Subalquiler;

public class ObtenerSubalquileresDeUseCase(IRepositorioSubalquiler repo)
{
    public List<Entidades.Subalquiler> Ejecutar(string idDuenio)
    {
        return repo.ObtenerSubalquileresDe(idDuenio).Where(s => !s.EstaEliminado).ToList();
    }
}