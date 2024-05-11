namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteModificacion(IExpendienteRepositorio repo, ExpedienteValidador validador, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(Expediente expediente, int idUsuario)
    {
        if (idUsuario <= 0)
        {
            throw new ArgumentException("El Id del usuario debe ser mayor que 0", nameof(idUsuario));
        }
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteModificacion)){
            throw new AutorizacionException($"El usuario #{idUsuario} no tiene permiso para realizar modificaciones de expedientes");
        }
        if (!validador.Validar(expediente, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        expediente.FechaHoraUltimaModificacion = DateTime.Now;
        expediente.IdUsuarioUltimaModificacion = idUsuario;
        repo.Modificar(expediente);
    }
}
