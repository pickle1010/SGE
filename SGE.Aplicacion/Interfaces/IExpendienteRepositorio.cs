namespace SGE.Aplicacion;

public interface IExpendienteRepositorio
{
    void Agregar(Expediente expediente);
    Expediente Eliminar(int id);
    void Modificar(Expediente expediente);
    Expediente ConsultarPorID(int id);
    List<Expediente> ConsultarTodos();
}
