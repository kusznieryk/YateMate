namespace YateMate.Aplicacion.Entidades;

public class Subalquiler(DateTime fechaInicio, DateTime fechaFin, string idDuenio, int idAmarra)
{
    public int Id { get; set; } = Guid.NewGuid().GetHashCode();
    public DateTime FechaInicio { get; set; } = fechaInicio;
    public DateTime FechaFin { get; set; } = fechaFin;
    public string IdDuenio { get; set; } = idDuenio;
    public int IdAmarra { get; set; } = idAmarra;
    public bool EstaEliminado { get; set; } = false;
    public List<Reserva>? Reservas { get; set; } //esto es de manu pero yo no hice ninguna migracion con este atributo
}