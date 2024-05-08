using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace YateMate.Aplicacion.Entidades;
using System.Drawing;
public class Publicacion(byte[] image, string titulo, string descripcion, int embarcacionId)
{
    public int Id { get; set; } = Guid.NewGuid().GetHashCode();
    public int EmbarcacionId { get; set; } = embarcacionId;

    public byte[] Image { get; set; } = image;

    [ MaxLength(50) ]
    public string Titulo { get; set; } = titulo;

    public string Descripcion { get; set; } = descripcion;
}