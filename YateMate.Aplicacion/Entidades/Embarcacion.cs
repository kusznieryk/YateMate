namespace YateMate.Aplicacion.Entidades;

public class Embarcacion
{
    public Embarcacion(string? nombre, double eslora, double calado)
    {
        Nombre = nombre;
        Eslora = eslora;
        Calado = calado;
        this.Id = Guid.NewGuid().GetHashCode();
    }
    public int Id { get; }
    public string? Nombre { get; set; }

    public double Eslora{ get; set; }
    public double Calado { get; set; }
}