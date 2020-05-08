using Assignment_1.Dto;
using Assignment_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_1.Mappers
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
