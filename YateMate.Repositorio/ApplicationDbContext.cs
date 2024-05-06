using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YateMate.Aplicacion.Entidades;

namespace YateMate.Repositorio;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public static ApplicationDbContext CrearContexto()
    {
        DbContextOptions<ApplicationDbContext> contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().Options;
        return new ApplicationDbContext(contextOptions);
    }
    #nullable disable
    public DbSet<Amarra> Amarras { get; set; }
    public DbSet<Bien> Bienes { get; set; }
    public DbSet<Embarcacion> Embarcaciones { get; set; }
    public DbSet<Mensaje> Mensajes { get; set; }
    public DbSet<Oferta> Ofertas { get; set; }
    public DbSet<Publicacion> Publicaciones { get; set; }
    public DbSet<Subalquiler> Subalquileres { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    #nullable enable

}