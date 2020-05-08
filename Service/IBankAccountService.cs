using Assignment_1.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_1.Service
{
    public interface IBankAccountService
    {
        IEnumerable<BankAccountDto> FetchAllAccounts();

        dynamic FetchAllDebitCards();
    }
}
