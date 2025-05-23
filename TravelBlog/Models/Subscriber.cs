using System;
using System.ComponentModel.DataAnnotations;

namespace TravelBlog.Models
{
    public class Subscriber
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public DateTime SubscribedOn { get; set; } = DateTime.UtcNow;
    }
}
