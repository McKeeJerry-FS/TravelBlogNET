using System;
using TravelBlog.Enums;

namespace TravelBlog.Services.Interfaces;

public interface IImageService
{
  public Task<byte[]> ConvertFileToByteArrayAsynC(IFormFile? file);
  public string? ConvertByteArrayToFile(byte[]? FileData, string? extension, DefaultImage defaultImage);
}
