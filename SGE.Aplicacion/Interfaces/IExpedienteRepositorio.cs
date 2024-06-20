namespace SGE.Aplicacion;

public interface IExpedienteRepositorio
{
    void Agregar(Expediente expediente);
    Expediente Eliminar(int id);
    void Modificar(Expediente expediente);
    Expediente ConsultarPorID(int id);
    List<Expediente> ConsultarTodos();
}
