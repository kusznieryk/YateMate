using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace YateMate.Aplicacion.Entidades;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [MaxLength(100)]
    public string? Nombre { get; set; }
    [MaxLength(100)]
    public string? Apellido { get; set; }
    public DateTime? FechaNacimiento { get; set; }

    [MaxLength(20)] //le puse 20 por poner algo
    public string? Genero { get; set; }
    
    public int? Dni { get; set; } //ver si cambiar a string
    
    [MaxLength(100)]
    public string? Nacionalidad { get; set; }  //no se esto que tipo hacerlo
    
    public List<Embarcacion>? Embarcaciones { get; set; }
    public List<Bien>? Bienes { get; set; }
}