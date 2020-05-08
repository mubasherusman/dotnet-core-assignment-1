using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_1.Models
{
    public class DebitCard
    {
        public int Id { get; set; }

        public string CardName { get; set; }

        public BankAccount BankAccount { get; set; }

    }
}
