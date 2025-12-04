using finc.Data;

public static class AccountRoute
{
  public static void AccountRoutes(this WebApplication app)
  {
    var routes = app.MapGroup("/accounts");

    app.MapGet("", () => "Get all accounts");
    app.MapPost("", async (UserRequest req, DataContext context) =>
{

});
  }
}