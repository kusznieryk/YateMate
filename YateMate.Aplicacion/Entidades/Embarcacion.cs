using System.ComponentModel.DataAnnotations;

namespace YateMate.Aplicacion.Entidades;

public class Embarcacion(string nombre, double eslora, double calado, string clienteId)
{
    
    public int Id { get; set; } = Guid.NewGuid().GetHashCode();
    [MaxLength(50)]
    public string Nombre { get; set; } = nombre;

    public string ClienteId { get; set; } = clienteId;
    public double Eslora{ get; set; } = eslora;
    public double Calado { get; set; } = calado;
}