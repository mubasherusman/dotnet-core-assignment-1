using DotNetAssignment.Dto;
using DotNetAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAssignment.Mappers
{
    public class DebitCardMapper
    {

        public static DebitCardDto ToDebitCardDTOMap(DebitCard d)
        {
            return new DebitCardDto()
            {
                CardNumber = d.Id,
                CardName = d.CardName,
                BankAccount = BankAccountMapper.ToBankAccountDTOMap(d.BankAccount)
            };
        }
    }
}
