using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YateMate.Components;
using YateMate.Components.Account;
using YateMate.Repositorio;
using YateMate.Aplicacion.Entidades;
namespace YateMate;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

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

        // asi se agregan roles y un admin a la base de datos, si descomentas esto main tiene que ser async Task
        // using (var scope = app.Services.CreateScope())
        // {
        //     var email = "admin@admin.com";
        //     var password = "Pass123$";
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
        // }
        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        // Add additional endpoints required by the Identity /Account Razor components.
        app.MapAdditionalIdentityEndpoints();

        app.Run();
    }
}