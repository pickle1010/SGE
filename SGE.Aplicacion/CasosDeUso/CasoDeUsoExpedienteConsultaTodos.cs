namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos(IExpendienteRepositorio repo)
{
    public List<Expediente> Ejecutar(Expediente expediente)
    {   
        return repo.ConsultarTodos();
    }
}
