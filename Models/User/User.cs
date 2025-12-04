using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class User
{
    public User(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    // Relacionamentos
    public virtual ICollection<Account> Accounts { get; set; }
    public virtual ICollection<Category> Categories { get; set; }
}