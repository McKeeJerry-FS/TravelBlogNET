using System;
using Npgsql;
using Microsoft.AspNetCore.Identity;
using TravelBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace TravelBlog.Data;

public class DataUtility
{
    // Admin & Moderator - for use with roles
    public const string? _adminRole = "Admin";
    public const string? _moderatorRole = "Moderator";

    public static string GetConnectionString(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
        return string.IsNullOrEmpty(databaseUrl) ? connectionString! : BuildConnectionString(databaseUrl);
    }

    private static string BuildConnectionString(string databaseUrl)
    {
        //Provides an object representation of a uniform resource identifier (URI) and easy access to the parts of the URI.
        var databaseUri = new Uri(databaseUrl);
        var userInfo = databaseUri.UserInfo.Split(':');
        //Provides a simple way to create and manage the contents of connection strings used by the NpgsqlConnection class.
        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = databaseUri.Host,
            Port = databaseUri.Port,
            Username = userInfo[0],
            Password = userInfo[1],
            Database = databaseUri.LocalPath.TrimStart('/'),
            SslMode = SslMode.Prefer,
            TrustServerCertificate = true
        };
        return builder.ToString();
    }

    public static async Task ManageDatabaseAsync(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
        var userManager = serviceProvider.GetRequiredService<UserManager<BlogUser>>();
        var configurationSvc = serviceProvider.GetRequiredService<IConfiguration>();
        var roleManagerSvc = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // align the database by checking the migrations
        await dbContext.Database.MigrateAsync();

        // seed some data
        await SeedRolesAsync(roleManagerSvc);
        await SeedBlogUsersAsync(userManager, configurationSvc);
    }
    
    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(_adminRole!))
            {
                await roleManager.CreateAsync(new IdentityRole(_adminRole!));
            }

            if (!await roleManager.RoleExistsAsync(_moderatorRole!))
            {
                await roleManager.CreateAsync(new IdentityRole(_moderatorRole!));
            }
        }

    private static async Task SeedBlogUsersAsync(UserManager<BlogUser> userManager, IConfiguration configuration)
    {
        string? adminEmail = configuration["AdminEmail"] ?? Environment.GetEnvironmentVariable("AdminEmail");
        string? adminPassword = configuration["AdminPWD"] ?? Environment.GetEnvironmentVariable("AdminPWD");
        string? moderatorEmail = configuration["ModeratorEmail"] ?? Environment.GetEnvironmentVariable("ModeratorEmail");
        string? moderatorPassword = configuration["ModeratorPWD"] ?? Environment.GetEnvironmentVariable("ModeratorPWD");

        try
        {
            // Admin
            var adminUser = await userManager.FindByEmailAsync(adminEmail!);
            if (adminUser == null)
            {
                adminUser = new BlogUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Jerry",
                    LastName = "McKee",
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(adminUser, adminPassword!);
                if (!result.Succeeded)
                {
                    // Optionally log errors here
                }
            }
            // Always get the user from the DB before adding to role
            adminUser = await userManager.FindByEmailAsync(adminEmail!);
            if (adminUser != null && !await userManager.IsInRoleAsync(adminUser, _adminRole!))
            {
                await userManager.AddToRoleAsync(adminUser, _adminRole!);
            }

            // Moderator
            var moderatorUser = await userManager.FindByEmailAsync(moderatorEmail!);
            if (moderatorUser == null)
            {
                moderatorUser = new BlogUser
                {
                    UserName = moderatorEmail,
                    Email = moderatorEmail,
                    FirstName = "John",
                    LastName = "Smith",
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(moderatorUser, moderatorPassword!);
                if (!result.Succeeded)
                {
                    // Optionally log errors here
                }
            }
            moderatorUser = await userManager.FindByEmailAsync(moderatorEmail!);
            if (moderatorUser != null && !await userManager.IsInRoleAsync(moderatorUser, _moderatorRole!))
            {
                await userManager.AddToRoleAsync(moderatorUser, _moderatorRole!);
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("****************** ERROR *****************");
            Console.WriteLine($"Failure Seeding Default Blog Users Error: {ex.Message}");
            Console.WriteLine("****************** ERROR *****************");
            Console.ResetColor();
            throw;
        }
    }
}
