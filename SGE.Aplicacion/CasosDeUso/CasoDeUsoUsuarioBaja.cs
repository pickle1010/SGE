namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioBaja(IUsuarioRepositorio repo, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(int idUsuarioBorrado, int idUsuario)
    {
        if (idUsuario <= 0)
        {
            throw new ArgumentException("El Id del usuario debe ser mayor que 0", nameof(idUsuario));
        }
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.UsuarioBaja))
        {
            throw new AutorizacionException($"El usuario #{idUsuario} no tiene permiso para realizar bajas de usuarios");
        }
        repo.Eliminar(idUsuarioBorrado);
    }
}
