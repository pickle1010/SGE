namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultaTodos(IExpendienteRepositorio repo)
{
    public List<Expediente> Ejecutar()
    {   
        return repo.ConsultarTodos();
    }
}
