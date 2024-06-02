namespace YateMate.Aplicacion.Entidades;

public class TruequeConfirmado
{
    public int Id { get; set; } = Guid.NewGuid().GetHashCode();
    public int BienId { get; set; }
    public int PublicacionId { get; set; }
    public string UsuarioId { get; set; }
    
    public TruequeConfirmado(int bienId, int publicacionId, string usuarioId)
    {
        this.BienId = bienId;
        this.PublicacionId = publicacionId;
        this.UsuarioId = usuarioId;
    }

    public TruequeConfirmado()
    {
        
    }
}