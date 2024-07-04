using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Repositorio;

public class RepositorioAmarra:IRepositorioAmarra
{
    public void AgregarAmarra(int amarraId, string userId)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            var viejo=context.Amarras.FirstOrDefault(b => b.Id== amarraId);
            if (viejo != null)
            {
                viejo.UsuarioId = userId;
                context.SaveChanges();
            }
        }

    }

    public void EliminarAmarra(int id)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
             var elim=context.Amarras.FirstOrDefault(b => b.Id== id);
             if (elim != null)
                 elim.UsuarioId =null;
             context.SaveChanges();
        }    
    }

    public void ModificarAmarra(Amarra amarra)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
           var viejo=context.Amarras.FirstOrDefault(b => b.Id== amarra.Id);
           if (viejo != null)
           {
               viejo.Precio = amarra.Precio;
               viejo.Ubicacion = amarra.Ubicacion;
               viejo.Tamanio = amarra.Tamanio;
               context.SaveChanges();
           }
        }

    }

    public List<Amarra> ListarAmarrasDe(string id)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Amarras.Where(b => (b.UsuarioId??"").Equals(id)&&!b.Borrado).ToList();
        }
    }
    public List<Amarra> ListarAmarrasSinAsignar()
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Amarras.Where(b => (b.UsuarioId==null)).ToList();
        }
    }

    public Amarra? ObtenerAmarra(int id)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.Amarras.FirstOrDefault(b => b.Id== id);
        }
        
    }
}