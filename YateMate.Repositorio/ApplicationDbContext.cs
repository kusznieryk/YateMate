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
    public DbSet<Embarcacion> Embarcaciones;
    
    #nullable enable
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=../YateMate.Repositorio/Data/app.db;Cache=Shared");
    }
    
}