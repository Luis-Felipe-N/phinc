using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Account
{
  public Account(string name)
  {
    Name = name;
    Id = Guid.NewGuid();
  }
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Name { get; set; }
  // public AccountType Type { get; set; }
  public decimal CurrentBalance { get; set; }
  public Guid UserId { get; set; }
  public virtual User User { get; set; }
}