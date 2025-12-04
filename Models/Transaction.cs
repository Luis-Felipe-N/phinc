public class Transaction
{
  public Transaction(decimal amount, DateTime date, Guid accountId, Guid categoryId)
  {
    Amount = amount;
    Date = date;
    AccountId = accountId;
    CategoryId = categoryId;
    Id = Guid.NewGuid();
  }
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Description { get; set; }
  public decimal Amount { get; set; }
  // public TransactionType Type { get; set; }
  public DateTime Date { get; set; }
  public bool IsPaid { get; set; } = true;
  public Guid AccountId { get; set; }
  public virtual Account Account { get; set; }
  public Guid CategoryId { get; set; }
  public virtual Category Category { get; set; }
  public Guid UserId { get; set; }
}