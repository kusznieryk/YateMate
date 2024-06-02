using YateMate.Aplicacion.Entidades;
namespace YateMate.Aplicacion.Interfaces;

public interface IRepositorioOferta
{
    List<Publicacion> ListarTruequesDisponibles();
    void HacerOferta(Oferta oferta);
    void EliminarOferta(int id);
    List<Oferta> ListarOfertasDe(int publicacionId);
    List<Oferta> ListarOfertasHechas(string userId);
    Publicacion ObtenerPublicacionDe(int id);
    void EliminarOfertasDe(int idPublicacion);
    void EliminarOfertasDelBien(int idBien);
    List<Oferta> ObtenerTruequesAcordados();


}