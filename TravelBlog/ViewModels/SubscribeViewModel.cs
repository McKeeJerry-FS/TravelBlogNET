using System.ComponentModel.DataAnnotations;
using TravelBlog.Models;

namespace TravelBlog.ViewModels
{
    public class SubscribeViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
