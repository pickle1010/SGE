namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaPorID(IExpendienteRepositorio repoExpediente, ITramiteRepositorio repoTramite)
{
    public Expediente Ejecutar(int expedienteId)
    {
        Expediente expediente = repoExpediente.ConsultarPorID(expedienteId);
        expediente.Tramites = repoTramite.ConsultarPorExpediente(expedienteId);
        return expediente;
    }
}
