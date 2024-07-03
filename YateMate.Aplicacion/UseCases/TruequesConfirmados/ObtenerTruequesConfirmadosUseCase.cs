using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Aplicacion.UseCases.TruequesConfirmados;

public class ObtenerTruequesConfirmadosUseCase(IRepositorioTruequeConfirmado repo)
    {
        public List<TruequeConfirmado> Ejecutar()
        {
            return repo.ObtenerTruequesConfirmados();
        }
}