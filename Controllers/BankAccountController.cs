using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetAssignment.Data;
using DotNetAssignment.Dto;
using DotNetAssignment.Mappers;
using DotNetAssignment.Models;
using DotNetAssignment.Service;
using DotNetAssignment.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetAssignment.Controllers
{
    [ApiController]
    [Route(Constants.API_PREFIX + "bank-account")]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService bankAccountService;

        public BankAccountController(IBankAccountService bankAccountService)
        {
            this.bankAccountService = bankAccountService;
        }

        [HttpGet]
        public IAsyncEnumerable<BankAccountDto> Get()
        {
            return bankAccountService.FetchAllAccounts();
        }
    }
}
