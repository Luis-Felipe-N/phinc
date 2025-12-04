using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace finc.Data;

public class DataContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Account> Account { get; set; }

    override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=finc.sqlite");
    }
}
