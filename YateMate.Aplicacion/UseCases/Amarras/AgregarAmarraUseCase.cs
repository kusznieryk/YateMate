using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.Amarras;

public class AgregarAmarraUseCase(IRepositorioAmarra repo)
{
    public void Ejecutar(int amarraId, string userId )
    {
        repo.AgregarAmarra(amarraId, userId);
    }
}