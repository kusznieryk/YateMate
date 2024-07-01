namespace YateMate.Aplicacion.Entidades;

public class Reserva(int subalquilerId, string usuarioId, DateTime fechaInicio, DateTime fechaFin)
{
    public int Id { get; set; } = Guid.NewGuid().GetHashCode();
    public int SubalquilerId { get; set; } = subalquilerId;
    public string UsuarioId { get; set; } = usuarioId;
    public DateTime FechaInicio { get; set; } = fechaInicio;
    public DateTime FechaFin { get; set; } = fechaFin;

}