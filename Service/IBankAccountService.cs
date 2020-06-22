using DotNetAssignment.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAssignment.Service
{
    public interface IBankAccountService
    {
        IEnumerable<BankAccountDto> FetchAllAccounts();

        dynamic FetchAllDebitCards();
    }
}
