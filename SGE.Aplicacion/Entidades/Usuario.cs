namespace SGE.Aplicacion;

public class Usuario
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Email { get; set; }
    public string? Contraseña { get; set; }
    public List<Permiso> Permisos { get; set; }
    public bool EsAdmin { get; set; } = false;

    public Usuario()
    {
        Permisos = new List<Permiso>();
    }

    public override string ToString()
    {
        return $"(Id:{Id}) {Nombre}, {Apellido}, {Email}, {Contraseña}, {EsAdmin}";
    }
}
