using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System.Text;

namespace Ans.Net6.Common.Services
{

    /// <summary>
    /// 
    /// </summary>
	public interface IMailerService
    {
        Task SendAsync(MailMessage message);
    }



    /// <summary>
    /// 
    /// </summary>
    public interface IMailerServiceOptions
    {
        string DefaultFromAddress { get; set; }
        string DefaultFromTitle { get; set; }
        string SmtpPassword { get; set; }
        int SmtpPort { get; set; }
        string SmtpServer { get; set; }
        string SmtpUsername { get; set; }
        bool SmtpUseSsl { get; set; }
    }



    /// <summary>
    /// 
    /// </summary>
    public class MailerServiceOptions
        : IMailerServiceOptions
    {
        public string DefaultFromTitle { get; set; }
        public string DefaultFromAddress { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public bool SmtpUseSsl { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
    }



    /// <summary>
    /// 
    /// </summary>
    public class MailerService
        : IMailerService
    {
        private readonly MailerServiceOptions _options;

        public MailerService(
            MailerServiceOptions options)
        {
            this._options = options;
        }

        public MailboxAddress GetMailboxAddress(
            string title,
            string address)
        {
            return new MailboxAddress(Encoding.UTF8, title ?? address, address);
        }

        public async Task SendAsync(
            MailMessage message)
        {
            var m1 = new MimeMessage();
            m1.From.Add((message.From != null)
                ? GetMailboxAddress(message.From.Title, message.From.Address)
                : GetMailboxAddress(_options.DefaultFromTitle, _options.DefaultFromAddress));
            m1.To.Add(GetMailboxAddress(message.To.Title, message.To.Address));
            if (message.Cc != null && message.Cc.Any())
                m1.Cc.AddRange(message.Cc.Select(x => GetMailboxAddress(x.Title, x.Address)));
            if (message.Bcc != null && message.Bcc.Any())
                m1.Bcc.AddRange(message.Bcc.Select(x => GetMailboxAddress(x.Title, x.Address)));
            m1.Subject = message.Subject;
            m1.Body = new TextPart(TextFormat.Html)
            {
                Text = message.ContentHtml
            };
            using var client = new SmtpClient();
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.ConnectAsync(
                _options.SmtpServer,
                _options.SmtpPort,
                _options.SmtpUseSsl);
            await client.AuthenticateAsync(
                _options.SmtpUsername,
                _options.SmtpPassword);
            await client.SendAsync(m1);
            await client.DisconnectAsync(true);
        }

    }






    //	_mailerService.Send(new MailMessage
    //	{
    //		//From = new MailAddress("От кого", "krv@aanet.ru"),
    //		To = new MailAddress("Кому", "krv@guap.ru"),
    //		Cc = new List<MailAddress> {
    //			new MailAddress("Копия 1", "krv@aanet.ru"),
    //			new MailAddress("Копия 2", "krv@guap.ru")
    //		},
    //		Bcc = new List<MailAddress> {
    //			new MailAddress("Скрытая 1", "krv@aanet.ru"),
    //			new MailAddress("Скрытая 2", "krv@guap.ru")
    //		},
    //		Subject = subject,
    //		ContentHtml = message
    //	});

}
