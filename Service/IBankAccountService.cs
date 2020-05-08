using Assignment_1.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_1.Service
{
    public interface IBankAccountService
    {
        IEnumerable<BankAccountDto> FetchAllAccounts();

        IEnumerable<DebitCardDto> FetchAllDebitCards();
    }
}
