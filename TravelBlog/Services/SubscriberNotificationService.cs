using System.Collections.Generic;
using System.Linq;
using TravelBlog.Data;
using TravelBlog.Models;
using TravelBlog.Services;

namespace TravelBlog.Services;

public class SubscriberNotificationService : ISubscriberNotificationService
{
    private readonly ApplicationDbContext _context;
    private readonly IEmailService _emailService;

    public SubscriberNotificationService(ApplicationDbContext context, IEmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }

    public void NotifySubscribersOfNewPost(string postTitle, string postUrl)
    {
        var emails = _context.Subscribers
            .Select(s => s.Email)
            .Where(email => email != null)
            .Cast<string>()
            .ToList();
        var subject = $"New Blog Post: {postTitle}";
        var body = $"<p>A new blog post has been published: <a href='{postUrl}'>{postTitle}</a></p>";
        _emailService.SendBulkEmail(emails, subject, body);
    }

    // Future: Add more notification methods for events, etc.
}
