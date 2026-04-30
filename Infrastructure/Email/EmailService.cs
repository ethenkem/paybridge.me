namespace PayBridge.Infrastructure.Email;


public class EmailService
{
    private readonly IConfiguration _config;
    public EmailService(IConfiguration configuration)
    {
        this._config = configuration;

    }

    // public async Task<bool> SendEmailAsync(string to, string subject, string body)
    // {

    // }
}