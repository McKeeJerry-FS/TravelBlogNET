using Microsoft.AspNetCore.Mvc;
using TravelBlog.Services.Interfaces;
using TravelBlog.Models;
using System.Threading.Tasks;

namespace TravelBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        // GET: BlogController
        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetAllBlogPostsAsync();
            return View(blogs);
        }

    }
}
