namespace SGE.Aplicacion;
using System.Text.RegularExpressions;

public class UsuarioValidador
{
    public bool Validar(Usuario usuario, out string mensajeError)
    {
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(usuario.Nombre))
        {
            mensajeError += "Nombre del usuario no puede estar vacío.\n";
        }
        else if (Regex.IsMatch(usuario.Nombre, @"^[a-zA-Z]+$"))
        {
            mensajeError += "Nombre del usuario debe tener solo letras.\n";
        }
        if (string.IsNullOrWhiteSpace(usuario.Apellido))
        {
            mensajeError += "Apellido del usuario no puede estar vacío.\n";
        }
        else if (Regex.IsMatch(usuario.Nombre, @"^[a-zA-Z]+$"))
        {
            mensajeError += "Apellido del usuario debe tener solo letras.\n";
        }
        if (string.IsNullOrWhiteSpace(usuario.Email))
        {
            mensajeError += "Email del usuario no puede estar vacío\n";
        }
        else
        {
            try
            {
                if (Regex.IsMatch(usuario.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
                {
                    mensajeError += "Email del usuario no tiene el formato correcto.\n";
                }
            }
            catch (RegexMatchTimeoutException)
            {
                throw new RegexMatchTimeoutException("Validacion del email del usuario excedió el intervalo de tiempo necesario.\n");
            }
        }
        if (string.IsNullOrWhiteSpace(usuario.Contraseña))
        {
            mensajeError += "Contraseña del usuario no puede estar vacía.\n";
        }
        else if (usuario.Contraseña.Length < 6)
        {
            mensajeError += "Contraseña del usuario debe tener 6 caracteres como mínimo.\n";
        }
        return (mensajeError == "");
    }
}
