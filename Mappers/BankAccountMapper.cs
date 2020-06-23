using DotNetAssignment.Dto;
using DotNetAssignment.Models;
using System;
using System.Collections;
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

        public static List<BankAccountDto> ToBankAccountDTOMap(List<BankAccount> ba)
        {
            if (ba == null)
            {
                return null;
            }

            List<BankAccountDto> list = new List<BankAccountDto>();
            ba.ForEach(x => list.Add(ToBankAccountDTOMap(x)));
            return list;
        }

        public static BankAccount ToBankAccountMap(BankAccountDto dto)
        {
            if (dto == null)
            {
                return null;
            }


            return new BankAccount()
            {
                Id = dto.BankAccountInternalId,
                AccountNumber = dto.CustomerAccountNumber,
                CreateDate = new DateTime()
            };
        }

    }
}
