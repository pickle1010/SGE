namespace SGE.Aplicacion;

public class CasoDeUsoTramiteAlta(ITramiteRepositorio repo, TramiteValidador validador, IServicioAutorizacion servicioAutorizacion, IServicioActualizacionEstado servicioActualizacionEstado)
{
    public void Ejecutar(Tramite tramite, int idUsuario)
    {
        if (idUsuario <= 0)
        {
            throw new ArgumentException("El Id del usuario debe ser mayor que 0", nameof(idUsuario));
        }
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteAlta)){
            throw new AutorizacionException($"El usuario #{idUsuario} no tiene permiso para realizar altas de Tramite");
        }
        if (!validador.Validar(tramite, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        tramite.FechaHoraCreacion = DateTime.Now;
        tramite.FechaHoraUltimaModificacion = DateTime.Now;
        tramite.IdUsuarioUltimaModificacion = idUsuario; //Para tener control del usuario que realizó el alta del trámite
        repo.Agregar(tramite);
        servicioActualizacionEstado.ActualizarEstado(tramite.ExpedienteId);
    }
}
