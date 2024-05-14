using SGE.Aplicacion;
using SGE.Repositorios;

/* Configurar las dependencias */
// Repositorios
string workingDirectory = Environment.CurrentDirectory;

IExpendienteRepositorio repoExpedientes = new RepositorioExpedienteTXT($"{workingDirectory}/DireccionExpedientesTXT"); //direcciones temporales
ITramiteRepositorio repoTramites = new RepositorioTramiteTXT($"{workingDirectory}/DireccionTramitesTXT");

// Servicios
IServicioAutorizacion servicioAutorizacion = new ServicioAutorizacionProvisorio();
EspecificacionCambioEstado especificacion = new EspecificacionCambioEstado(); // NO ESTA BIEN, ME HACE INSTANCIAR UN CAMBIO DE ESTADO
IServicioActualizacionEstado servicioActualizacion = new ServicioActualizacionEstado(especificacion, repoExpedientes, repoTramites); //REVISAR, ¿CREAR UNA NUEVA INTERFAZ?
//La instancia podría ser en el caso de uso directamente? <-------

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
var consultarExpedientesyTramites = new CasoDeUsoExpedienteConsultaTodos(repoExpedientes);

// Para tramites
var darAltaTramite = new CasoDeUsoTramiteAlta(repoTramites, tramiteValidador, servicioAutorizacion, servicioActualizacion); // QUE SUCEDE: ME PIDE COMO PARAMETRO UN SERVICIO ACTUALIZACION EL CUAL ME OBLIGA A INSTANCIAR UN CAMBIO DE ESTADO
var darBajaTramite = new CasoDeUsoTramiteBaja(repoTramites, servicioAutorizacion, servicioActualizacion); // idem anterior
var modificarTramite = new CasoDeUsoTramiteModificacion(repoTramites, tramiteValidador, servicioAutorizacion, servicioActualizacion); // idem anteriores
var consultarPorEtiqueta = new CasoDeUsoTramiteConsultaPorEtiqueta(repoTramites);

//Ejecuto los casos de uso de expedientes -> ESTOY UTILIZANDO EL ID 1 DE EXPEDIENTE COMO EJEMPLO
Expediente expedienteEjemplo = new Expediente("CaratulaEjemplo");
darAltaExpediente.Ejecutar(expedienteEjemplo, IdUsuario);
darBajaExpediente.Ejecutar(1, IdUsuario);
Console.WriteLine(expedienteEjemplo.Id);
foreach(Expediente expediente in repoExpedientes.ConsultarTodos()){
    Console.WriteLine(expediente);
}
Console.WriteLine("Consultando \n"+consultarExpedientePorId.Ejecutar(1));
consultarExpedientesyTramites.Ejecutar(expedienteEjemplo);
modificarExpediente.Ejecutar(expedienteEjemplo, IdUsuario);

//Ejecuto los casos de uso de tramite
Tramite tramiteEjemplo = new Tramite("ContenidoEjemplo");
EtiquetaTramite etiquetaConsulta = EtiquetaTramite.Despacho; 
consultarPorEtiqueta.Ejecutar(etiquetaConsulta);


Console.ReadKey();

/* --Pseudocodigo--
{Llamar a ejecutar a los casos de uso}
    -{darAltaTramite}
    -{darBajaTramite}
    -{modificarTramite}

{Hacer un iterador para imprimir los tostring}

*/
