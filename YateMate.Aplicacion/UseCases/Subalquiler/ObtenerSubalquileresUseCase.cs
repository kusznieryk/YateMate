using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Subalquiler;

public class ObtenerSubalquileresUseCase(IRepositorioSubalquiler repo)
{
    public List<Entidades.Subalquiler> Ejecutar()
    {
       return repo.ObtenerSubalquileres().Where(s => !s.EstaEliminado).ToList();
    }
}