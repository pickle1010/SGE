using SGE.Aplicacion;
using SGE.Repositorios;

/* Configurar las dependencias */
// Repositorios
string workingDirectory = Environment.CurrentDirectory;

IExpendienteRepositorio repoExpedientes = new RepositorioExpedienteTXT($"{workingDirectory}/DireccionExpedientesTXT"); //direcciones temporales
ITramiteRepositorio repoTramites = new RepositorioTramiteTXT($"{workingDirectory}/DireccionTramitesTXT");

// Servicios
IServicioAutorizacion servicioAutorizacion = new ServicioAutorizacionProvisorio();
EspecificacionCambioEstado especificacion = new EspecificacionCambioEstado();
IServicioActualizacionEstado servicioActualizacion = new ServicioActualizacionEstado(especificacion, repoExpedientes, repoTramites); 

// Validadores
ExpedienteValidador expedienteValidador = new ExpedienteValidador();
TramiteValidador tramiteValidador = new TramiteValidador();

int IdUsuario = 1;

/* Crear casos de uso */
// Para expedientes
var darAltaExpediente = new CasoDeUsoExpedienteAlta(repoExpedientes, expedienteValidador, servicioAutorizacion);
var darBajaExpediente = new CasoDeUsoExpedienteBaja(repoExpedientes, repoTramites, servicioAutorizacion);
var modificarExpediente = new CasoDeUsoExpedienteModificacion(repoExpedientes, expedienteValidador, servicioAutorizacion);
var consultarExpedientePorId = new CasoDeUsoExpedienteConsultaPorID(repoExpedientes, repoTramites);
var consultarTodos = new CasoDeUsoExpedienteConsultaTodos(repoExpedientes);

// Para tramites
var darAltaTramite = new CasoDeUsoTramiteAlta(repoTramites, tramiteValidador, servicioAutorizacion, servicioActualizacion);
var darBajaTramite = new CasoDeUsoTramiteBaja(repoTramites, servicioAutorizacion, servicioActualizacion);
var modificarTramite = new CasoDeUsoTramiteModificacion(repoTramites, tramiteValidador, servicioAutorizacion, servicioActualizacion);
var consultarPorEtiqueta = new CasoDeUsoTramiteConsultaPorEtiqueta(repoTramites);


//Ejecuto los casos de uso de expedientes
// Imprimir todos los expedientes ya existentes en el archivo y eliminarlos todos, si hay alguno
// List<Expediente> expedientesTodos = consultarTodos.Ejecutar();
// if(expedientesTodos != null){
//     for (int i = 0; i < expedientesTodos.Count; i++)
//     {
//         Console.WriteLine(expedientesTodos[i]);
//         try
//         {
//             darBajaExpediente.Ejecutar(expedientesTodos[i].Id, IdUsuario);
//         }
//         catch(Exception e)
//         {
//             Console.WriteLine(e.Message);
//         }
//     }
// }


// Generar 3 expedientes y darlos de alta
// Expediente[] exps = new Expediente[10];
// for (int i = 0; i < 3; i++)
// {
//     exps[i] = new Expediente($"CaratulaEjemplo{i}");
//     darAltaExpediente.Ejecutar(exps[i], IdUsuario);
// }


// Consultar expedientes exps[0], exps[1] y exps[2] segun su ID
// try
// {
//     Console.WriteLine(consultarExpedientePorId.Ejecutar(exps[0].Id)); //RECORDAR MOSTRAR TRAMITES EN UN PASO POSTERIOR
//     Console.WriteLine(consultarExpedientePorId.Ejecutar(exps[1].Id)); //RECORDAR MOSTRAR TRAMITES EN UN PASO POSTERIOR
//     Console.WriteLine(consultarExpedientePorId.Ejecutar(exps[2].Id)); //RECORDAR MOSTRAR TRAMITES EN UN PASO POSTERIOR
// }
// catch(Exception e)
// {
//     Console.WriteLine(e.Message);
// }


// Modificar caratula y estado del exps[0] y exps[1] e imprimirlos en pantalla
// try
// {
//     exps[0].Caratula = "Esta es la caratula de exps[0]";
//     modificarExpediente.Ejecutar(exps[0], IdUsuario);
//     Console.WriteLine(exps[0]);
//     exps[1].Caratula = "Esta es la caratula de exps[1]";
//     modificarExpediente.Ejecutar(exps[1], IdUsuario);
//     Console.WriteLine(exps[1]);
// }
// catch(Exception e)
// {
//     Console.WriteLine(e.Message);
// }

// Eliminar expedientes exps[0] y exps[2] e imprimir todos los expedientes en el archivo
// try
// {
//     darBajaExpediente.Ejecutar(exps[4].Id, IdUsuario);
//     darBajaExpediente.Ejecutar(exps[5].Id, IdUsuario);
//     IdUsuario = 2;              //Cambio Id usuario para verificar autorizacion
//     darBajaExpediente.Ejecutar(exps[5].Id, IdUsuario);
//     IdUsuario = 1; 
// }
// catch(Exception e)
// {
//     Console.WriteLine(e.Message);
// }


// Mostrar expedientes restantes
// foreach(Expediente exp in repoExpedientes.ConsultarTodos()){
//     Console.WriteLine(exp);
// }


// Ejecuto los casos de uso de tramite
// Tramite tramite1 = new Tramite("ContenidoEjemplo", exps[0].Id);
// Generar 3 tramites y darlos de alta
// Tramite[] trams = new Tramite[10];
// for (int i = 0; i < 3; i++)
// {
//     trams[i] = new Tramite($"ContenidoEjemplo{i}", exps[i].Id);
//     darAltaTramite.Ejecutar(trams[i], IdUsuario);
// }


//Caso de uso Tramite baja: dar de baja tramite XX 
// try
// {   
//     darBajaTramite.Ejecutar(trams[1].Id, IdUsuario);
// }
// catch(Exception e)
// {
//     Console.WriteLine(e.Message);
// }


//Caso de uso Modificacion de tramite: modificar trams[2]
// try
// {
//     trams[2].Contenido = "Soy un tramite";
//     trams[2].Etiqueta = EtiquetaTramite.Despacho;
//     modificarTramite.Ejecutar(trams[2], IdUsuario);
// }
// catch(Exception e)
// {
//     Console.WriteLine(e.Message);
// }



//Caso de uso consulta por etiqueta de ejemplo
// try
// {
//     consultarPorEtiqueta.Ejecutar(EtiquetaTramite.Despacho);
//     consultarPorEtiqueta.Ejecutar(EtiquetaTramite.EscritoPresentado);
// }
// catch(Exception e)
// {
//     Console.WriteLine(e.Message);
// }


// Alta de expedientes | Alta de tramites | Consulta de expedientes con tramites por id
// Expediente[] expedientes = new Expediente[3];
// for (int i = 0; i < 3; i++)
// {
//     expedientes[i] = new Expediente($"Expedientes-expedientes[{i}]");
//     darAltaExpediente.Ejecutar(expedientes[i], IdUsuario);
// }
// Tramite[] tramites = new Tramite[6];
// for (int i = 0; i < 6; i++)
// {
//     tramites[i] = new Tramite($"Tramites[{i}]", expedientes[i % 3].Id);
//     darAltaTramite.Ejecutar(tramites[i],IdUsuario);
// }
// for (int i = 1; i <= 3; i++)
// {
//     Expediente e = consultarExpedientePorId.Ejecutar(i);
//     Console.WriteLine(e);
//     for (int j = 0; j < e.Tramites.Count; j++)
//     {
//         Console.WriteLine(e.Tramites[j]);
//     }
// }

// Eliminacion de expedientes con sus tramites
Expediente[] expedientes = new Expediente[3];
for (int i = 0; i < 3; i++)
{
    expedientes[i] = new Expediente($"Expedientes-expedientes[{i}]");
    darAltaExpediente.Ejecutar(expedientes[i], IdUsuario);
}
Tramite[] tramites = new Tramite[6];
for (int i = 0; i < 6; i++)
{
    tramites[i] = new Tramite($"Tramites[{i}]", expedientes[i % 3].Id);
    darAltaTramite.Ejecutar(tramites[i],IdUsuario);
}

// Probar imprimir todos los expedientes con sus tramites
// for (int i = 1; i <= 3; i++)
// {
//     Expediente e = consultarExpedientePorId.Ejecutar(i);
//     Console.WriteLine(e);
//     for (int j = 0; j < e.Tramites.Count; j++)
//     {
//         Console.WriteLine(e.Tramites[j]);
//     }
// }

// Probar borrado
// Borrar expedientes con id = 2
// for (int i = 1; i <= 3; i++)
// {
//     Expediente e = consultarExpedientePorId.Ejecutar(i);
//     Console.WriteLine(e);
//     for (int j = 0; j < e.Tramites.Count; j++)
//     {
//         Console.WriteLine(e.Tramites[j]);
//     }
// }
// darBajaExpediente.Ejecutar(2, IdUsuario);

/* Probar modificado */
// Modificar expediente
Console.WriteLine("Expediente Viejo: ");
Console.WriteLine(expedientes[0]);

expedientes[0].Caratula = "Caratula Modificada";
expedientes[0].Estado = EstadoExpediente.EnNotificacion;
modificarExpediente.Ejecutar(expedientes[0], IdUsuario);

// Verificar modificacion
Console.WriteLine("Expediente Nuevo: ");
Console.WriteLine(consultarExpedientePorId.Ejecutar(expedientes[0].Id));
/* --------------------------------------------- */

Console.ReadKey();