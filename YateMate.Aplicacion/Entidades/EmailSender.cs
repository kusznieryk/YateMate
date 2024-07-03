using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Net.Mail;
using System.Resources;

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

        public Task SendMessageAceptacion(string Email, Bien bien, Publicacion publicacion) => SendEmailAsync(Email,
            "Una oferta ha sido aceptada"
            , $"Te aceptaron la oferta del bien {bien.Nombre}, en la publicacion {publicacion.Titulo}");

        public Task SendMessageChat(string Email, ApplicationUser SendingUser)
            => SendEmailAsync(Email, "¡Te han enviado un mensaje!",
                $"Has recibido un mensaje de {SendingUser.Nombre} {SendingUser.Apellido}. Entra a la seccion de 'Chat' para verlo.");

        public Task SendMessageReserva(string Email, Reserva reserva, ApplicationUser duenioReserva,
            Subalquiler subalquiler)
            => SendEmailAsync(Email, "¡Han reservado tu amarra!",
                $"El usuario '{duenioReserva.Nombre} {duenioReserva.Apellido}' ha reservado tu amarra de Nº{subalquiler.IdAmarra} desde {reserva.FechaInicio:d} hasta {reserva.FechaFin:d}");

        public Task SendMessageCambioReserva(string Email, Reserva reserva, ApplicationUser duenioReserva,
            Subalquiler subalquiler)
            => SendEmailAsync(Email, "Cambio de fecha de reserva",
                $"El usuario '{duenioReserva.Nombre} {duenioReserva.Apellido}' ha efectuado un cambio de fecha para la reserva del subalquiler de la amarra Nº{subalquiler.IdAmarra}. Ahora la reserva es entre {reserva.FechaInicio:d} y {reserva.FechaFin:d}");
        public Task SendMessageCancelacion(string Email, Reserva reserva, ApplicationUser duenioReserva,
            Subalquiler subalquiler)
            => SendEmailAsync(Email, "Cancelado de reserva",
                $"El usuario '{duenioReserva.Nombre} {duenioReserva.Apellido}' ha cancelado su reserva para tu amarra de Nº{subalquiler.IdAmarra}. El rango {reserva.FechaInicio:d} - {reserva.FechaFin:d} vuelve a estar disponible para reservas.");

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
            Credentials = new NetworkCredential("e4ec570ec78c2f", apiKey),
            EnableSsl = true
        };
        client.EnableSsl = true;
        try
        {
            client.Send("YateMate@YateMate.com", toEmail, subject, message);
        }
        catch (SmtpException)
        {
            Console.WriteLine("Problemas al enviar el mail, fijate de tener la clave al dia y tener internet");
        }
         
        _logger.LogInformation($"Email to {toEmail} sent!, with subject {subject} and message {message}");
     }

}