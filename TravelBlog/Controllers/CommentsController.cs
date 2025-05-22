using Microsoft.AspNetCore.Mvc;

namespace TravelBlog.Controllers
{
    public class CommentsController : Controller
    {
        // GET: CommentsController
        public ActionResult Index()
        {
            return View();
        }

    }
}
