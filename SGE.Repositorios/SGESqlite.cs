namespace SGE.Repositorios;

using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;
public class SGESqlite 
{
    public static void Inicializar(){
        using var context = new SGEContext();
        if(context.Database.EnsureCreated()){
            var connection = context.Database.GetDbConnection();
            connection.Open();
            using (var command = connection.CreateCommand()){
                command.CommandText = "PRAGMA journal_mode=DELETE;";
                command.ExecuteNonQuery();
            }
            Console.WriteLine("La base de datos ha sido creada exitosamente");
        }
        else
        {
            Console.WriteLine("La base de datos ya fue creada previamente");
            IUsuarioRepositorio repo = new RepositorioUsuario();
            Usuario u = new Usuario();
            u.Nombre = "Lisandro";
            u.Apellido = "Martinez";
            u.Email = "email@ejemplo.com";
            u.Contraseña = "contraseña";
            repo.Agregar(u);
        }
    }
}
