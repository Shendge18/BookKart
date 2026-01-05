using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKart.Utility
{
    public class EmailSender : IEmailSender
    {
        public string SendGridSecret { get; set; }

        public EmailSender(IConfiguration _config)
        {
            SendGridSecret = _config.GetValue<string>("SendGrid:SecretKey");
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //logic to send email

            var client = new SendGridClient(SendGridSecret);

            var from = new EmailAddress("shendgeshivam@gmail.com", "Book Kart");
            var to = new EmailAddress(email);
            var message = MailHelper.CreateSingleEmail(
                from,
                to,
                subject,
                plainTextContent: null,
                htmlContent: htmlMessage
            );

            var response = await client.SendEmailAsync(message);

            // Optional but VERY useful for debugging
            if (!response.IsSuccessStatusCode)
            {
                var responseBody = await response.Body.ReadAsStringAsync();
                throw new Exception($"Email failed: {response.StatusCode} - {responseBody}");
            }


        }
    }
}
