using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_1.Data;
using Assignment_1.Dto;
using Assignment_1.Mappers;
using Assignment_1.Models;
using Assignment_1.Service;
using Assignment_1.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Assignment_1.Controllers
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
        public IEnumerable<BankAccountDto> Get()
        {
            return bankAccountService.FetchAllAccounts();
        }

        [HttpGet("debit-card")]
        public IEnumerable<DebitCardDto> GetDebitCards()
        {
            return bankAccountService.FetchAllDebitCards();
        }
    }
}
