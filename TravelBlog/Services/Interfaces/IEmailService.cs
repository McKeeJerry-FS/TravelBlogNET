using TravelBlog.Models;
using System.Collections.Generic;

namespace TravelBlog.Services;

public interface IEmailService
{
    void SendEmail(EmailData emailData);
    void SendBulkEmail(IEnumerable<string> recipients, string subject, string body);
}
