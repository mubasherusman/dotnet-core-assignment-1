using Assignment_1.Dto;
using Assignment_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_1.Mappers
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
