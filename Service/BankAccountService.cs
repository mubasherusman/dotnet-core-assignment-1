using Assignment_1.Data;
using Assignment_1.Dto;
using Assignment_1.Mappers;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_1.Service
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

        public IEnumerable<DebitCardDto> FetchAllDebitCards() {
            logger.LogInformation("Inside FetchAllDebitCards Method for Debit cards");

            return dataContext.DebitCards.
                Join(dataContext.BankAccounts,
                debitCard => debitCard.BankAccount.Id,
                bankAccount => bankAccount.Id,
                (debitCard, bankAccount) => new DebitCardDto {
                    CardName = debitCard.CardName,
                    CardNumber = debitCard.Id,
                    BankAccount = BankAccountMapper.ToBankAccountDTOMap(bankAccount)
                })
                .ToList();
        }
    }
}
