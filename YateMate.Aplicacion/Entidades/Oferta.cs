namespace YateMate.Aplicacion.Entidades;

public class Oferta
{
    public int Id { get; set; } = Guid.NewGuid().GetHashCode();
    public int BienId { get; set; } // no se si deberia tener un bien o el id del bien y obtenerlo con el usecase
    public int PublicacionId { get; set; }
    public string UsuarioId { get; set; }
    public bool Acordado { get; set; }
    public Oferta(int bienId, int publicacionId, string usuarioId)
    {
        this.BienId = bienId;
        this.PublicacionId = publicacionId;
        this.UsuarioId = usuarioId;
    }

    public Oferta()
    {
        
    }
}