using DotNetAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAssignment.Data.Repository
{
    public class BankAccountRepository : BaseRepository<BankAccount, DataContext>
    {
        public BankAccountRepository(DataContext context) : base(context)
        {

        }
    
    }
}
