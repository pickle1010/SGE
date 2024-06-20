namespace SGE.Aplicacion;

public class ServicioAutorizacion: IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso)
    {
        return IdUsuario == 1;
    }
}
