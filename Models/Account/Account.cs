using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Account
{
  public Account(string name, Guid userId, AccountType type)
  {
    Name = name;
    UserId = userId;
    Type = type;
    // CurrentBalance vai ser 0 inicialmente, atualizado depois pelo transactions
  }
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Name { get; set; }
  public AccountType Type { get; set; }
  public decimal CurrentBalance { get; set; }
  public Guid UserId { get; set; }
  public virtual User User { get; set; }
}

public enum AccountType
{
  Wallet,     // Carteira
  Checking,   // Conta Corrente
  Savings,    // Poupança
  Investment, // Investimentos
  CreditCard  // Cartão de Crédito
}