using Microsoft.AspNetCore.Mvc;
using TravelBlog.Data;
using TravelBlog.Models;
using TravelBlog.ViewModels;

namespace TravelBlog.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SubscribeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SubscribeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_context.Subscribers.Any(s => s.Email == model.Email))
                {
                    var subscriber = new Subscriber { Email = model.Email };
                    _context.Subscribers.Add(subscriber);
                    _context.SaveChanges();
                    ViewBag.Message = "Thank you for subscribing!";
                }
                else
                {
                    ViewBag.Message = "You are already subscribed.";
                }
            }
            return View();
        }
    }
}
