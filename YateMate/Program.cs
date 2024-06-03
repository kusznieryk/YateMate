using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YateMate.Components;
using YateMate.Components.Account;
using YateMate.Repositorio;
using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.UseCases;
using MudBlazor.Services;
using YateMate.Aplicacion.UseCases.Bien;
using YateMate.Aplicacion.UseCases.ApplicationUser;
using YateMate.Aplicacion.UseCases.Embarcaciones;
using YateMate.Aplicacion.UseCases.Oferta;
using YateMate.Aplicacion.UseCases.Mensaje;
using YateMate.Aplicacion.UseCases.Publicaciones;
using YateMate.Components.Pages;
using YateMate.Hubs;


namespace YateMate;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        
        //ADD USE CASES
        builder.Services.AddTransient<ListarMisEmbarcacionesUseCase>();
        builder.Services.AddTransient<AgregarEmbarcacionUseCase>();
        builder.Services.AddTransient<ModificarEmbarcacionUseCase>();
        builder.Services.AddTransient<ObtenerEmbarcacionUseCase>();
        builder.Services.AddTransient<ObtenerEmbarcacionesDeUseCase>();
        builder.Services.AddTransient<ObtenerEmbarcacionPorMatriculaUseCase>();
        builder.Services.AddTransient<EliminarEmbarcacionUseCase>();
        builder.Services.AddScoped<IRepositorioEmbarcacion, RepositorioEmbarcacion>();
        
        builder.Services.AddTransient<EliminarApplicationUserUseCase>();
        builder.Services.AddTransient<ObtenerApplicationUsersUseCase>();
        builder.Services.AddTransient<ModificarApplicationUserUseCase>();
        builder.Services.AddTransient<ObtenerEmpleadosUseCase>();
        builder.Services.AddTransient<ObtenerClientesUseCase>();
        builder.Services.AddTransient<ObtenerClientesExceptoUseCase>();
        builder.Services.AddTransient<ObtenerApplicationUserUseCase>();
        builder.Services.AddTransient<ObtenerContactosDeUseCase>();
        builder.Services.AddScoped<IRepositorioApplicationUser, RepositorioApplicationUser>();
        
        builder.Services.AddTransient<AgregarBienUseCase>();
        builder.Services.AddTransient<EliminarBienUseCase>();
        builder.Services.AddTransient<ModificarBienUseCase>();
        builder.Services.AddTransient<ListarBienesDeUseCase>();
        builder.Services.AddTransient<ObtenerBienUseCase>();
        builder.Services.AddScoped<IRepositorioBien,RepositorioBien>();
        
        builder.Services.AddTransient<EliminarOfertaUseCase>();
        builder.Services.AddTransient<HacerOfertaUseCase>();
        builder.Services.AddTransient<AceptarOfertaUseCase>();
        builder.Services.AddTransient<ListarOfertasDeUseCase>();
        builder.Services.AddTransient<ListarOfertasHechasUseCase>();
        builder.Services.AddTransient<ListarTruequesDisponiblesUseCase>();
        builder.Services.AddTransient<ObtenerPublicacionDeUseCase>();
        builder.Services.AddTransient<ObtenerTruequesAcordadosUseCase>();
        builder.Services.AddScoped<IRepositorioOferta,RepositorioOferta>();
              
        builder.Services.AddTransient<ObtenerPublicacionUseCase>();
        builder.Services.AddTransient<PublicarEmbarcacionUseCase>();
        builder.Services.AddTransient<ListarMisPublicacionesUseCase>();
        builder.Services.AddTransient<FiltrarPublicacionesPorCaladoUseCase>();
        builder.Services.AddTransient<FiltrarPublicacionesPorEsloraUseCase>();
        builder.Services.AddTransient<ModificarPublicacionUseCase>();
        builder.Services.AddTransient<EliminarPublicacionUseCase>();
        builder.Services.AddTransient<ObtenerDuenioUseCase>();
        builder.Services.AddScoped<IRepositorioPublicacion, RepositorioPublicacion>();

        builder.Services.AddTransient<AgregarMensajeUseCase>();
        builder.Services.AddTransient<ObtenerMensajesEntreUseCase>();
        builder.Services.AddScoped<IRepositorioMensaje, RepositorioMensaje>();

            
        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddScoped<IdentityUserAccessor>();
        builder.Services.AddScoped<IdentityRedirectManager>();
        builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

        builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddIdentityCookies();

      
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite("DataSource=../YateMate.Repositorio/Data/app.db;Cache=Shared"));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        //Identity
        builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>() //con esto podes tener roles
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders()
            .AddErrorDescriber<SpanishIdentityErrorDescriber>();
        
        
        //https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.identityoptions?view=aspnetcore-8.0&viewFallbackFrom=net-8.0
        builder.Services.Configure<IdentityOptions>(options =>
        {
            // Password settings.
            options.Password.RequiredLength = 8;
            
            // User settings.
            options.User.RequireUniqueEmail = true;
        });
        
        builder.Services.AddMudServices();
        builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration); //esto es para guardar secretos
        
        // Consolw.WriteLine("Secretos:);
        // Console.WriteLine(builder.Configuration["EmailAuthKey"]);
        // Console.WriteLine();
        
        builder.Services.AddSingleton<IEmailSender<ApplicationUser>, EmailSender>();
        builder.Services.AddTransient<EmailSender>();

        //cosas del chat
        builder.Services.AddSignalR(hubOptions =>
        {
            hubOptions.MaximumReceiveMessageSize = Constants.SignalRConstants.MaximumMessageSize;
        });
        
        
        var app = builder.Build();
        
        app.UseAntiforgery();
        
        app.MapHub<SignalRHub>(Constants.SignalRConstants.HubPath);
        app.MapFallbackToFile(Constants.SignalRConstants.FallbackFile);

        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        
        app.UseHttpsRedirection();

        app.UseStaticFiles();
        
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        // Add additional endpoints required by the Identity /Account Razor components. 
        // esto solo hace falta porque tiene el logout, pero tiene mucho de 2fa y eso
        app.MapAdditionalIdentityEndpoints();
        

        app.Run();
    }
}