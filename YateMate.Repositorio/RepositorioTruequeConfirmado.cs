using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Repositorio;

public class RepositorioTruequeConfirmado : IRepositorioTruequeConfirmado
{
    public void AgregarTruequeConfirmado(Oferta oferta)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            TruequeConfirmado? confirmado = context.TruequesConfirmados.FirstOrDefault(p => p.PublicacionId == oferta.PublicacionId);
            if (confirmado != null)
            {
                context.Add(new TruequeConfirmado( oferta.BienId, oferta.PublicacionId));
                context.SaveChanges();
            }
        }
    }

    public List<TruequeConfirmado> ObtenerTruequesConfirmados()
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.TruequesConfirmados.ToList();
        }
    }

    public List<TruequeConfirmado> ObtenerTruequesConfirmadosDeLaPublicacion(int idPublicacion)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.TruequesConfirmados
                .Where(tc => tc.PublicacionId == idPublicacion)
                .ToList();
        }
    }
}