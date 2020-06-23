using DotNetAssignment.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAssignment.Models
{
    public class BankAccount : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 8)]
        public string AccountNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        public ICollection<DebitCard> DebitCards { get; set; }

    }
}
