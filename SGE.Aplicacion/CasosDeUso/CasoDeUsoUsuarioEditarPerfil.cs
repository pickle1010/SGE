namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioEditarPerfil(IUsuarioRepositorio repo, UsuarioValidador validador, IServicioAutorizacion servicioAutorizacion, IServicioHashing servicioHashing)
{
    public void Ejecutar(Usuario usuario, int idUsuario, bool contraseñaCambiada)
    {
        if (idUsuario <= 0)
        {
            throw new ArgumentException("El Id del usuario debe ser mayor que 0", nameof(idUsuario));
        }
        if (usuario.Id != idUsuario){
            throw new AutorizacionException($"El usuario #{idUsuario} no tiene permiso para editar otros perfiles");
        }
        if (!validador.Validar(usuario, out string mensajeError, contraseñaCambiada))
        {
            throw new ValidacionException(mensajeError);
        }
        if (contraseñaCambiada)
        {
            usuario.Contraseña = servicioHashing.CalcularHash(usuario.Contraseña);
        }
        repo.Modificar(usuario);
    }
}
