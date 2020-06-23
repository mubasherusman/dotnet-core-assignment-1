using DotNetAssignment.Data.Repository;
using DotNetAssignment.Dto;
using DotNetAssignment.Mappers;
using DotNetAssignment.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAssignment.Service
{
    public class DebitCardService : IDebitCardService
    {
        private readonly ILogger<DebitCardService> logger;
        private readonly DebitCardRepository repository;
        private readonly BankAccountRepository bankAccountRepository;

        public DebitCardService(ILogger<DebitCardService> logger,
                                    DebitCardRepository repository,
                                    BankAccountRepository bankAccountRepository)
        {
            this.logger = logger;
            this.repository = repository;
            this.bankAccountRepository = bankAccountRepository;
        }

        public async void createDebitCard(DebitCardDto dto)
        {
            DebitCard debitCard = DebitCardMapper.ToDebitCardMap(dto);
            if (debitCard != null)
            {
                var abc = new System.Security.Cryptography.HMACSHA512();
                debitCard.Pan = abc.ComputeHash(System.Text.Encoding.UTF8.GetBytes("abcdefghijklmnopqrstuvwxyz"));
                if (debitCard.BankAccount != null && debitCard.BankAccount.Id != 0)
                {
                    debitCard.BankAccount = await bankAccountRepository.FetchById(debitCard.BankAccount.Id);
                }
                await repository.Save(debitCard);
            }
           

        }

        public dynamic FetchAllDebitCards()
        {
            return repository.FetchAllDebitCardsWithBankAccount();
        }
    }
}
