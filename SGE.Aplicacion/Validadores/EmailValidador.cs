namespace SGE.Aplicacion;
using System.Text.RegularExpressions;
public class EmailValidador
{
    public bool Validar(string? email, out string mensajeError)
    {
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(email))
        {
            mensajeError += "Email no puede estar vacío\n";
        }
        else
        {
            try
            {
                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
                {
                    mensajeError += "Email no tiene el formato correcto.\n";
                }
            }
            catch (RegexMatchTimeoutException)
            {
                throw new RegexMatchTimeoutException("Validacion del email excedió el intervalo de tiempo necesario.\n");
            }
        }
        return (mensajeError == "");
    }
}
