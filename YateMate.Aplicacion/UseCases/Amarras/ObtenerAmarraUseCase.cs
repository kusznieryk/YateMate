using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Amarras;

public class ObtenerAmarraUseCase(IRepositorioAmarra repo)
{
    public Amarra? Ejecutar(int idAmarra)
    {
        return repo.ObtenerAmarra(idAmarra);
    }
}