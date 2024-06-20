namespace SGE.Aplicacion;

public interface IServicioHashing
{
    string CalcularHash(string data);
    bool Verificar(string hash, string data);
}
