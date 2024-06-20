using System.Security.Cryptography;
using System.Text;

namespace SGE.Aplicacion;

public class ServicioHashing : IServicioHashing
{
    public string CalcularHash(string data)
    {
        using SHA256 sha256Hash = SHA256.Create();
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));
        return Convert.ToBase64String(bytes);
    }

    public bool Verificar(string hash, string data)
    {
        string dataHash = CalcularHash(data);
        return hash == dataHash;
    }
}
