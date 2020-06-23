using DotNetAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAssignment.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<DebitCard> DebitCards { get; set; }
    }
}
