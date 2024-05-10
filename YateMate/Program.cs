using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YateMate.Components;
using YateMate.Components.Account;
using YateMate.Repositorio;
using YateMate.Aplicacion.Entidades;
using YateMate.Aplicacion.Interfaces;
using YateMate.Aplicacion.UseCases;
using YateMate.Aplicacion.UseCases.ApplicationUser;

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
        builder.Services.AddScoped<IRepositorioEmbarcacion, RepositorioEmbarcacion>();
        
        builder.Services.AddTransient<EliminarApplicationUserUseCase>();
        builder.Services.AddTransient<ObtenerApplicationUsersUseCase>();
        builder.Services.AddScoped<IRepositorioApplicationUser, RepositorioApplicationUser>();
        
            
            
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

        builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>() //con esto podes tener roles
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();
        
        
        //https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.identityoptions?view=aspnetcore-8.0&viewFallbackFrom=net-8.0
        builder.Services.Configure<IdentityOptions>(options =>
        {
            // Password settings.
            options.Password.RequiredLength = 8;
            
            // User settings.
            // options.User.RequireUniqueEmail = true; //este por defecto se inicializa en falso pero igual funca
        });

        
        builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration); //esto es para guardar secretos
        
        // Consolw.WriteLine("Secretos:);
        // Console.WriteLine(builder.Configuration["ActualEmail"]);
        // Console.WriteLine(builder.Configuration["EmailAuthKey"]);
        // Console.WriteLine();
        
        builder.Services.AddSingleton<IEmailSender<ApplicationUser>, EmailSender>();
        
        var app = builder.Build();

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
        // asi se agregan roles, un admin y un empleado a la base de datos si no estan agregados,
        // si descomentas esto main tiene que ser async Task
        // using (var scope = app.Services.CreateScope())
        // {
        //     var email = "admin@admin.com";
        //     var password = "Test123,";
        //     string[] roles = ["Admin", "Empleado", "Cliente"];
        //     var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //     var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        //     foreach (var role in roles)
        //     {
        //         if (!await roleManager.RoleExistsAsync(role))
        //         {
        //             IdentityRole roleRole = new IdentityRole(role);
        //             await roleManager.CreateAsync(roleRole);
        //         }
        //     }
        //     if (await userManager.FindByNameAsync(email) == null)
        //     {
        //         var user = new ApplicationUser();
        //         user.UserName = email;
        //         user.Email = email;
        //         user.EmailConfirmed = true;
        //         var result = await userManager.CreateAsync(user, password);
        //         await userManager.AddToRoleAsync(user, "Admin");
        //     }
        //     
        //     email = "empleado@empleado.com";
        //     password = "Empleado123,";
        //     
        //     if (await userManager.FindByNameAsync(email) == null)
        //     {
        //         var user = new ApplicationUser();
        //         user.UserName = email;
        //         user.Email = email;
        //         user.EmailConfirmed = true;
        //         var result = await userManager.CreateAsync(user, password);
        //         await userManager.AddToRoleAsync(user, "Empleado");
        //     }
        // }
        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        // Add additional endpoints required by the Identity /Account Razor components. 
        // esto solo hace falta porque tiene el logout, pero tiene mucho de 2fa y eso
        app.MapAdditionalIdentityEndpoints();

        app.Run();
    }
}