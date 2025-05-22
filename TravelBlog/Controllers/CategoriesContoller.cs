using Microsoft.AspNetCore.Mvc;

namespace TravelBlog.Controllers
{
    public class CategoriesContoller : Controller
    {
        // GET: CategoriesContoller
        public ActionResult Index()
        {
            return View();
        }

    }
}
