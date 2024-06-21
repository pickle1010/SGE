using SGE.UI.Components;

using SGE.Aplicacion;
using SGE.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IUsuarioRepositorio, RepositorioUsuario>();
builder.Services.AddScoped<IExpedienteRepositorio, RepositorioExpediente>();
builder.Services.AddScoped<ITramiteRepositorio, RepositorioTramite>();

builder.Services.AddTransient<EmailValidador>();
builder.Services.AddTransient<LogInValidador>();
builder.Services.AddTransient<UsuarioValidador>();
builder.Services.AddTransient<ExpedienteValidador>();
builder.Services.AddTransient<TramiteValidador>();

builder.Services.AddTransient<IEspecificacionCambioEstado, EspecificacionCambioEstado>();
builder.Services.AddTransient<IServicioActualizacionEstado, ServicioActualizacionEstado>();
builder.Services.AddTransient<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddSingleton<IServicioHashing, ServicioHashing>();
builder.Services.AddSingleton<IServicioGestionDeSesion, ServicioGestionDeSesion>();

builder.Services.AddTransient<CasoDeUsoUsuarioAlta>();
builder.Services.AddTransient<CasoDeUsoUsuarioBaja>();
builder.Services.AddTransient<CasoDeUsoUsuarioModificacion>();
builder.Services.AddTransient<CasoDeUsoUsuarioConsultarTodos>();
builder.Services.AddTransient<CasoDeUsoUsuarioEditarPerfil>();
builder.Services.AddTransient<CasoDeUsoUsuarioIniciarSesion>();
builder.Services.AddTransient<CasoDeUsoUsuarioRegistrar>(); 
builder.Services.AddTransient<CasoDeUsoUsuarioConsultarPorId>(); 


builder.Services.AddTransient<CasoDeUsoExpedienteAlta>();
builder.Services.AddTransient<CasoDeUsoExpedienteBaja>();
builder.Services.AddTransient<CasoDeUsoExpedienteModificacion>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultarTodos>();
builder.Services.AddTransient<CasoDeUsoExpedienteConsultarPorID>();

builder.Services.AddTransient<CasoDeUsoTramiteAlta>();
builder.Services.AddTransient<CasoDeUsoTramiteBaja>();
builder.Services.AddTransient<CasoDeUsoTramiteModificacion>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultaPorEtiqueta>();
builder.Services.AddTransient<CasoDeUsoTramiteConsultarTodos>();

SGESqlite.Inicializar();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
