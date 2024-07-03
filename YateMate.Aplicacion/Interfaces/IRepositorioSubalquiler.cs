using YateMate.Aplicacion.Entidades;

namespace YateMate.Aplicacion.Interfaces;

public interface IRepositorioSubalquiler
{
    public void AgregarSubalquiler(Subalquiler subalquiler);
    public void ModificarSubalquiler(Subalquiler subalquiler);
    public void EliminarSubalquiler(int idSubalquiler);
    public Subalquiler? ObtenerSubalquiler(int id);
    public List<Subalquiler> ObtenerSubalquileres();
    public List<Subalquiler> ObtenerSubalquileresDe(string idDuenio);
    public List<Subalquiler> ObtenerSubalquileresEntre(DateTime fechaI, DateTime fechaF);
    public List<Subalquiler> ObtenerSubalquileresVigentes();
    public List<Subalquiler> ObtenerSubalquileresDeLaAmarra(int idAmarra);
    public ApplicationUser ObtenerDuenioSubalquiler(string id);
    public List<(DateTime Start, DateTime End)> ObtenerFechasReservadas(int idAmarra);
}