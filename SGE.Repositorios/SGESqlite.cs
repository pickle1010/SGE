namespace SGE.Repositorios;
using SGE.Aplicacion;
public class SGESqlite 
{
    public static void Inicializar(){
        using var context = new SGEContext();
        if(context.Database.EnsureCreated()){
            Console.WriteLine("La base de datos ha sido creada exitosamente");
        }
    }
}
