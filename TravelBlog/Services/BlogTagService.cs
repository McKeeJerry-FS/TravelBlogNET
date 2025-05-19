using System;
using TravelBlog.Services.Interfaces;

namespace TravelBlog.Services;

public class BlogTagService : IBlogTagService
{
  public Task AddTagsToBlogPostAsync(IEnumerable<int> tagId, int blogPostId)
  {
    throw new NotImplementedException();
  }

  public Task RemoveTagsFromBlogPostAsync(int blogPostId)
  {
    throw new NotImplementedException();
  }
}
