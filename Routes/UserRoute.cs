using finc.Data;
using Microsoft.EntityFrameworkCore;

public static class UserRoute
{
  public static void UserRoutes(this WebApplication app)
  {
    var route = app.MapGroup("/users");

    route.MapGet("me", async (DataContext context) =>
    {
      var user = await context.User.Include(u => u.Accounts).Include(u => u.Categories).FirstOrDefaultAsync();
    });

    route.MapPost("register", async (RegisterRequest req, DataContext context) =>
      {
        var userExists = await context.User.FirstOrDefaultAsync(u => u.Email == req.Email);

        if (userExists != null)
        {
          return Results.BadRequest("Email já cadastrado.");
        }

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(req.Password);

        var user = new User(req.Name, req.Email, passwordHash);

        await context.User.AddAsync(user);
        await context.SaveChangesAsync();

        return Results.Created($"/users/{user.Id}", new { user.Id, user.Name, user.Email });
      });
  }
}