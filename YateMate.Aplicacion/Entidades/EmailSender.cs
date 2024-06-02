using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace YateMate.Aplicacion.Entidades;
public class EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
    ILogger<EmailSender> logger) : IEmailSender<ApplicationUser>
{
    private readonly ILogger _logger = logger;

    public AuthMessageSenderOptions Options { get; } = optionsAccessor.Value;

    
         public Task SendConfirmationLinkAsync(ApplicationUser user, string email, 
         string confirmationLink) => SendEmailAsync(email, "Confirma tu cuenta:", 
         $"Por favor confirma tu cuenta haciendo click en el siguiente enlace {confirmationLink}");
       //nota: este metodo no se deberia ejecutar nunca, no usamos link de confirmacion de cuenta

     public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, 
         string resetLink) => SendEmailAsync(email, "Cambia tu contraseña:", 
         $"Haz click aqui para cambiar tu contraseña {resetLink}");

        public Task SendMessageOferta(string Email, Bien bien,
            Publicacion publicacion) => SendEmailAsync(Email, "Recibiste una nueva oferta",
            $"Te han ofertado el bien: '{bien.Nombre}', con descripción: '{bien.Descripcion}' para tu publicación: '{publicacion.Titulo}'");
     
        public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, 
         string resetCode) => SendEmailAsync(email, "Cambia tu contraseña", 
         $"Cambia tu contraseña usando el siguiente codigo: {resetCode}");
     //nota: tampoco se deberia ejecutar
    
    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        if (string.IsNullOrEmpty(Options.EmailAuthKey))
        {
            
            Console.WriteLine($"Api Mailtrap: {Options.EmailAuthKey} ");
            throw new Exception("La apiKey es null o no esta seteada. Agregaste el secreto?");
            
        }

        await Execute(Options.EmailAuthKey, subject, message, toEmail);
    }

    public async Task Execute(string apiKey, string subject, string message, 
        string toEmail)
    {
        if (message.Contains("amp;"))
        {
            message = message.Replace("&amp;", "&");
        }
        var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
        {
            Credentials = new NetworkCredential("b7680a9e8a9a3a", apiKey),
            EnableSsl = true
        };
        client.EnableSsl = true;
        client.Send("YateMate@YateMate.com", toEmail, subject, message);
         
        _logger.LogInformation($"Email to {toEmail} sent!, with subject {subject} and message {message}");
     }

}