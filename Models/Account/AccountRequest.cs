public record CreateAccountRequest(
    string Name,
    Guid UserId,
    AccountType Type
);