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

    public void ModificarApplicationUser(ApplicationUser user)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            var applicationUserAModificar = context.ApplicationUsers.FirstOrDefault(au => au.Id.Equals(user.Id));
            if (applicationUserAModificar != null)
            {
                applicationUserAModificar.Nombre = user.Nombre;
                applicationUserAModificar.Apellido = user.Apellido;
                applicationUserAModificar.FechaNacimiento = user.FechaNacimiento;
                applicationUserAModificar.Dni = user.Dni;
                applicationUserAModificar.Genero = user.Genero;
                applicationUserAModificar.Nacionalidad = user.Nacionalidad;
                
                context.SaveChanges();
            }
        }
    }

    public List<ApplicationUser> ObtenerEmpleados()
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            var empleados = context.ApplicationUsers
                .Join(
                    context.UserRoles,
                    user => user.Id,
                    userRole => userRole.UserId,
                    (user, userRole) => new { User = user, UserRole = userRole }
                )
                .Join(
                    context.Roles,
                    userUserRole => userUserRole.UserRole.RoleId,
                    role => role.Id,
                    (userUserRole, role) => new { userUserRole.User, Role = role }
                )
                .Where(x => x.Role.Name == "Empleado")
                .Select(x => x.User)
                .ToList();
            //como no aprobe dbd la consulta la hizo una ia
            return empleados;

        }
    }
    
    public List<ApplicationUser> ObtenerClientes()
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            var clientes = context.ApplicationUsers
                .Join(
                    context.UserRoles,
                    user => user.Id,
                    userRole => userRole.UserId,
                    (user, userRole) => new { User = user, UserRole = userRole }
                )
                .Join(
                    context.Roles,
                    userUserRole => userUserRole.UserRole.RoleId,
                    role => role.Id,
                    (userUserRole, role) => new { userUserRole.User, Role = role }
                )
                .Where(x => x.Role.Name == "Cliente")
                .Select(x => x.User)
                .ToList();
            return clientes;

        }
    }

    public ApplicationUser? ObtenerApplicationUser(string id)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.ApplicationUsers.Find(id);
        }
    }

    public List<ApplicationUser> ObtenerClientesExcepto(string id)
    {
        return ObtenerClientes().Where(c => c.Id != id).ToList();
    }

    public List<ApplicationUser> ObtenerContactosDe(string id)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.MensajesChats
                .Where(m => m.FromUserId == id || m.ToUserId == id)
                .Select(m => new { UserId = m.FromUserId == id ? m.ToUserId : m.FromUserId })
                .Distinct()
                .Select(m => context.Users.FirstOrDefault(u => u.Id == m.UserId))
                .Where(u => u != null)
                .ToList()!;
        }
        
        

    }
}