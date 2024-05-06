using System.Net.Mime;

namespace YateMate.Aplicacion.Entidades;
using System.Drawing;
public class Publicacion
{
    public byte[] Image { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }

    public Publicacion(byte[] image, string titulo, string descripcion)
    {
        Image = image;
        Titulo = titulo;
        Descripcion = descripcion;
    }
}