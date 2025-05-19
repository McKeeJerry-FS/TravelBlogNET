using System;
using TravelBlog.Models;

namespace TravelBlog.Services.Interfaces;

public interface IBlogService
{
  public Task<IEnumerable<BlogPost>> GetBlogPostsAsync();

  public Task<IEnumerable<BlogPost>> GetAllBlogPostsAsync();

  public Task<IEnumerable<BlogPost>> GetAllArchivedBlogPostsAsync(int? tagId);

  public Task<BlogPost> GetBlogDetailsAsync(int? id);

  public Task CreateBlogPostAsync(BlogPost blogPost, IEnumerable<int> selected);

  public Task<BlogPost> EditBlogPostAsync(BlogPost blogPost, IEnumerable<int> selected);

  public Task<BlogPost> DeleteBlogPostAsync_Get(int? id);

  public Task UpdateBlogPostAsync(BlogPost blogPost);

  public Task<BlogPost> GetBlogByIdAsync(int? id);

  public Task<IEnumerable<Category>> GetCategoriesAsync();
  
  public Task<IEnumerable<BlogPost>> GetPopularBlogsAsync();

  public Task<List<BlogPost>> FilterBlogPostByCategory(int? categoryId);

  public IEnumerable<BlogPost> SearchBlogPost(string searchString);
  public Task DeleteBlogPostAsync(int id);

  public Task<IEnumerable<BlogPost>> GetAllDraftBlogPostsAsync(int? tagId);

  public Task<bool> IsValidSlugAsync(string? title, int? blogPostId);

  public Task<BlogPost> GetBlogBySlugAsync(string? slug);
  public Task<IEnumerable<BlogPost>> GetFavoriteBlogPostsAsync(string? blogUserId);

  public Task<bool> UserLikedBlogAsync(int blogPostId, string blogUserId);
}
