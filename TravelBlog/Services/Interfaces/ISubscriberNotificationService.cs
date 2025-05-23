namespace TravelBlog.Services;

public interface ISubscriberNotificationService
{
    void NotifySubscribersOfNewPost(string postTitle, string postUrl);
    // Add more notification methods as needed
}
