using DotNetAssignment.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetAssignment.Service
{
    public interface IDebitCardService
    {
        dynamic FetchAllDebitCards();

        void createDebitCard(DebitCardDto dto);
    }
}
