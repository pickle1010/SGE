namespace SGE.Aplicacion;

public interface IExpendienteRepositorio
{
    void Agregar(Expediente expediente);
    void Eliminar(int id);
    void Modificar(Expediente expediente);
    Expediente ConsultarPorID(int id); //nunca va a ser null, puede venir vacío pero nunca null
    List<Expediente> ConsultarTodos();
}
