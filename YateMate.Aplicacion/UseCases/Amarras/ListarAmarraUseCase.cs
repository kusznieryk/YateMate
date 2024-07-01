using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Amarras;

public class ListarAmarraUseCase(IRepositorioAmarra repo)
{
    public List<Amarra> Ejecutar(string idUser)
    {
        return repo.ListarAmarrasDe(idUser);
    }
}