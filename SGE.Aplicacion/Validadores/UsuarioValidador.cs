namespace SGE.Aplicacion;
using System.Text.RegularExpressions;

public class UsuarioValidador(EmailValidador emailValidador)
{
    public bool Validar(Usuario usuario, out string mensajeError, bool validarFormatoContraseña)
    {
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(usuario.Nombre))
        {
            mensajeError += "Nombre del usuario no puede estar vacío.\n";
        }
        else if (!Regex.IsMatch(usuario.Nombre, @"^[a-zA-Z]+$"))
        {
            mensajeError += "Nombre del usuario debe tener solo letras.\n";
        }
        if (string.IsNullOrWhiteSpace(usuario.Apellido))
        {
            mensajeError += "Apellido del usuario no puede estar vacío.\n";
        }
        else if (!Regex.IsMatch(usuario.Apellido, @"^[a-zA-Z]+$"))
        {
            mensajeError += "Apellido del usuario debe tener solo letras.\n";
        }
        if(!emailValidador.Validar(usuario.Email, out string emailMensajeError))
        {
            mensajeError += emailMensajeError;
        }
        if (string.IsNullOrWhiteSpace(usuario.Contraseña))
        {
            mensajeError += "Contraseña del usuario no puede estar vacía.\n";
        }
        else if(validarFormatoContraseña && usuario.Contraseña.Length < 6)
        {
            mensajeError += "Contraseña del usuario debe tener 6 caracteres como mínimo.\n";
        }
        return (mensajeError == "");
    }
}
