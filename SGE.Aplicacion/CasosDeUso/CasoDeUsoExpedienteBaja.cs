namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpendienteRepositorio repoExpediente, ITramiteRepositorio repoTramite, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(int expedienteId, int idUsuario)
    {
        if (idUsuario <= 0)
        {
            throw new ArgumentException("El Id del usuario debe ser mayor que 0", nameof(idUsuario));
        }
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteBaja))
        {
            throw new AutorizacionException($"El usuario #{idUsuario} no tiene permiso para realizar bajas de expedientes");
        }
        if(repoExpediente.ConsultarPorID(expedienteId) == null){
            throw new RepositorioException($"No existe expediente que tenga el id #{expedienteId}");
        }
        foreach (Tramite tramite in repoTramite.ConsultarPorExpediente(expedienteId))
        {
            repoTramite.Eliminar(expedienteId);
        }
        repoExpediente.Eliminar(expedienteId);
    }
}
