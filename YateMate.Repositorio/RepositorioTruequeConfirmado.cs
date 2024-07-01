using YateMate.Aplicacion.Entidades;

namespace YateMate.Repositorio;

public class RepositorioTruequeConfirmado
{
    public void AgregarTruequeConfirmado(Oferta oferta)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            TruequeConfirmado? confirmado = context.TruequesConfirmados.FirstOrDefault(p => p.PublicacionId == oferta.PublicacionId);
            if (confirmado != null)
            {
                context.Add(new TruequeConfirmado( oferta.BienId, oferta.PublicacionId, oferta.UsuarioId));
                context.SaveChanges();
            }
        }
    }
}