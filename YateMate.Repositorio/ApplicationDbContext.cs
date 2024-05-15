using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YateMate.Aplicacion.Entidades;

namespace YateMate.Repositorio;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public static ApplicationDbContext CrearContexto()
    {
        var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite("DataSource=../YateMate.Repositorio/Data/app.db;Cache=Shared")
            //.EnableDetailedErrors(detailedErrorsEnabled:true) //el nombre lo explica
            .Options;
        
        return new ApplicationDbContext(contextOptions);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ApplicationUser>()
            .Property(p => p.Genero)
            .HasConversion(
                v => v.ToString(),
                v => (Genero)Enum.Parse(typeof(Genero), v));
        modelBuilder.Entity<ApplicationUser>()
            .Property(p => p.Nacionalidad)
            .HasConversion(
                v => v.ToString(),
            v => (Nacionalidad)Enum.Parse(typeof(Nacionalidad), v));
    }

#nullable disable
    //public DbSet<Amarra> Amarras { get; set; }
    public DbSet<Bien> Bienes { get; set; }
    public DbSet<Embarcacion> Embarcaciones { get; set; }
    //public DbSet<Mensaje> Mensajes { get; set; }
    //public DbSet<Oferta> Ofertas { get; set; }
    public DbSet<Publicacion> Publicaciones { get; set; }
    //public DbSet<Subalquiler> Subalquileres { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    #nullable enable
    
    
}