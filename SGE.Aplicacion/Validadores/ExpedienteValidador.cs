namespace SGE.Aplicacion;

public class ExpedienteValidador
{
    public bool Validar(Expediente expediente, out string mensajeError)
    {
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(expediente.Caratula))
        {
            mensajeError = "Carátula del expediente no puede estar vacía.\n";
        }
        return (mensajeError == "");
    }
}
