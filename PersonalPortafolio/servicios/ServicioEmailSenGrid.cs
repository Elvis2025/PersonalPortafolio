using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using PersonalPortafolio.Models;
using MailKit.Net.Smtp;

namespace PersonalPortafolio.servicios
{

    public class ServicioEmailSenGrid: ISevicioEmail
    {
        private readonly IConfiguration _configuration;
        public ServicioEmailSenGrid(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Enviar(ContactoDTO contactoDto)
        {
            var email = new MimeMessage();
            email.From.Add(
                MailboxAddress.Parse(contactoDto.Email)
                );
            email.To.Add(
                MailboxAddress.Parse(_configuration.GetSection("Email:UserName").Value)
                );
            email.Subject = $"El cliente {contactoDto.Nombre} quiere contactarte.";
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = @$"<p>{contactoDto.Mensaje}<p>                      

                        <p><strong>Nombre<strong>: {contactoDto.Nombre}<p>                    
                        <p><strong>Email<strong>: {contactoDto.Email} <p>"
            };

            using var smtp = new SmtpClient();
            smtp.Connect(
                _configuration.GetSection("Email:Host").Value,
                Convert.ToInt32(_configuration.GetSection("Email:Port").Value),
                SecureSocketOptions.StartTls
            );
            smtp.Authenticate(
                _configuration.GetSection("Email:UserName").Value,
                _configuration.GetSection("Email:PassWord").Value
                );
            smtp.Send(email);
            smtp.Disconnect(true);


            }
        
    }
}
