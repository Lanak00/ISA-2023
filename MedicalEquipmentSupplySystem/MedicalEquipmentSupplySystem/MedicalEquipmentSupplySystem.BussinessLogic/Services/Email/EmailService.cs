using MailKit.Net.Smtp;
using MedicalEquipmentSupplySystem.BussinessLogic.Interfaces;
using MimeKit;


namespace MedicalEquipmentSupplySystem.BussinessLogic.Services.Email
{
    public class EmailService : IEmailService
    {
        public readonly EmailConfiguration _emailConfig;
        public EmailService(EmailConfiguration emailConfig) => _emailConfig = emailConfig;

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        private void Send(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_emailConfig.SmptServer, _emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfig.Username, _emailConfig.Password);

                client.Send(mailMessage);

            }
            catch
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }

        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }
    }
}
