using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Amarras;

public class ListarAmarrasVaciasUseCase(IRepositorioAmarra repo)
{
    public List<Amarra> Ejecutar()
    {
        return repo.ListarAmarrasSinAsignar();
    }
}