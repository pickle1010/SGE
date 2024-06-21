namespace SGE.Aplicacion;

public interface IServicioGestionDeSesion
{
    void IniciarSesion(Usuario usuario);
    void CerrarSesion();
    Usuario? ObtenerUsuario();
}
