namespace SGE.Aplicacion;

public class CasoDeUsoExpedienteConsultarTodos(IExpendienteRepositorio repo)
{
    public List<Expediente> Ejecutar()
    {   
        return repo.ConsultarTodos();
    }
}
