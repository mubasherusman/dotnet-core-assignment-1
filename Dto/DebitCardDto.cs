using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_1.Dto
{
    public class DebitCardDto
    {
        public int CardNumber { get; set; }
        public string CardName { get; set; }
        public BankAccountDto BankAccount { get; set; }
    }
}
