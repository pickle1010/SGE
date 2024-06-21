namespace SGE.Aplicacion;

public class ServicioAutorizacion(IUsuarioRepositorio repoUsuario): IServicioAutorizacion
{
    
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso)
    {
        var usuario = repoUsuario.ConsultarPorID(IdUsuario);
        if (usuario == null || usuario.Permisos == null)
            {
                return false;
            }

        return usuario.Permisos.Contains(permiso);
    }
}
