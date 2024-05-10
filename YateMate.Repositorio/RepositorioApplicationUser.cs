using Microsoft.AspNetCore.Identity;
using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;
using Microsoft.Extensions.Identity;
namespace YateMate.Repositorio;

public class RepositorioApplicationUser : IRepositorioApplicationUser
{
    public void EliminarApplicationUser(string id)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            var applicationUserAEliminar = context.ApplicationUsers.FirstOrDefault(au => au.Id.Equals(id));
            if (applicationUserAEliminar != null)
            {
                context.Remove(applicationUserAEliminar);
                context.SaveChanges();
            }
        }
    }

    public List<ApplicationUser> ObtenerApplicationUsers()
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.ApplicationUsers.ToList();
        }
    }
}