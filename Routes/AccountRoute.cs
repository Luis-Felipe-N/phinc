using finc.Data;
using Microsoft.EntityFrameworkCore;

public static class AccountRoute
{
  public static void AccountRoutes(this WebApplication app)
  {
    var route = app.MapGroup("/accounts");

    route.MapGet("", async (DataContext context) =>
    {
      var accounts = await context.Account.ToListAsync();
      return Results.Ok(accounts);
    });
    route.MapPost("", async (CreateAccountRequest req, DataContext context) =>
      {
        var userExists = await context.User.FindAsync(req.UserId);

        if (userExists == null)
        {
          return Results.BadRequest("Usuário não encontrado.");
        }

        var accountExists = await context.Account.FirstOrDefaultAsync(a => a.Name == req.Name && a.UserId == req.UserId);

        if (accountExists != null)
        {
          return Results.BadRequest("Conta já cadastrada para este usuário.");
        }

        var account = new Account(req.Name, req.UserId, req.Type);

        await context.Account.AddAsync(account);
        await context.SaveChangesAsync();

        return Results.Created($"/accounts/{account.Id}", new { account.Id, account.Name, account.Type, account.CurrentBalance, account.UserId });
      });
  }
}