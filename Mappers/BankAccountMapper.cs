using DotNetAssignment.Dto;
using DotNetAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAssignment.Mappers
{
    public class BankAccountMapper
    {
        public static BankAccountDto ToBankAccountDTOMap(BankAccount ba)
        {
            if (ba == null)
            {
                return null;
            }

            return new BankAccountDto()
            {
                BankAccountInternalId = ba.Id,
                CustomerAccountNumber = ba.AccountNumber
            };
        }
        
    }
}
