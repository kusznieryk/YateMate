namespace YateMate.Aplicacion.Entidades;

public class TruequeConfirmado
{
    public int Id { get; set; } = Guid.NewGuid().GetHashCode();
    public int BienId { get; set; }
    public int PublicacionId { get; set; }
    
    public TruequeConfirmado(int bienId, int publicacionId)
    {
        this.BienId = bienId;
        this.PublicacionId = publicacionId;
    }

    public TruequeConfirmado()
    {
        
    }
}