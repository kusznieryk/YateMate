using System.Security.AccessControl;
using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.UseCases;

namespace YateMate.Repositorio;

public class RepositorioOferta : IRepositorioOferta
{
    
    public List<Publicacion> ListarTruequesDisponibles()
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Publicaciones.ToList();
        }
    }

    public void HacerOferta(Oferta oferta)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            var publicacion = context.Publicaciones.FirstOrDefault(p => p.Id == oferta.PublicacionId);
            if (publicacion != null)
            {
                publicacion!.Ofertas?.Add(oferta);
                context.Add(oferta);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("No se pudo agregar la oferta a esta publicación");
            }
        }
    }

    public void EliminarOferta(int id)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            var oferta = context.Ofertas.FirstOrDefault(o => o.Id == id);
            if (oferta != null)
            {
                context.Remove(oferta);
                context.SaveChanges();
            }
        }
    }

    public List<Oferta> ListarOfertasDe(int publicacionId)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Ofertas.Where(o => o.PublicacionId == publicacionId).ToList();
        }
    }
    
}