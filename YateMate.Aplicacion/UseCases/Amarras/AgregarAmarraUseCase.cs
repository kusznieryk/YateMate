using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Amarras;

public class AgregarAmarraUseCase(IRepositorioAmarra repo)
{
    public void Ejecutar(Amarra amarra)
    {
        repo.AgregarAmarra(amarra);
    }
}