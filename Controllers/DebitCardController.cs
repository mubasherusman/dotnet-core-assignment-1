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
    [Route(Constants.API_PREFIX + "debit-card")]
    public class DebitCardController : ControllerBase
    {
        private readonly IDebitCardService debitCardService;

        public DebitCardController(IDebitCardService debitCardService)
        {
            this.debitCardService = debitCardService;
        }

        [HttpGet]
        public IActionResult GetDebitCards()
        {
            return Ok(debitCardService.FetchAllDebitCards());
        }

        [HttpPost]
        public IActionResult saveDebitCard(DebitCardDto dto)
        {
            debitCardService.createDebitCard(dto);
            return Ok();
        }
    }
}
