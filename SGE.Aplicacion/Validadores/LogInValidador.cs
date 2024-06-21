namespace SGE.Aplicacion;

public class LogInValidador(EmailValidador emailValidador)
{
    public bool Validar(string? email, string contraseña, out string mensajeError)
    {
        mensajeError = "";
        if(!emailValidador.Validar(email, out string emailMensajeError))
        {
            mensajeError += emailMensajeError;
        }
        if (string.IsNullOrWhiteSpace(contraseña))
        {
            mensajeError += "Contraseña no puede estar vacía.\n";
        }
        return (mensajeError == "");
    }
}
