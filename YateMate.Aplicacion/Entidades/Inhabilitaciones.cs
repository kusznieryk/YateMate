namespace YateMate.Aplicacion.Entidades;

public class Inhabilitaciones(bool duenioInhibido, bool bienInhabilitado, bool noEsDuenioDe)
{
    public bool DuenioInhibido { get; } = duenioInhibido;
    public bool BienInhabilitado { get; } = bienInhabilitado;
    public bool NoEsDuenioDe { get; } = noEsDuenioDe;
}