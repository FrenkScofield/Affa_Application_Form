using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace QrantApplicationForm.Services
{
    public class Emailsender : IEmailSender
    {
        private readonly string _host;
        private readonly int _port;
        private readonly bool _ssl;
        private readonly string _username;
        private readonly string _password;
        private readonly BufferBlock<MimeMessage> mailMessages;

        public Emailsender(string host, int port, bool ssl, string username, string password)
        {
            _host = host;
            _port = port;
            _ssl = ssl;
            _username = username;
            _password = password;
            this.mailMessages = new BufferBlock<MimeMessage>();
        }


        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("AFFA", "kamranalibeyli@gmail.com"));
            message.To.Add(MailboxAddress.Parse("kamranaa@code.edu.az"));
            message.Subject = subject;
            message.Body = new TextPart("html")
            {
                Text = htmlMessage
            };
            // We just enqueue the message in memory. Delivery will be attempted in background (see the DeliverAsync method)

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_host, _port, _ssl);   
                smtp.Authenticate(_username, _password);
                await smtp.SendAsync(message);
                smtp.Disconnect(true);
            }

          //  await this.mailMessages.SendAsync(message);
        }


    }
}
