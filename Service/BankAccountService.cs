using DotNetAssignment.Data;
using DotNetAssignment.Dto;
using DotNetAssignment.Mappers;
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
        private readonly DataContext dataContext;

        public BankAccountService(ILogger<BankAccountService> logger,
                                    DataContext context) {
            this.logger = logger;
            dataContext = context;
        }

        public IEnumerable<BankAccountDto> FetchAllAccounts() {
            logger.LogInformation("Inside FetchAllAccounts Method for Account");
            return dataContext.BankAccounts.Select(x => BankAccountMapper.ToBankAccountDTOMap(x)).ToList();
        }

        public dynamic FetchAllDebitCards() {
            logger.LogInformation("Inside FetchAllDebitCards Method for Debit cards");

            var debitCard = dataContext.DebitCards.
                Join(dataContext.BankAccounts,
                debitCard => debitCard.BankAccount.Id,
                bankAccount => bankAccount.Id,
                (debitCard, bankAccount) => new {
                    debitCard.CardName,
                    CardNumber = debitCard.Id,
                    BankAccount = BankAccountMapper.ToBankAccountDTOMap(bankAccount)
                })
                .ToList();
            return debitCard;
        }
    }
}
