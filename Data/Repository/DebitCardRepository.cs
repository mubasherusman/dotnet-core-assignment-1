using DotNetAssignment.Mappers;
using DotNetAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAssignment.Data.Repository
{
    public class DebitCardRepository : BaseRepository<DebitCard, DataContext>
    {
        private readonly DataContext dataContext;
        public DebitCardRepository(DataContext context) : base(context)
        {
            this.dataContext = context;
        }

        public dynamic FetchAllDebitCardsWithBankAccount()
        {
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
