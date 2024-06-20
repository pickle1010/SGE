using System.ComponentModel.DataAnnotations;

namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, ExpedienteValidador validador, IServicioAutorizacion servicioAutorizacion)
{
    public void Ejecutar(Expediente expediente, int idUsuario)
    {
        if (idUsuario <= 0)
        {
            throw new ArgumentException("El Id del usuario debe ser mayor que 0", nameof(idUsuario));
        }
        if (!servicioAutorizacion.PoseeElPermiso(idUsuario, Permiso.ExpedienteAlta)){
            throw new AutorizacionException($"El usuario #{idUsuario} no tiene permiso para realizar altas de expedientes");
        }
        if (!validador.Validar(expediente, out string mensajeError))
        {
            throw new ValidacionException(mensajeError);
        }
        expediente.FechaHoraCreacion = DateTime.Now;
        expediente.FechaHoraUltimaModificacion = DateTime.Now;
        expediente.IdUsuarioUltimaModificacion = idUsuario; //Para tener control del usuario que realizó el alta del expediente
        repo.Agregar(expediente);
    }
}
