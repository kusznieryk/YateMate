namespace YateMate.Aplicacion.Entidades;

public class Reserva
{
    public int Id { get; set; } = Guid.NewGuid().GetHashCode();
    public int SubalquilerId { get; set; } 
    public string UsuarioId { get; set; } 
    public DateTime FechaInicio { get; set; } 
    public DateTime FechaFin { get; set; }

    public Reserva(int subalquilerId, string usuarioId, DateTime fechaInicio, DateTime fechaFin)
    {
        SubalquilerId = subalquilerId;
        UsuarioId = usuarioId;
        FechaInicio = fechaInicio;
        FechaFin = fechaFin;
    }

    public Reserva()
    {
        
    }
}