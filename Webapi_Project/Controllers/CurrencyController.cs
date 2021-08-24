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

        private readonly ICurrencyService currency;

        public CurrencyController(ICurrencyService currency)
        {
            this.currency = currency;
        }
        [HttpPost]
        public ConversionResponse GetConvertedAmount(ConversionRequest conversionRequest)
        {
            ConversionResponse res = new ConversionResponse();
            res.RateResponses = new List<CurrencyRateResponse>();
            foreach (var item in conversionRequest.RateRequests)
            {
                double convertRate = currency.ExchangeRateService(item.from, item.to);
                CurrencyRateResponse rateResponse = new CurrencyRateResponse();
                rateResponse.from = item.from;
                rateResponse.to = item.to;
                rateResponse.amount = item.amount;
                rateResponse.convertedamount = item.amount * convertRate;
                res.RateResponses.Add(rateResponse);
            }
            return res;
        }
    }
}
