using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace YateMate.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [MaxLength(100)]
    public string? Nombre { get; set; }
    [MaxLength(100)]
    public string? Apellido { get; set; }
    public DateTime? FechaNacimiento { get; set; }

    [MaxLength(9)] //Masculino = 9 letras, sacar esto
    public string? Genero { get; set; }
    
    public int? Dni { get; set; }
    
    [MaxLength(100)]
    public string? Nacionalidad { get; set; }  //no se esto que tipo hacerlo
}