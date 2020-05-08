using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_1.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_1.Controllers
{
    [Route(Constants.API_PREFIX)]
    [ApiController]
    public class BaseController : ControllerBase
    {
    }
}