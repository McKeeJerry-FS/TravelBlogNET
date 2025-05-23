using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using TravelBlog.Models;
using System.Collections.Generic;

namespace TravelBlog.Services;

public class EmailService : IEmailService
{
    private readonly EmailSettings _settings;

    public EmailService(IConfiguration configuration)
    {
        _settings = new EmailSettings
        {
            EmailAddress = configuration["EmailSettings:EmailAddress"],
            EmailPassword = configuration["EmailSettings:EmailPassword"],
            EmailHost = configuration["EmailSettings:EmailHost"],
            EmailPort = int.Parse(configuration["EmailSettings:EmailPort"] ?? "587")
        };
    }

    public void SendEmail(EmailData emailData)
    {
        if (string.IsNullOrWhiteSpace(_settings.EmailAddress) || string.IsNullOrWhiteSpace(emailData.EmailAddress))
            throw new InvalidOperationException("Email address is not configured.");
        using var client = new SmtpClient(_settings.EmailHost, _settings.EmailPort)
        {
            Credentials = new NetworkCredential(_settings.EmailAddress, _settings.EmailPassword),
            EnableSsl = true
        };
        var mail = new MailMessage
        {
            From = new MailAddress(_settings.EmailAddress!),
            Subject = emailData.EmailSubject,
            Body = emailData.EmailBody,
            IsBodyHtml = true
        };
        mail.To.Add(emailData.EmailAddress!);
        client.Send(mail);
    }

    public void SendBulkEmail(IEnumerable<string> recipients, string subject, string body)
    {
        if (string.IsNullOrWhiteSpace(_settings.EmailAddress))
            throw new InvalidOperationException("Email address is not configured.");
        using var client = new SmtpClient(_settings.EmailHost, _settings.EmailPort)
        {
            Credentials = new NetworkCredential(_settings.EmailAddress, _settings.EmailPassword),
            EnableSsl = true
        };
        foreach (var email in recipients)
        {
            if (string.IsNullOrWhiteSpace(email)) continue;
            var mail = new MailMessage
            {
                From = new MailAddress(_settings.EmailAddress!),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mail.To.Add(email!);
            client.Send(mail);
        }
    }
}
