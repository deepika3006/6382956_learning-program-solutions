namespace EmailApp
{
    public interface IEmailService
    {
        bool SendEmail(string to, string message);
    }
}
