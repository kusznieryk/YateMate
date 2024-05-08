using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace YateMate.Aplicacion.Entidades;
public class EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
    ILogger<EmailSender> logger) : IEmailSender<ApplicationUser>
{
    private readonly ILogger logger = logger;

    public AuthMessageSenderOptions Options { get; } = optionsAccessor.Value;

    
         public Task SendConfirmationLinkAsync(ApplicationUser user, string email, 
         string confirmationLink) => SendEmailAsync(email, "Confirma tu cuenta:", 
         $"Por favor confirma tu cuenta haciendo click en el siguiente enlace " +
         "{confirmationLink}");
//     //nota: este metodo no se deberia ejecutar nunca, no usamos link de confirmacion de cuenta

     public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, 
         string resetLink) => SendEmailAsync(email, "Cambia tu contraseña:", 
         $"Haz click aqui para cambiar tu contraseña {resetLink}");

          public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, 
         string resetCode) => SendEmailAsync(email, "Cambia tu contraseña", 
         $"Cambia tu contraseña usando el siguiente codigo: {resetCode}");
     //nota: tampoco se deberia ejecutar
    
    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        if (string.IsNullOrEmpty(Options.EmailAuthKey) || string.IsNullOrEmpty(Options.ActualEmail))
        {
            
            Console.WriteLine($"contrasenia: {Options.EmailAuthKey} mail: {Options.ActualEmail} options to string {Options.ToString()}");
            throw new Exception("Contraseña del mail o el mail en si no estan seteados. Agregaste los secretos?");
            
        }

        await Execute(Options.EmailAuthKey, subject, message, toEmail);
    }

    public async Task Execute(string apiKey, string subject, string message, 
        string toEmail)
    {
        //usamos el servidor smtp que te da gmail, necesitas tener una cuenta con 2fa y habilitar application passwords
         var client = new SmtpClient("smtp.gmail.com", 587);
         string? pass = Options.EmailAuthKey;
         string? emailFrom = Options.ActualEmail;
         client.Credentials = new NetworkCredential(emailFrom, pass);
         client.EnableSsl = true;
         await client.SendMailAsync(emailFrom, toEmail, subject, message);
         
         logger.LogInformation("Email to {EmailAddress} sent!", toEmail);
     }
}