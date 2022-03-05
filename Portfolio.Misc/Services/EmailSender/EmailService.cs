using MailKit.Net.Smtp;
using MimeKit;

namespace Portfolio.Misc.Services.EmailSender;

public class EmailService : IEmailService
{
    private readonly EmailConfiguration _config;

    public EmailService(EmailConfiguration config) =>
        _config = config;

    public async Task SendMessageAsync(string email, string message, string name, string subject)
    {
        using var client = new SmtpClient();
        await client.ConnectAsync(_config.SmtpServer, _config.Port, true);
        client.AuthenticationMechanisms.Remove("XOAUTH2");
        await client.AuthenticateAsync(_config.UserName, _config.Password);

        var mime = new MimeMessage();
        mime.From.Add(new MailboxAddress("TONY!", _config.From));
        mime.To.Add(new MailboxAddress(name, email));
        mime.Subject = subject;
        mime.Body = new TextPart(MimeKit.Text.TextFormat.Text) {Text = "Automatic response for: \""+message+"\" \n DUCK UUUUUUUU!"};
        
        await client.SendAsync(mime);
    }
}