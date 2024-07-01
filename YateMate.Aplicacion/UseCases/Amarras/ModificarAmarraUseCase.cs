using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Amarras;

public class ModificarAmarraUseCase(IRepositorioAmarra repo)
{
    public void Ejecutar(Amarra amarra)
    {
         repo.ModificarAmarra(amarra);
    }
}