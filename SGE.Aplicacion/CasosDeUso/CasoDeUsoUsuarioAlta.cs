namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioAlta(IUsuarioRepositorio repo, UsuarioValidador validador, IServicioAutorizacion servicioAutorizacion, IServicioHashing servicioHashing)
{
    public void Ejecutar(Usuario usuario, int idUsuario)
    {
        if (idUsuario <= 0)
        {
            throw new ArgumentException("El Id del usuario debe ser mayor que 0", nameof(idUsuario));
        }
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioAlta)){
            throw new AutorizacionException($"El usuario #{idUsuario} no tiene permiso para realizar altas de Usuario");
        }
        if (!validador.Validar(usuario, out string mensajeError, true))
        {
            throw new ValidacionException(mensajeError);
        }
        usuario.Contraseña = servicioHashing.CalcularHash(usuario.Contraseña);
        if(usuario.EsAdmin)
        {
            usuario.Permisos = new List<Permiso>(Enum.GetValues<Permiso>());
        }
        repo.Agregar(usuario);
    }
}
