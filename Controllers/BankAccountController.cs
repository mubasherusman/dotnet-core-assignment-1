using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_1.Data;
using Assignment_1.Dto;
using Assignment_1.Mappers;
using Assignment_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Assignment_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankAccountController : BaseController
    {

        private readonly ILogger<BankAccountController> logger;
        private readonly DataContext dataContext;

        public BankAccountController(ILogger<BankAccountController> logger, DataContext dataContext)
        {
            this.logger = logger;
            this.dataContext = dataContext;
        }

        [HttpGet]
        public ICollection<BankAccountDto> Get()
        {
            logger.LogInformation("Inside Get Method for Account");
            return dataContext.BankAccounts.Select(x=>BankAccountMapper.ToBankAccountDTOMap(x)).ToList();
        }
    }
}
