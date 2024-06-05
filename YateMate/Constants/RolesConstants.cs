namespace YateMate.Constants;

public static class RolesConstants
{
    public const string Administrador = "Admin";

    public const string Empleado = "Empleado";

    public const string Cliente = "Cliente";
    
    public static readonly List<String> Roles = new List<string>() {Administrador, Empleado, Cliente};
}

