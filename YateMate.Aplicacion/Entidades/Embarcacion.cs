using System.ComponentModel.DataAnnotations;

namespace YateMate.Aplicacion.Entidades;

public class Embarcacion(string nombre, double eslora, double calado, string clienteId, string matricula)
{
    public int Id { get; set; } = Guid.NewGuid().GetHashCode();
    [MaxLength(50)]
    public string Nombre { get; set; } = nombre;
    
    [MaxLength(50)]
    public string ClienteId { get; set; } = clienteId;
    public double Eslora{ get; set; } = eslora;
    public double Calado { get; set; } = calado;
    [MaxLength(50)]
    public string Matricula { get; set; } = matricula;
}
