namespace YateMate.Aplicacion.Entidades;

public class Subalquiler(DateTime fechaInicio, DateTime fechaFin, string idDuenio, string idAmarra)
{
    public int Id { get; set; } = Guid.NewGuid().GetHashCode();
    public DateTime FechaInicio { get; set; } = fechaInicio;
    public DateTime FechaFin { get; set; } = fechaFin;
    public string IdDuenio { get; set; } = idDuenio;
    public string IdAmarra { get; set; } = idAmarra;
    public string? IdAlquilante { get; set; } 
    public bool EstaEliminado { get; set; } = false;
}