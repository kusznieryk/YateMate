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
        modelBuilder.Entity<Embarcacion>()
            .Property(p => p.Bandera)
            .HasConversion(
                v => v.ToString(),
                v => (Nacionalidad)Enum.Parse(typeof(Nacionalidad), v));
        
        
        modelBuilder.Entity<Amarra>()
            .Property(p => p.Tamanio)
            .HasConversion(
                v => v.ToString(),
                v => (TamanioEstandar)Enum.Parse(typeof(TamanioEstandar), v));
        modelBuilder.Entity<MensajeChat>(entity =>
        {
            entity.HasOne(d => d.FromUser)
                .WithMany(p => p.ChatMessagesFromUsers)
                .HasForeignKey(d => d.FromUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            entity.HasOne(d => d.ToUser)
                .WithMany(p => p.ChatMessagesToUsers)
                .HasForeignKey(d => d.ToUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
        //no se si les parece hacer que al borrar pongamos el id en null, no se como hacer lo de borrar y ponerlo en otra tabla
    }

#nullable disable
    //public DbSet<Amarra> Amarras { get; set; }
    public DbSet<Bien> Bienes { get; set; }
    public DbSet<Embarcacion> Embarcaciones { get; set; }
    public DbSet<MensajeChat> MensajesChats { get; set; }
    public DbSet<Oferta> Ofertas { get; set; }
    public DbSet<Amarra> Amarras { get; set; }
    public DbSet<Publicacion> Publicaciones { get; set; } 
    public DbSet<TruequeConfirmado> TruequesConfirmados { get; set; }
    public DbSet<Subalquiler> Subalquileres { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    #nullable enable
    
    
}