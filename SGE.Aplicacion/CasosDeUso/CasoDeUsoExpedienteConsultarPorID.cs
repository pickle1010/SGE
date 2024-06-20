namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultarPorID(IExpedienteRepositorio repoExpediente, ITramiteRepositorio repoTramite)
{
    public Expediente Ejecutar(int expedienteId)
    {
        Expediente expediente = repoExpediente.ConsultarPorID(expedienteId);
        expediente.Tramites = repoTramite.ConsultarPorExpediente(expedienteId);
        return expediente;
    }
}
