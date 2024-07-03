using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Subalquiler;

public class ObtenerSubalquileresVigentesUseCase(IRepositorioSubalquiler repo)
{
    public List<Entidades.Subalquiler> Ejecutar()
    {
        return repo.ObtenerSubalquileresVigentes().Where(s => !s.EstaEliminado).ToList();
    }
}