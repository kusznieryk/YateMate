using System.ComponentModel.DataAnnotations;

namespace YateMate.Aplicacion.Entidades;

public class Amarra
{
    public int Id { get; set; } = Guid.NewGuid().GetHashCode();
    public double Precio { get; set; }
    public TamanioEstandar Tamanio { get; set; }
    public bool Borrado { get; set; } = false;
    [MaxLength(60)] public string Ubicacion { get; set; } = "";
    public string? UsuarioId { get; set; } = "";
}