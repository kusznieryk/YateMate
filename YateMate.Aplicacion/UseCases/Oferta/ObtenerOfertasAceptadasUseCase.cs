using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Oferta;

public class ObtenerOfertasAceptadasUseCase(IRepositorioOferta repo)
{
    public List<Entidades.Oferta> Ejecutar()
    {
        return repo.ObtenerOfertasAceptadas();
    }
}