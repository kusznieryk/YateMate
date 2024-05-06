using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YateMate.Aplicacion.Entidades;

namespace YateMate.Repositorio;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public ApplicationDbContext(){}
    public DbSet<Amarra> Amarras { get; set; }
    public DbSet<Bien> Bienes { get; set; }
    public DbSet<Embarcacion> Embarcaciones { get; set; }
    public DbSet<Mensaje> Mensajes { get; set; }
    public DbSet<Oferta> Ofertas { get; set; }
    public DbSet<Publicacion> Publicaciones { get; set; }
    public DbSet<Subalquiler> Subalquileres { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }


    
}