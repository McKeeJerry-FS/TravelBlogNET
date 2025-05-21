using Microsoft.AspNetCore.Mvc;

namespace TravelBlog.Controllers
{
    public class BlogController : Controller
    {
        // GET: BlogController
        public ActionResult Index()
        {
            return View();
        }

    }
}
