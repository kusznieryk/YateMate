using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace YateMate.Aplicacion.Entidades;

public class Bien
{
    public int Id { get; set; } = Guid.NewGuid().GetHashCode();
    [MaxLength(50)] public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string UsuarioId { get; set; }
    public string Imagen { get; set; }
    public bool EstaEliminado { get; set; }

    public Bien(string nombre, string descripcion, string imagen, string usuarioId)
    {
        this.Nombre = nombre;
        this.Descripcion = descripcion;
        this.Imagen = imagen;
        this.UsuarioId = usuarioId;
    }
}