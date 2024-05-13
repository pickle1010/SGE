using SGE.Aplicacion;
using SGE.Repositorios;

//Configuro las dependencias
IExpendienteRepositorio repoExpedientes = new RepositorioExpedienteTXT("/DireccionExpedientesTXT"); //direcciones temporales
ITramiteRepositorio repoTramites = new RepositorioTramiteTXT("/DireccionTramitesTXT");
IServicioAutorizacion servicioAutorizacion = new ServicioAutorizacionProvisorio();
// EspecificacionCambioEstado estado = new EspecificacionCambioEstado(); // NO ESTA BIEN, ME HACE INSTANCIAR UN CAMBIO DE ESTADO
// ServicioActualizacionEstado servicioActualizacion = new ServicioActualizacionEstado(); //REVISAR, ¿CREAR UNA NUEVA INTERFAZ?
//La instancia podría ser en el caso de uso directamente? <-------
ExpedienteValidador expedienteValidador = new ExpedienteValidador();
TramiteValidador tramiteValidador = new TramiteValidador();


int IdUsuario = 1;

//Creo los casos de uso
var darAltaExpediente = new CasoDeUsoExpedienteAlta(repoExpedientes, expedienteValidador, servicioAutorizacion);
var darBajaExpediente = new CasoDeUsoExpedienteBaja(repoExpedientes, repoTramites, servicioAutorizacion);
var consultarExpedientePorId = new CasoDeUsoExpedienteConsultaPorID(repoExpedientes, repoTramites);
var consultarExpedientesyTramites = new CasoDeUsoExpedienteConsultaTodos(repoExpedientes);
var modificarExpediente = new CasoDeUsoExpedienteModificacion(repoExpedientes, expedienteValidador, servicioAutorizacion);
//var darAltaTramite = new CasoDeUsoTramiteAlta(repoTramites, tramiteValidador, servicioAutorizacion, servicioAuctualizacion); // QUE SUCEDE: ME PIDE COMO PARAMETRO UN SERVICIO ACTUALIZACION EL CUAL ME OBLIGA A INSTANCIAR UN CAMBIO DE ESTADO
//var darBajaTramite = new CasoDeUsoTramiteBaja(repoTramites, servicioAutorizacion); // idem anterior
var consultarPorEtiqueta = new CasoDeUsoTramiteConsultaPorEtiqueta(repoTramites);
//var modificarTramite = new CasoDeUsoTramiteModificacion(repoTramites, tramiteValidador, servicioAutorizacion, ) // idem anteriores


//Ejecuto los casos de uso de expedientes -> ESTOY UTILIZANDO EL ID 1 DE EXPEDIENTE COMO EJEMPLO
Expediente expedienteEjemplo = new Expediente("CaratulaEjemplo");
darAltaExpediente.Ejecutar(expedienteEjemplo, IdUsuario);
darBajaExpediente.Ejecutar(1, IdUsuario);
consultarExpedientePorId.Ejecutar(1);
consultarExpedientesyTramites.Ejecutar(expedienteEjemplo);
modificarExpediente.Ejecutar(expedienteEjemplo, IdUsuario);


//Ejecuto los casos de uso de tramite
Tramite tramiteEjemplo = new Tramite("ContenidoEjemplo");
EtiquetaTramite etiquetaConsulta = EtiquetaTramite.Despacho; 
consultarPorEtiqueta.Ejecutar(etiquetaConsulta);



/* --Pseudocodigo--
{Llamar a ejecutar a los casos de uso}
    -{darAltaTramite}
    -{darBajaTramite}
    -{modificarTramite}

{Hacer un iterador para imprimir los tostring}

*/


