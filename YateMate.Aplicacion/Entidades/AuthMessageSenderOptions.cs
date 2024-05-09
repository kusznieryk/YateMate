namespace YateMate.Aplicacion.Entidades;

public class AuthMessageSenderOptions
{
    public string? EmailAuthKey { get; set; } //en el tutorial original usaba esto para la api, aca lo voy a usar para guardar la clave no segura

    public string? ActualEmail { get; set; } // aca guardo el mail, seteado por una e.v para no subir los datos a git
}