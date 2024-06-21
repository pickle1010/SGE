namespace SGE.Aplicacion;

public class ServicioGestionDeSesion() : IServicioGestionDeSesion
{
    public Usuario? UsuarioActual { get; set; }

    public void IniciarSesion(Usuario usuario)
    {
        UsuarioActual = usuario;
    }

    public void CerrarSesion()
    {
        UsuarioActual = null;
    }

    public Usuario? ObtenerUsuario()
    {
        return UsuarioActual;
    }
}
