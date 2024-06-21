namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioRegistrar(IUsuarioRepositorio repo, UsuarioValidador validador, IServicioHashing servicioHashing)
{
    public void Ejecutar(Usuario usuario)
    {
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
