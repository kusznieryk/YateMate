using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Amarras;

public class EliminarAmarraUseCase(IRepositorioAmarra repo)
{
    public void Ejecutar(int idAmarra)
    {
        repo.EliminarAmarra(idAmarra);
    }
}