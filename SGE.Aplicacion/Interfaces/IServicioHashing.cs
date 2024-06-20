namespace SGE.Aplicacion;

public interface IServicioHashing
{
    string CalcularHash(string data);
    bool VerificarHash(string hash, string data);
}
