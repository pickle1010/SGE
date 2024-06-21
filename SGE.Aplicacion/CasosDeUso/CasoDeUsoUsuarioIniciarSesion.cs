namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioIniciarSesion(IUsuarioRepositorio repo, LogInValidador validador, IServicioGestionDeSesion servicioGestionDeSesion, IServicioHashing servicioHashing)
{
    public Usuario? Ejecutar(string email, string contraseña)
    {
        if (!validador.Validar(email, contraseña, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        Usuario? usuario = null;
        try
        {
            usuario = repo.ConsultarPorEmail(email);
            if(!servicioHashing.Verificar(usuario.Contraseña, contraseña))
            {
                throw new LogInException("El email o la contraseña son incorrectos");
            }
        }
        catch (RepositorioException)
        {
            throw new LogInException("El email o la contraseña son incorrectos");
        }
        servicioGestionDeSesion.IniciarSesion(usuario);
        return usuario;
    }
}
