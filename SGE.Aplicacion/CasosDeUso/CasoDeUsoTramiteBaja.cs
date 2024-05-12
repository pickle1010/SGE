namespace SGE.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repo, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(int idTramite, int idUsuario)
    {
        if (idUsuario <= 0)
        {
            throw new ArgumentException("El Id del usuario debe ser mayor que 0", nameof(idUsuario));
        }
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteAlta)){
            throw new AutorizacionException($"El usuario #{idUsuario} no tiene permiso para realizar altas de Tramite");
        }
        if(repo.ConsultarPorId(idTramite) == null){
            throw new RepositorioException($"No existe tramite que tenga el id #{idTramite}");
        }
        repo.Eliminar(idUsuario);
    }
}
