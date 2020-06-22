using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAssignment.Dto
{
    public class DebitCardDto
    {
        public int CardNumber { get; set; }
        public string CardName { get; set; }
        public BankAccountDto BankAccount { get; set; }
    }
}
