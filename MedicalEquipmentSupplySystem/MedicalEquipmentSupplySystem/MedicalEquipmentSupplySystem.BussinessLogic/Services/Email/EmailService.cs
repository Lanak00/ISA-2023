using MailKit.Net.Smtp;
using MailKit.Security;
using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace MedicalEquipmentSupplySystem.BussinessLogic.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfig;
        public EmailService(IOptions<EmailConfiguration> emailConfig)
        {
            _emailConfig = emailConfig.Value;
        }

        public void SendEmail(EmailRequest emailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_emailConfig.From);
            email.To.Add(MailboxAddress.Parse(emailRequest.ToEmail));
            email.Subject = emailRequest.Subject;
            //body?
            BodyBuilder emailBodyBuilder = new BodyBuilder();   
            emailBodyBuilder.TextBody = emailRequest.Body;
            email.Body = emailBodyBuilder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_emailConfig.Host, _emailConfig.Port,
                    SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailConfig.From, _emailConfig.Password);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }
}
