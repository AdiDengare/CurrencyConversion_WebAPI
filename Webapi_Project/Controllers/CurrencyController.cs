using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Webapi_Project.Models;
using Webapi_Project.Services;

namespace Webapi_Project.Controllers
{
    [ApiController]
    [Route("currencies")]
    public class CurrencyController : Controller
    {

        private readonly ICurrencyRate currency;

        public CurrencyController(ICurrencyRate currency)
        {
            this.currency = currency;
        }
        [HttpPost]
        public ActionResult GetConversionResponse(List<CurrencyRate> currencyRate)
        {
            var result = currency.GetAmount(currencyRate);
            return Ok(result);
        }
    }
}
