namespace EmailApp
{
    public class NotificationService
    {
        private readonly IEmailService _emailService;

        public NotificationService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public bool NotifyUser()
        {
            string email = "user@example.com";
            string message = "Transaction successful!";
            return _emailService.SendEmail(email, message);
        }
    }
}
