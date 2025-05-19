using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace TravelBlog.Models;

public class AppUser : IdentityUser
{
  [Required]
  [Display(Name = "First Name")]
  [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
  public string FirstName { get; set; } = string.Empty;

  [Required]
  [Display(Name = "Last Name")]
  [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
  public string LastName { get; set; } = string.Empty;

  [NotMapped]
  public string? FullName { get { return $"{FirstName} {LastName}"; } }
}
