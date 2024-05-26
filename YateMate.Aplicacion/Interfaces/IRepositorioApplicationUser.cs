using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.Interfaces;

public interface IRepositorioApplicationUser
{
    void EliminarApplicationUser(string id);
    List<ApplicationUser> ObtenerApplicationUsers();

    void ModificarApplicationUser(ApplicationUser user);

    List<ApplicationUser> ObtenerEmpleados(); //podria recibir el nombre del rol, lo hardcodeo como Empleado adentro
    List<ApplicationUser> ObtenerClientes();

    ApplicationUser? ObtenerApplicationUser(string id);
    
    List<ApplicationUser> ObtenerClientesExcepto(string id);

    List<ApplicationUser> ObtenerContactosDe(string id);
}