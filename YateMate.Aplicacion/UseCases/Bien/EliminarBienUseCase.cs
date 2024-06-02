using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;
namespace YateMate.Aplicacion.UseCases.Bien;

public class EliminarBienUseCase(IRepositorioBien repo, IRepositorioOferta repoOf)
{

    public void Ejecutar(int id)
    {
        repo.EliminarBien(id);
        repoOf.EliminarOfertasDelBien(id);
    }
}