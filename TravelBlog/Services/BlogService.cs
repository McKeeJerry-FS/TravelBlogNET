using System;
using TravelBlog.Models;
using TravelBlog.Services.Interfaces;
using TravelBlog.Data; // Add this using directive
using Microsoft.EntityFrameworkCore; // Add this using directive

namespace TravelBlog.Services;

public class BlogService : IBlogService
{
  private readonly ApplicationDbContext _context;
  public BlogService(ApplicationDbContext context)
  {
    _context = context;
  }

  public Task CreateBlogPostAsync(BlogPost blogPost, IEnumerable<int> selected)
  {
    throw new NotImplementedException();
  }

  public Task DeleteBlogPostAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<BlogPost> DeleteBlogPostAsync_Get(int? id)
  {
    throw new NotImplementedException();
  }

  public Task<BlogPost> EditBlogPostAsync(BlogPost blogPost, IEnumerable<int> selected)
  {
    throw new NotImplementedException();
  }

  public Task<List<BlogPost>> FilterBlogPostByCategory(int? categoryId)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<BlogPost>> GetAllArchivedBlogPostsAsync(int? tagId)
  {
    throw new NotImplementedException();
  }

  public async Task<IEnumerable<BlogPost>> GetAllBlogPostsAsync()
  {
    return await _context.Posts.ToListAsync();
  }

  public Task<IEnumerable<BlogPost>> GetAllDraftBlogPostsAsync(int? tagId)
  {
    throw new NotImplementedException();
  }

  public Task<BlogPost> GetBlogByIdAsync(int? id)
  {
    throw new NotImplementedException();
  }

  public Task<BlogPost> GetBlogBySlugAsync(string? slug)
  {
    throw new NotImplementedException();
  }

  public Task<BlogPost> GetBlogDetailsAsync(int? id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<BlogPost>> GetBlogPostsAsync()
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Category>> GetCategoriesAsync()
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<BlogPost>> GetFavoriteBlogPostsAsync(string? blogUserId)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<BlogPost>> GetPopularBlogsAsync()
  {
    throw new NotImplementedException();
  }

  public Task<bool> IsValidSlugAsync(string? title, int? blogPostId)
  {
    throw new NotImplementedException();
  }

  public IEnumerable<BlogPost> SearchBlogPost(string searchString)
  {
    throw new NotImplementedException();
  }

  public Task UpdateBlogPostAsync(BlogPost blogPost)
  {
    throw new NotImplementedException();
  }

  public Task<bool> UserLikedBlogAsync(int blogPostId, string blogUserId)
  {
    throw new NotImplementedException();
  }
}
