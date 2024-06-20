namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioModificacion(IUsuarioRepositorio repo, UsuarioValidador validador, IServicioAutorizacion servicioAutorizacion, IServicioHashing servicioHashing)
{
    public void Ejecutar(Usuario usuario, int idUsuario, bool contraseñaCambiada)
    {
        if (idUsuario <= 0)
        {
            throw new ArgumentException("El Id del usuario debe ser mayor que 0", nameof(idUsuario));
        }
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioModificacion)){
            throw new AutorizacionException($"El usuario #{idUsuario} no tiene permiso para realizar modificaciones de usuarios");
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
