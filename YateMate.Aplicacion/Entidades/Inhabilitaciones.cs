namespace YateMate.Aplicacion.Entidades;

public class Inhabilitaciones(bool duenioInhibido, bool bienInhabilitado, bool noEsDuenioDe)
{
    public bool DuenioInhibido { get; } = duenioInhibido;
    public bool BienInhabilitado { get; } = bienInhabilitado;
    public bool NoEsDuenioDe { get; } = noEsDuenioDe;


    public bool AlgunError()
    {
        return NoEsDuenioDe || DuenioInhibido || BienInhabilitado;
    }
    
    public string MensajeError()
    {

        if (DuenioInhibido) return MensajeErrorDuenioInhibido();
        if (NoEsDuenioDe) return MensajeErrorNoEsDuenioDe();
        if (BienInhabilitado) return MensajeErrorBienInhabilitado();
        
        return "no tiene ninguna inhabilitacion";
    }

    public string MensajeErrorDuenioInhibido()
    {
        return DuenioInhibido ? "está inhibido" : "";
    }
    
    public string MensajeErrorBienInhabilitado()
    {
        return BienInhabilitado ? "tiene su bien inhabilitado" : "";
    }
    
    public string MensajeErrorNoEsDuenioDe()
    {
        return NoEsDuenioDe ? "no es dueño del bien" : "";
    }
}