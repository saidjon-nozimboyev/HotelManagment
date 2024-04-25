using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

public class EmailService(IConfiguration config, IUnitOfWork unitOfWork) : IEmailService
{
    private readonly IConfiguration _config = config.GetSection("Email");
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task SendMessageToEmailAsync(string to, string title, string code)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_config["EmailAddress"]));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = title;
        email.Body = new TextPart(TextFormat.Html) { Text = code };

        var smtp = new SmtpClient();
        await smtp.ConnectAsync(_config["Host"], 587, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_config["EmailAddress"], _config["Password"]);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }

    
}
