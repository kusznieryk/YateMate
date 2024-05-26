using Microsoft.EntityFrameworkCore;
using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;

namespace YateMate.Repositorio;

public class RepositorioMensaje : IRepositorioMensaje
{
    public void AgregarMensaje(MensajeChat message)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            context.Add(message);
            context.SaveChanges();
        }
    }

    public List<MensajeChat> ObtenerMensajesEntre(string contact1Id, string contact2Id)
    {
        using (var context = ApplicationDbContext.CrearContexto())
        {
            return context.MensajesChats
                .Where(mensaje => (mensaje.FromUserId == contact1Id && mensaje.ToUserId ==contact2Id) ||(mensaje.FromUserId == contact2Id && mensaje.ToUserId ==contact1Id ))
                .OrderBy(msg => msg.CreatedDate)
                .Include(a => a.FromUser)
                .Include(a => a.ToUser)
                .ToList();
        }
    }
}