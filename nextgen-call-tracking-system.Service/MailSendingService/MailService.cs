using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace nextgen_call_tracking_system.Service.MailSendingService
{
    public class MailService : IMailService
    {
        IConfiguration _configuration;
        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> SendPassword(string userId, string password)
        {
            var response = "Mail Not Sent";
            var sender = _configuration.GetSection("Data").GetSection("Id").Value;
            var spassword = _configuration.GetSection("Data").GetSection("Password").Value;
            SmtpClient client = new SmtpClient("smtp.gmail.com");

            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential(sender, spassword);
            client.EnableSsl = true;
            client.Credentials = credentials;

            try
            {
                var mail = new MailMessage(sender.Trim(), userId.Trim());
                mail.Subject = "Updated Password";
                mail.Body = "Your new password is " + password;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                await client.SendMailAsync(mail);
                response = "Mail sent";
            }
            catch (Exception ex)
            {
                response = response + " due to exception:- " + ex.Message;
                throw ex;
            }

            return response;
        }
    }
}
