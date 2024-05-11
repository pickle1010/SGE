namespace SGE.Aplicacion;

public class TramiteValidador
{
    public bool Validar(Tramite tramite, out string mensajeError)
    {
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(tramite.Contenido))
        {
            mensajeError = "Contenido del trámite no puede estar vacío.\n";
        }
        return (mensajeError == "");
    }
}
