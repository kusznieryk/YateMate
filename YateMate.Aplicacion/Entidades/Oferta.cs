namespace YateMate.Aplicacion.Entidades;

public class Oferta
{
    public int Id { get; set; } = Guid.NewGuid().GetHashCode();
    public Bien Bien { get; set; } // no se si deberia tener un bien o el id del bien y obtenerlo con el usecase
    public int PublicacionId { get; set; }

    public Oferta(Bien bien, int publicacionId)
    {
        this.Bien = bien;
        this.PublicacionId = publicacionId;
    }
}