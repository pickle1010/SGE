namespace SGE.Aplicacion;

public class CasoDeUsoTramiteModificacion(ITramiteRepositorio repo, TramiteValidador validador, IServicioAutorizacion servicioAutorizacion, IServicioActualizacionEstado servicioActualizacion, IExpedienteRepositorio repoExpediente)
{
    public void Ejecutar(Tramite tramite, int idUsuario)
    {
        if (idUsuario <= 0)
        {
            throw new ArgumentException("El Id del usuario debe ser mayor que 0", nameof(idUsuario));
        }
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.TramiteModificacion)){
            throw new AutorizacionException($"El usuario #{idUsuario} no tiene permiso para realizar modificaciones de Tramite");
        }
        if (!validador.Validar(tramite, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        Expediente expedienteBuscado = repoExpediente.ConsultarPorID(tramite.ExpedienteId);
        tramite.FechaHoraUltimaModificacion = DateTime.Now;
        tramite.IdUsuarioUltimaModificacion = idUsuario;
        repo.Modificar(tramite);
        servicioActualizacion.ActualizarEstado(tramite.ExpedienteId);
    }
}

