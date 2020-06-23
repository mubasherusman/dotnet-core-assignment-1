using DotNetAssignment.Data;
using DotNetAssignment.Data.Repository;
using DotNetAssignment.Dto;
using DotNetAssignment.Mappers;
using DotNetAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAssignment.Service
{
    public class BankAccountService : IBankAccountService
    {
        private readonly ILogger<BankAccountService> logger;
        private readonly BankAccountRepository repository;

        public BankAccountService(ILogger<BankAccountService> logger,
                                    BankAccountRepository repository) {
            this.logger = logger;
            this.repository = repository;
        }

        public async IAsyncEnumerable<BankAccountDto> FetchAllAccounts() {
            logger.LogInformation("Inside FetchAllAccounts Method for Account");
            List<BankAccount> accounts = await repository.FetchAll();
            foreach(BankAccount a in accounts)
            {
                yield return BankAccountMapper.ToBankAccountDTOMap(a);
            }
            
        }
    }
}
