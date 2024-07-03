using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Repositorio;

public class RepositorioTruequeConfirmado : IRepositorioTruequeConfirmado
{
    public void AgregarTruequeConfirmado(TruequeConfirmado truequeConfirmado)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            Console.WriteLine("debug");
            Console.WriteLine(truequeConfirmado.PublicacionId);
            if (!context.TruequesConfirmados.Any() || context.TruequesConfirmados.FirstOrDefault(tc => tc.PublicacionId == truequeConfirmado.PublicacionId) != null)
            {
                context.Add(truequeConfirmado);
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