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

    public List<Oferta> ListarOfertasHechas(string userId)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Ofertas.Where(o => o.UsuarioId == userId).ToList();
        }
    }

    public Publicacion ObtenerPublicacionDe(int id)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Publicaciones.FirstOrDefault(p => p.Id == id) ?? throw new InvalidOperationException();
        }
    }

    public void EliminarOfertasDe(int idPublicacion)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            var ofertas = context.Ofertas.Where(o => o.PublicacionId == idPublicacion);
            if (!ofertas.Any()) return;
            foreach (var oferta in ofertas)
            {
                context.Remove(oferta);
            }
            context.SaveChanges();
        }
    }
    public void EliminarOfertasDelBien(int idBien)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            var ofertas = context.Ofertas.Where(o => o.BienId == idBien);
            if (!ofertas.Any()) return;
            foreach (var oferta in ofertas)
            {
                context.Remove(oferta);
            }
            context.SaveChanges();
        }
    }

    public List<Oferta> ObtenerTruequesAcordados()
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Ofertas.Where(oferta => oferta.Acordado).ToList();
        }
    }
    
    public List<Oferta> ObtenerOfertasAceptadas()
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Ofertas.Where(oferta => oferta.Aceptada).ToList();
        }
    }
    
    

    public void RetrotraerTrueque()
    {
        
    }

    public void ModificarOferta(Oferta oferta)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            var viejaO = context.Ofertas.FirstOrDefault(o => o.Id == oferta.Id);
            if (viejaO == null) return;
            viejaO.Aceptada = oferta.Aceptada;
            context.SaveChanges();
        }
    }

    public bool TieneOfertaAceptada(int publicacionId)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Ofertas.Any(oferta => oferta.PublicacionId==publicacionId && oferta.Aceptada);
        }
    }
}