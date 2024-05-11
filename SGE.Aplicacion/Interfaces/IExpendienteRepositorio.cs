namespace SGE.Aplicacion;

public interface IExpendienteRepositorio
{
    void Agregar(Expediente expediente);
    void Eliminar(int id);
    void Modificar(Expediente expediente);
    // void ConsultarPorID(int id);
    List<Expediente> ConsultarTodos();
}
