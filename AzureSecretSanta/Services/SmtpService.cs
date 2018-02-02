using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AzureSecretSanta.Models;
using AzureSecretSanta.Services.Interfaces;

namespace AzureSecretSanta.Services
{
    public class SmtpService : ISmtpService
    {
        public async Task SendEmail(UserModel to, UserModel santaOf)
        {
            string gmailLogin = ConfigurationManager.AppSettings["GmailLogin"];
            string gmailPassword = ConfigurationManager.AppSettings["GmailPassword"];

            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(gmailLogin, gmailPassword),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            })

            {

                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(gmailLogin, "Secret Santa"),
                    IsBodyHtml = true,
                    Body = $"Hi, you are santa of: <b>{santaOf.Name}</b>. His gift description: <b>{santaOf.GiftDescription}</b>"
                };
                mail.To.Add(new MailAddress(to.Email));

                await smtpClient.SendMailAsync(mail);
            }
        }
    }
}