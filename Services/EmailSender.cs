using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace Employee_Management_System.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // For now, just write to the console/log instead of actually sending
            Console.WriteLine($"Sending email to {email}, subject: {subject}");
            Console.WriteLine(htmlMessage);
            return Task.CompletedTask;
        }
    }
}

