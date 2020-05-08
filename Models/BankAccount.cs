using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_1.Models
{
    public class BankAccount
    {
        public int Id { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        public ICollection<DebitCard> DebitCards { get; set; }

    }
}
