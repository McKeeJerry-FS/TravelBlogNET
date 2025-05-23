using Microsoft.AspNetCore.Mvc;
using TravelBlog.Models;
using TravelBlog.Services.Interfaces;
using System.Threading.Tasks;

namespace TravelBlog.Controllers
{
  public class BlogPostsController : Controller
  {
    private readonly IBlogService _blogService;
    private readonly IImageService _imageService;
    public BlogPostsController(IBlogService blogService, IImageService imageService)
    {
      _blogService = blogService;
      _imageService = imageService;
    }

    // GET: BlogPosts/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: BlogPosts/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BlogPost blogPost)
    {
      if (ModelState.IsValid)
      {
        // Save blog post logic here (call _blogService)
        await _blogService.CreateBlogPostAsync(blogPost, new List<int>());
        return RedirectToAction("Index");
      }
      return View(blogPost);
    }

    // GET: BlogPosts/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }
      var blogPost = await _blogService.GetBlogByIdAsync(id);
      if (blogPost == null)
      {
        return NotFound();
      }
      return View("Create", blogPost); // Reuse the Create view for editing
    }

    // POST: BlogPosts/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, BlogPost blogPost)
    {
      if (id != blogPost.Id)
      {
        return NotFound();
      }
      if (ModelState.IsValid)
      {
        await _blogService.UpdateBlogPostAsync(blogPost);
        return RedirectToAction("Index");
      }
      return View("Create", blogPost); // Reuse the Create view for editing
    }
    // ...existing code...
  }
}